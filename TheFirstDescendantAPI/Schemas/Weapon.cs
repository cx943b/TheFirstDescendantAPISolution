using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<Weapon>))]
    public class Weapon
    {
        public int ModuleMaxCapacity { get; set; }
        public int ModuleCapacity { get; set; }
        public string WeaponSlotId { get; set; } = "";
        public string WeaponId { get; set; } = "";
        public int WeaponLevel { get; set; }
        public int? PerkAbilityEnchantLevel { get; set; }

        public IEnumerable<AdditionalStat> WeaponAdditionalStats { get; set; } = Enumerable.Empty<AdditionalStat>();
        public IEnumerable<Module> Modules { get; set; } = Enumerable.Empty<Module>();
    }
}