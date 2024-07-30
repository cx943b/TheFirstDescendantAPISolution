using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.User
{
    [JsonConverter(typeof(SchemeJsonConverter<ExternalComponent>))]
    public class ExternalComponent
    {
        public string ExternalComponentId { get; set; } = "";
        public string ExternalComponentSlotId { get; set; } = "";
        public int ExternalComponentLevel { get; set; }
        public IEnumerable<AdditionalStat> ExternalComponentAdditionalStats { get; set; } = Enumerable.Empty<AdditionalStat>();
    }
}
