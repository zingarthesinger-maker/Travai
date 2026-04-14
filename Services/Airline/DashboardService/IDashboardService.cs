using travai;
using travai.Airline.DTOs.Dashboard;

namespace travai.Airline.Services.DashboardService
{
    public interface IDashboardService
    {
        Task<DashboardStatsDto> GetStatsAsync();
    }
}



