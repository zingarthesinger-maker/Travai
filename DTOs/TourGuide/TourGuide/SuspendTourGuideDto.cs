using travai.TourGuide.Models;
using System.ComponentModel.DataAnnotations;
using travai.Models.Enums;
using travai.TourGuide.Models.Enums;

namespace travai.TourGuide.DTOs.TourGuide
{
    public class SuspendTourGuideDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }

        [Required]
        public SuspensionUnit Unit { get; set; }
    }
}


