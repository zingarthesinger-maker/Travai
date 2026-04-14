using travai.TourGuide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using travai.TourGuide.DTOs.WithdrawRequest;

namespace travai.TourGuide.Services
{
    public interface IWithdrawRequestService
    {
        Task<WithdrawRequestResponseDto> CreateWithdrawRequestAsync(long tourGuideId, CreateWithdrawRequestDto model);
        Task<List<WithdrawRequestResponseDto>> GetAllPendingRequestsAsync();
        Task<List<WithdrawRequestResponseDto>> GetMyRequestsAsync(long tourGuideId);
        Task<WithdrawRequestResponseDto> ProcessRequestAsync(long requestId, ProcessWithdrawRequestDto model);
    }
}

