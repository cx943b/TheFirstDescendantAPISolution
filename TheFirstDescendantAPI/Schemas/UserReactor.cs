using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<UserReactor>))]
    public class UserReactor : User
    {
        public string ReactorId { get; set; } = "";
        public string ReactorSlotId { get; set; } = "";
        public int ReactorLevel { get; set; }
        public int ReactorEnchantLevel { get; set; }
        public IEnumerable<AdditionalStat> ReactorAdditionalStats { get; set; } = Enumerable.Empty<AdditionalStat>();
    }
}
