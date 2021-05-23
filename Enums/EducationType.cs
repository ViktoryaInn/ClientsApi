using System.Text.Json.Serialization;

namespace ClientsApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EducationType
    {
        Secondary,
        SecondarySpecial,
        IncompleteHigher,
        Higher,
        TwoOrMoreHigher,
        AcademicDegree
    }
}