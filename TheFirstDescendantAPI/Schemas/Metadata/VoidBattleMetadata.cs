using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<VoidBattleMetadata>))]
    public class VoidBattleMetadata : IMetadata
    {
        public string VoidBattleId { get; set; } = "";
        public string VoidBattleName { get; set; } = "";
    }
}
