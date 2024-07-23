using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Schemas;

namespace TheFirstDescendantAPI
{
    public class MetadataInfo : ApiBase
    {
        public MetadataInfo(ILogger<MetadataInfo> logger) : base(logger)
        {
        }

        public async Task<IEnumerable<Descendant>> GetDescendants(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/descendant.json";
            return await RequestToApi<IEnumerable<Descendant>>(apiClient, reqUrl) ?? Enumerable.Empty<Descendant>();
        }
    }
}
