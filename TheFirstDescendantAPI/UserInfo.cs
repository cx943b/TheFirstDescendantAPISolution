using Microsoft.Extensions.Logging;
using System.Web;
using TheFirstDescendantAPI.Schemas;

namespace TheFirstDescendantAPI
{
    public class UserInfo : ApiBase
    {
        public UserInfo(ILogger<UserInfo> logger) : base(logger)
        {
        }

        public async Task<UserBase?> GetUserId(HttpClient apiClient, string username)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(username));

            string reqUrl = $"/tfd/v1/id?user_name={HttpUtility.UrlEncode(username)}";
            return await RequestToApi<UserBase>(apiClient, reqUrl);
        }
        public async Task<UserBasic?> GetUserBasic(HttpClient apiClient, string ouId)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/basic?ouid={HttpUtility.UrlEncode(ouId)}";
            return await RequestToApi<UserBasic>(apiClient, reqUrl);
        }
        public async Task<UserDescendant?> GetUserDescendant(HttpClient apiClient, string ouId)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/descendant?ouid={HttpUtility.UrlEncode(ouId)}";
            return await RequestToApi<UserDescendant>(apiClient, reqUrl);
        }
        public async Task<UserWeapon?> GetUserWeapon(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/weapon?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await RequestToApi<UserWeapon>(apiClient, reqUrl);
        }
        public async Task<UserReactor?> GetUserReactor(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/reactor?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await RequestToApi<UserReactor>(apiClient, reqUrl);
        }        
        public async Task<UserExternalComponent?> GetUserExternalComponent(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/external-component?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await RequestToApi<UserExternalComponent>(apiClient, reqUrl);
        }
        
    }
}
