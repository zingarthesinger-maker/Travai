using travai.TourGuide.Models;
using System.Collections.Generic;
using travai.Models.Enums;
using travai.TourGuide.Models.Enums;

namespace travai.TourGuide.DTOs.TourGuide
{
    public class UpdateProfileDto
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Certification { get; set; }
        public int? ExperienceYears { get; set; }

        public List<string>? Emails { get; set; }
        public List<string>? PhoneNumbers { get; set; }
        public List<Language>? Languages { get; set; }
        public List<string>? Cities { get; set; }
    }
}


