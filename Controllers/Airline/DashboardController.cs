using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using travai.DTOs;
using travai.Airline.Services.DashboardService;

namespace travai.Airline.Controllers
{
    [ApiController]
    [Route("api/airline/dashboard")]
    [Authorize(Roles = "Admin,Airline")]
    [ApiExplorerSettings(GroupName = "Airline")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _dashboardService.GetStatsAsync();
            return Ok(new ApiResponse<object>(stats));
        }
    }
}
