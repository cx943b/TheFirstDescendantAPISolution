using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;
using TheFirstDescendantAPI.Schemas.Metadata;

namespace TheFirstDescendantAPI
{
    public class MetadataInfo : ApiBase
    {
        public MetadataInfo(ILogger<MetadataInfo> logger) : base(logger)
        {
        }

        public async Task<IEnumerable<TMetadata>> GetMetadata<TMetadata>(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO) where TMetadata : IMetadata
        {
            ArgumentNullException.ThrowIfNull(apiClient, nameof(apiClient));

            string endpoint = typeof(TMetadata) switch
            {
                Type t when t == typeof(DescendantMetadata) => "descendant",
                Type t when t == typeof(WeaponMetadata) => "weapon",
                Type t when t == typeof(ModuleMetadata) => "module",
                Type t when t == typeof(ReactorMetadata) => "reactor",
                Type t when t == typeof(ExternalComponentMetadata) => "external-component",
                Type t when t == typeof(RewardMetadata) => "reward",
                Type t when t == typeof(StatMetadata) => "stat",
                Type t when t == typeof(TitleMetadata) => "title",
                Type t when t == typeof(VoidBattleMetadata) => "void-battle",
                _ => throw new NotSupportedException("Unsupported metadata type")
            };

            string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/{endpoint}.json";
            return await RequestToApi<IEnumerable<TMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<TMetadata>();
        }

        //public async Task<IEnumerable<DescendantMetadata>> GetDescendants(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/descendant.json";
        //    return await RequestToApi<IEnumerable<DescendantMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<DescendantMetadata>();
        //}
        //public async Task<IEnumerable<WeaponMetadata>> GetWeapons(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/weapon.json";
        //    return await RequestToApi<IEnumerable<WeaponMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<WeaponMetadata>();
        //}
        //public async Task<IEnumerable<ModuleMetadata>> GetModules(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/module.json";
        //    return await RequestToApi<IEnumerable<ModuleMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ModuleMetadata>();
        //}
        //public async Task<IEnumerable<ReactorMetadata>> GetReactors(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/reactor.json";
        //    return await RequestToApi<IEnumerable<ReactorMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ReactorMetadata>();
        //}
        //public async Task<IEnumerable<ExternalComponentMetadata>> GetExternalComponents(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/external-component.json";
        //    return await RequestToApi<IEnumerable<ExternalComponentMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<ExternalComponentMetadata>();
        //}
        //public async Task<IEnumerable<RewardMetadata>> GetRewards(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/reward.json";
        //    return await RequestToApi<IEnumerable<RewardMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<RewardMetadata>();
        //}
        //public async Task<IEnumerable<StatMetadata>> GetStats(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/stat.json";
        //    return await RequestToApi<IEnumerable<StatMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<StatMetadata>();
        //}
        //public async Task<IEnumerable<TitleMetadata>> GetTitles(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/title.json";
        //    return await RequestToApi<IEnumerable<TitleMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<TitleMetadata>();
        //}
        //public async Task<IEnumerable<VoidBattleMetadata>> GetVoidBattles(HttpClient apiClient, LanguageCode langCode = LanguageCode.KO)
        //{
        //    string reqUrl = $"/static/tfd/meta/{LanguageCodeConverter.Convert(langCode)}/void-battle.json";
        //    return await RequestToApi<IEnumerable<VoidBattleMetadata>>(apiClient, reqUrl) ?? Enumerable.Empty<VoidBattleMetadata>();
        //}
    }
}
