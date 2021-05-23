using System.Text.Json.Serialization;

namespace ClientsApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Lead,
        Potential,
        NotTarget,
        Consultation,
        Application,
        Deal,
        TransactionParticipant,
        Rejection
    }
}