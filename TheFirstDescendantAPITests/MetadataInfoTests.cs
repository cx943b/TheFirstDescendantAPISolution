using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI;
using TheFirstDescendantAPI.Schemas;
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
            IEnumerable<DescendantMetadata> descendant = await metadataInfo.GetDescendants(_apiClient);

            Assert.NotNull(descendant);
        }

        [Fact]
        public async Task GetWeapons()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<WeaponMeatadata> weapons = await metadataInfo.GetWeapons(_apiClient);

            Assert.NotNull(weapons);
        }
        [Fact]
        public async Task GetModules()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ModuleMetadata> modules = await metadataInfo.GetModules(_apiClient);

            Assert.NotNull(modules);
        }
        [Fact]
        public async Task GetReactors()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ReactorMetadata> reactors = await metadataInfo.GetReactors(_apiClient);

            Assert.NotNull(reactors);
        }
        [Fact]
        public async Task GetExternalComponents()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<ExternalComponentMetadata> externalComponents = await metadataInfo.GetExternalComponents(_apiClient);

            Assert.NotNull(externalComponents);
        }
    }
}
