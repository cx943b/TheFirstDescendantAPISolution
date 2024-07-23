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
        public async Task CheckDescendant()
        {
            MetadataInfo metadataInfo = new MetadataInfo(_loggerFac.CreateLogger<MetadataInfo>());
            IEnumerable<Descendant> descendant = await metadataInfo.GetDescendants(_apiClient);

            Assert.NotNull(descendant);
        }
    }
}
