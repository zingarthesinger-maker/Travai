using travai.TourGuide.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travai.TourGuide.Models
{
    public class TourGuideCity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("TourGuide")]
        public long TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }

        [Required]
        public string City { get; set; }
    }
}


