using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFirstDescendantAPI.Schemas.Recommendation
{
    public class ModuleRecommendation
    {
        public DescendantRecommendation? Descendant { get; set; }
        public WeaponRecommendation? Weapon { get; set; }

    }
    public class DescendantRecommendation
    {
        public string DescendantId { get; set; } = "";
        public IEnumerable<ModuleRecommendationResult> Recommendations { get; set; } = Enumerable.Empty<ModuleRecommendationResult>();
    }
    public class WeaponRecommendation
    {
        public string WeaponId { get; set; } = "";
        public IEnumerable<ModuleRecommendationResult> Recommendations { get; set; } = Enumerable.Empty<ModuleRecommendationResult>();
    }
    public class ModuleRecommendationResult
    {
        public string ModuleId { get; set; } = "";
    }
}
