using travai.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using travai.Airline.Models.Airlines;

namespace travai.Airline.Models
{
    public class Review
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public long FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; } = null!;

        public int Rating { get; set; } // 1 to 5
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}




