using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<AdditionalStat>))]
    public class AdditionalStat
    {
        public string AdditionalStatName { get; set; } = "";
        public string AdditionalStatValue { get; set; } = "";
    }
}
