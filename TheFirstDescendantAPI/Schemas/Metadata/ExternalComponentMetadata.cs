using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;
using TheFirstDescendantAPI.Schemas.User;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<ExternalComponentMetadata>))]
    public class ExternalComponentMetadata : IMetadata
    {
        public string ExternalComponentId { get; set; } = "";
        public string ExternalComponentName { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string ExternalComponentEquipmentType { get; set; } = "";
        public string ExternalComponentTier { get; set; } = "";

        public IEnumerable<ExternalComponentBaseStat> BaseStats { get; set; } = Enumerable.Empty<ExternalComponentBaseStat>();
        public IEnumerable<ExternalComponentSetOptionDetail> SetOptionDetails { get; set; } = Enumerable.Empty<ExternalComponentSetOptionDetail>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<ExternalComponentBaseStat>))]
    public class ExternalComponentBaseStat : BaseStat
    {
        public int Level { get; set; }
    }
    [JsonConverter(typeof(SchemeJsonConverter<ExternalComponentSetOptionDetail>))]
    public class ExternalComponentSetOptionDetail
    {
        public string SetOption { get; set; } = "";
        public int SetCount { get; set; }
        public string SetOptionEffect { get; set; } = "";
    }
}