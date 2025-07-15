using System.Text.Json.Serialization;

namespace CafePilot.Server.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Pending,
        InProgress,
        Done,
        Canceled
    }

}
