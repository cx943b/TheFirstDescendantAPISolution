using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Responses
{
    [JsonConverter(typeof(ErrorResponseJsonConverter))]
    public class ErrorResponse : ResponseBase
    {
        public string Name { get; set; } = "";
        public string Message { get; set; } = "";

        public override string ToString() => $"Name: {Name}\r\nMessage: {Message}";
    }
}
