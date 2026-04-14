using System.Text.Json.Serialization;

namespace travai.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        User,
        Admin,
        Tourguide,
        Hotel,
        Airline
    }
}
