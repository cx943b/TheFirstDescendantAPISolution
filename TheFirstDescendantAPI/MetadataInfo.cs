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

        public async Task<IEnumerable<DescendantMetadata>> GetDescendants(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/descendant.json";
            return await RequestToApi<IEnumerable<DescendantMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<DescendantMetadata>();
        }
        public async Task<IEnumerable<WeaponMeatadata>> GetWeapons(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/weapon.json";
            return await RequestToApi<IEnumerable<WeaponMeatadata>>(apiClient, reqUrl) ?? Enumerable.Empty<WeaponMeatadata>();
        }
        public async Task<IEnumerable<ModuleMetadata>> GetModules(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/module.json";
            return await RequestToApi<IEnumerable<ModuleMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ModuleMetadata>();
        }
        public async Task<IEnumerable<ReactorMetadata>> GetReactors(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/reactor.json";
            return await RequestToApi<IEnumerable<ReactorMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ReactorMetadata>();
        }
        public async Task<IEnumerable<ExternalComponentMetadata>> GetExternalComponents(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        {
            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/external-component.json";
            return await RequestToApi<IEnumerable<ExternalComponentMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ExternalComponentMetadata>();
        }
    }
}
