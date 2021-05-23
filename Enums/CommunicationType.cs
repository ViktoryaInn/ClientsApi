using System.Text.Json.Serialization;

namespace ClientsApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CommunicationType
    {
        Email,
        Phone
    }
}