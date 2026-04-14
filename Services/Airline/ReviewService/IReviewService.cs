using travai;
using travai.Airline.DTOs.Review;

namespace travai.Airline.Services.ReviewService
{
    public interface IReviewService
    {
        Task<ReviewResponseDto> AddReviewAsync(long userId, ReviewRequestDto dto);
        Task<List<ReviewResponseDto>> GetFlightReviewsAsync(long flightId);
    }
}



