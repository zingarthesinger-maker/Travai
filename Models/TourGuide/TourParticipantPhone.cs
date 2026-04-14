using travai.TourGuide.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travai.TourGuide.Models
{
    public class TourParticipantPhone
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Participant")]
        public long ParticipantId { get; set; }
        public TourBookingParticipant Participant { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}


