using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<StatMetadata>))]
    public class StatMetadata : IMetadata
    {
        public string StatId { get; set; } = "";
        public string StatName { get; set; } = "";
    }
}
