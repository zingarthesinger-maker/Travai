using travai;
using travai.Airline.DTOs.Airport;

namespace travai.Airline.Services.AirportService
{
    public interface IAirportService
    {
        Task<List<AirportDto>> GetAllAsync();
        Task<List<AirportDto>> SearchAsync(string query);
        Task<AirportDto?> GetByCodeAsync(string code);
        Task CreateAsync(CreateAirportDto dto);
        Task DeleteAsync(string code);
    }
}



