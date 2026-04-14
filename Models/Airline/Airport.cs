using travai.Models.Enums;
using travai.Models;
using System.ComponentModel.DataAnnotations;

namespace travai.Airline.Models
{
    public class Airport
    {
        [Key]
        [MaxLength(3)]
        public string Code { get; set; } = null!; // CAI, DXB

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string City { get; set; } = null!;

        [MaxLength(100)]
        public string Country { get; set; } = null!;
    }
}


