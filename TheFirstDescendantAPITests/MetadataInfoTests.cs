using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI;
using TheFirstDescendantAPI.Schemas.Metadata;
using Xunit.Abstractions;

namespace TheFirstDescendantAPITests
{
    public class MetadataInfoTests : TestBase
    {
        public MetadataInfoTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task GetDescendant()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<DescendantMetadata>? descendant = await metadataInfo.GetMetadata<DescendantMetadata>(_apiClient);

            Assert.NotNull(descendant);
        }

        [Fact]
        public async Task GetWeapons()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<WeaponMetadata>? weapons = await metadataInfo.GetMetadata<WeaponMetadata>(_apiClient);

            Assert.NotNull(weapons);
        }
        [Fact]
        public async Task GetModules()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ModuleMetadata>? modules = await metadataInfo.GetMetadata<ModuleMetadata>(_apiClient);

            Assert.NotNull(modules);
        }
        [Fact]
        public async Task GetReactors()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ReactorMetadata>? reactors = await metadataInfo.GetMetadata<ReactorMetadata>(_apiClient);

            Assert.NotNull(reactors);
        }
        [Fact]
        public async Task GetExternalComponents()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ExternalComponentMetadata>? externalComponents = await metadataInfo.GetMetadata<ExternalComponentMetadata>(_apiClient);

            Assert.NotNull(externalComponents);
        }
        [Fact]
        public async Task GetRewards()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<RewardMetadata>? rewards = await metadataInfo.GetMetadata<RewardMetadata>(_apiClient);

            Assert.NotNull(rewards);
        }
        [Fact]
        public async Task GetStats()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<StatMetadata>? stats = await metadataInfo.GetMetadata<StatMetadata>(_apiClient);

            Assert.NotNull(stats);
        }
        [Fact]
        public async Task GetTitles()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<TitleMetadata>? titles = await metadataInfo.GetMetadata<TitleMetadata>(_apiClient);

            Assert.NotNull(titles);
        }
        [Fact]
        public async Task GetVoidBattles()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<VoidBattleMetadata>? voidBattles = await metadataInfo.GetMetadata<VoidBattleMetadata>(_apiClient);

            Assert.NotNull(voidBattles);
        }   
    }
}
