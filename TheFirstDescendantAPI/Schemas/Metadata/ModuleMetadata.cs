using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<ModuleMetadata>))]
    public class ModuleMetadata : IMetadata
    {
        public string ModuleName { get; set; } = "";
        public string ModuleId { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string ModuleType { get; set; } = "";
        public string ModuleTier { get; set; } = "";
        public string ModuleSocketType { get; set; } = "";
        public string ModuleClass { get; set; } = "";

        public IEnumerable<ModuleStat> ModuleStats { get; set; } = Enumerable.Empty<ModuleStat>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<ModuleStat>))]
    public class ModuleStat
    {
        public int Level { get; set; }
        public int ModuleCapacity { get; set; }
        public string Value { get; set; } = "";
    }
}