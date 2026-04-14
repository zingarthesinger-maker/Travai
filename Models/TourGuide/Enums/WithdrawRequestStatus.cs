using System.Text.Json.Serialization;

namespace travai.TourGuide.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WithdrawRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

