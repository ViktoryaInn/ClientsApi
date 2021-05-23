using System.Text.Json.Serialization;

namespace ClientsApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobType
    {
        Pluralistically,
        Main,
        Owner
    }
}