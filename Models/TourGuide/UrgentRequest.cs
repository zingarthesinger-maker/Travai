using travai.TourGuide.Models.Enums;
using travai.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using travai.Models.Enums;

namespace travai.TourGuide.Models
{
    public class UrgentRequest
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("TourGuide")]
        public long TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }

        [ForeignKey("Tour")]
        public long TourId { get; set; }
        public Tour Tour { get; set; }

        [Required]
        public string Reason { get; set; }
        
        public string? DocumentationUrl { get; set; }

        public UrgentRequestStatus Status { get; set; } = UrgentRequestStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }
        public string? AdminNotes { get; set; }
    }
}


