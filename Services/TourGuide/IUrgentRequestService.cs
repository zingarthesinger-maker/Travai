using travai.TourGuide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using travai.TourGuide.DTOs.UrgentRequest;

namespace travai.TourGuide.Services
{
    public interface IUrgentRequestService
    {
        Task<UrgentRequestResponseDto> CreateUrgentRequestAsync(long tourGuideId, CreateUrgentRequestDto model);
        Task<List<UrgentRequestResponseDto>> GetAllPendingRequestsAsync();
        Task<List<UrgentRequestResponseDto>> GetMyRequestsAsync(long tourGuideId);
        Task<UrgentRequestResponseDto> ProcessRequestAsync(long requestId, AdminProcessUrgentRequestDto model);
    }
}

