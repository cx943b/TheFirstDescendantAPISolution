using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<TitleMetadata>))]
    public class TitleMetadata : IMetadata
    {
        public string TitleId { get; set; } = "";
        public string TitleName { get; set; } = "";
    }
}
