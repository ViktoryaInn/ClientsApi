using System.Text.Json.Serialization;

namespace ClientsApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MaritalStatus
    {
        Single,
        Married,
        Widow,
        InDivorce,
        CivilMarriage
    }
}