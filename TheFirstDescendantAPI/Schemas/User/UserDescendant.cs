using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.User
{
    [JsonConverter(typeof(SchemeJsonConverter<UserDescendant>))]
    public class UserDescendant : User
    {
        public string DescendantId { get; set; } = "";
        public string DescendantSlotId { get; set; } = "";
        public int DescendantLevel { get; set; }
        public int ModuleMaxCapacity { get; set; }
        public int ModuleCapacity { get; set; }
        public IEnumerable<Module> Modules { get; set; } = Enumerable.Empty<Module>();
    }
}