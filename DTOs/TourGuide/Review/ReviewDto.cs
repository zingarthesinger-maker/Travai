using travai.TourGuide.Models;
using System;

namespace travai.TourGuide.DTOs.Review
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long? TourGuideId { get; set; }
        public long? TourId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


