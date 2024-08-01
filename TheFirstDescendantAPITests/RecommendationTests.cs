using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI;
using TheFirstDescendantAPI.Schemas.Recommendation;
using Xunit.Abstractions;

namespace TheFirstDescendantAPITests
{
    public class RecommendationTests : TestBase
    {
        public RecommendationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task GetRecommendation()
        {
            RecommendationInfo recommendationInfo = new RecommendationInfo(_loggerFac.CreateLogger<RecommendationInfo>());

            string descendantId = "101000020";
            string weaponId = "211052004";
            string voidBattleId = "651000001";

            ModuleRecommendation? recommendations = await recommendationInfo.GetModules(_apiClient, descendantId, weaponId, voidBattleId);

            Assert.NotNull(recommendations);
        }
    }
}
