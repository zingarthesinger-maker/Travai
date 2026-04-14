using travai.TourGuide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using travai.TourGuide.DTOs.Booking;
using travai.Models.Enums;
using travai.TourGuide.Models.Enums;
using BookingStatus = travai.TourGuide.Models.Enums.BookingStatus;

namespace travai.TourGuide.Services
{
    public interface IBookingService
    {
        // Direct booking - creates booking with Pending status (1 participant by default)
        Task<BookingResponseDto> CreateBookingAsync(long userId, long tourId);
        
        // Update booking participants
        Task<BookingResponseDto> UpdateBookingParticipantsAsync(long userId, long bookingId, List<ParticipantDto> participants);
        
        // Payment processing - changes status from Pending to Confirmed
        Task<BookingResponseDto> ProcessPaymentAsync(long userId, ProcessPaymentDto model);
        
        // Cancel booking (before or after payment)
        Task<bool> CancelBookingAsync(long userId, long bookingId);
        
        // Get user's bookings (all statuses or specific status)
        Task<List<BookingResponseDto>> GetUserBookingsAsync(long userId, BookingStatus? status = null);
        Task<BookingResponseDto> GetBookingByIdAsync(long userId, long bookingId);
        
        // Admin - Get all bookings
        Task<List<BookingResponseDto>> GetAllBookingsAsync(BookingStatus? status = null);
        Task<BookingResponseDto> GetBookingByAdminAsync(long bookingId);
        
        // Check tour availability
        Task<bool> IsTourAvailableAsync(long tourId, int participantsCount);
    }
}


