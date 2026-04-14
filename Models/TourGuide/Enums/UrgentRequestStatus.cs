using System.Text.Json.Serialization;

namespace travai.TourGuide.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UrgentRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

