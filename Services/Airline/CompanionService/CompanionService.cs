using travai;
using Microsoft.EntityFrameworkCore;

using travai.Airline.DTOs.Companion;
using travai.Models;
using travai.Airline.Models;

namespace travai.Airline.Services.CompanionService
{
    public class CompanionService : ICompanionService
    {
        private readonly ApplicationDbContext _context;

        public CompanionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserCompanionDto>> GetMyCompanionsAsync(long userId)
        {
            return await _context.UserCompanions
                .Where(c => c.UserId == userId)
                .Select(c => new UserCompanionDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    AgeType = c.AgeType,
                    PassportNumber = c.PassportNumber,
                    Nationality = c.Nationality,
                    ProfilePic = c.ProfilePic,
                    PassportImage = c.PassportImage
                })
                .ToListAsync();
        }

        public async Task<UserCompanionDto> AddCompanionAsync(long userId, CreateCompanionDto dto)
        {
            var companion = new UserCompanion
            {
                UserId = userId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                AgeType = dto.AgeType,
                PassportNumber = dto.PassportNumber,
                Nationality = dto.Nationality,
                ProfilePic = dto.ProfilePic,
                PassportImage = dto.PassportImage
            };

            _context.UserCompanions.Add(companion);
            await _context.SaveChangesAsync();

            return new UserCompanionDto
            {
                Id = companion.Id,
                FirstName = companion.FirstName,
                LastName = companion.LastName,
                AgeType = companion.AgeType,
                PassportNumber = companion.PassportNumber,
                Nationality = companion.Nationality,
                ProfilePic = companion.ProfilePic,
                PassportImage = companion.PassportImage
            };
        }

        public async Task DeleteCompanionAsync(long userId, long companionId)
        {
            var companion = await _context.UserCompanions
                .FirstOrDefaultAsync(c => c.Id == companionId && c.UserId == userId);

            if (companion == null) throw new Exception("Companion not found.");

            _context.UserCompanions.Remove(companion);
            await _context.SaveChangesAsync();
        }
    }
}



