using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<Module>))]
    public class Module
    {
        public string ModuleId { get; set; } = "";
        public string ModuleSlotId { get; set; } = "";
        public int ModuleEnchantLevel { get; set; }
    }
}