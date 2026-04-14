using travai.TourGuide.Models.Enums;
using travai.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using travai.Models.Enums;
using BookingStatus = travai.TourGuide.Models.Enums.BookingStatus;
using PaymentStatus = travai.TourGuide.Models.Enums.PaymentStatus;

namespace travai.TourGuide.Models
{
    public class TourBooking
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Tour")]
        public long TourId { get; set; }
        public Tour Tour { get; set; }

        [ForeignKey("TourGuide")]
        public long TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }

        public DateTime? BookingDate { get; set; }
        public DateTime? TourDate { get; set; }
        public TimeSpan? TourTime { get; set; }
        public int ParticipantsCount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        
        public string Currency { get; set; } = "USD";
        public string? SpecialRequests { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        
        [Column(TypeName = "nvarchar(20)")]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TourBookingParticipant> Participants { get; set; } = new List<TourBookingParticipant>();
        public ICollection<TourBookingPayment> Payments { get; set; } = new List<TourBookingPayment>();
    }
}


