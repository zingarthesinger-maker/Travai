using travai.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travai.Airline.Models
{
    public class PassengerPhone
    {
        [Key]
        public long Id { get; set; }

        public long PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;
    }
}


