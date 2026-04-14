using travai.TourGuide.Models;
using System.ComponentModel.DataAnnotations;

namespace travai.TourGuide.DTOs.TourGuide
{
    public class RejectApplicationDto
    {
        [Required]
        public string Reason { get; set; }
    }
}


