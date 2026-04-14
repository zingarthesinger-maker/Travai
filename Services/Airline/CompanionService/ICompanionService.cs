using travai;
using travai.Airline.DTOs.Companion;

namespace travai.Airline.Services.CompanionService
{
    public interface ICompanionService
    {
        Task<List<UserCompanionDto>> GetMyCompanionsAsync(long userId);
        Task<UserCompanionDto> AddCompanionAsync(long userId, CreateCompanionDto dto);
        Task DeleteCompanionAsync(long userId, long companionId);
    }
}



