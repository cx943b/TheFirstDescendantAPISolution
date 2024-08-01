using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Recommendation
{
    [JsonConverter(typeof(SchemeJsonConverter<ModuleRecommendation>))]
    public class ModuleRecommendation
    {
        public DescendantRecommendation? Descendant { get; set; }
        public WeaponRecommendation? Weapon { get; set; }
    }
    [JsonConverter(typeof(SchemeJsonConverter<DescendantRecommendation>))]
    public class DescendantRecommendation
    {
        public string DescendantId { get; set; } = "";
        public IEnumerable<ModuleRecommendationResult> Recommendations { get; set; } = Enumerable.Empty<ModuleRecommendationResult>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<WeaponRecommendation>))]
    public class WeaponRecommendation
    {
        public string WeaponId { get; set; } = "";
        public IEnumerable<ModuleRecommendationResult> Recommendations { get; set; } = Enumerable.Empty<ModuleRecommendationResult>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<ModuleRecommendationResult>))]
    public class ModuleRecommendationResult
    {
        public string ModuleId { get; set; } = "";
    }
}
