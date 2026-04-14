using travai.TourGuide.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travai.TourGuide.Models
{
    public class TourGuidePhone
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("TourGuide")]
        public long TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public bool PhoneVerified { get; set; } = false;
    }
}


