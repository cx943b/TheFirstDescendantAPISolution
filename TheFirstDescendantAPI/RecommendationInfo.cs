using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Schemas.Recommendation;

namespace TheFirstDescendantAPI
{
    public class RecommendationInfo : ApiBase
    {
        public RecommendationInfo(ILogger<RecommendationInfo> logger) : base(logger)
        {
        }

        public async Task<ModuleRecommendation?> GetModules(HttpClient apiClient, string descendantId, string weaponId, string voidBattleId, RecommendationPeriod period = RecommendationPeriod.All)
        {
            ArgumentNullException.ThrowIfNull(apiClient, nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(descendantId, nameof(descendantId));
            ArgumentException.ThrowIfNullOrEmpty(weaponId, nameof(weaponId));
            ArgumentException.ThrowIfNullOrEmpty(voidBattleId, nameof(voidBattleId));

            string reqUrl = $"/tfd/v1/recommendation/module?descendant_id={descendantId}&weapon_id={weaponId}&void_battle_id={voidBattleId}&period={(int)period}";
            return await RequestToApi<ModuleRecommendation>(apiClient, reqUrl);
        }
    }
}
