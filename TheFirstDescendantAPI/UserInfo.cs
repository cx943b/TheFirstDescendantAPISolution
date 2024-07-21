using Microsoft.Extensions.Logging;
using System.Net;
using System.Web;
using System.Text.Json;
using TheFirstDescendantAPI.Responses;
using TheFirstDescendantAPI.Schemas;


namespace TheFirstDescendantAPI
{
    public abstract class ApiBase
    {
        protected const string BaseUrl = "https://open.api.nexon.com";
    }

    public class UserInfo : ApiBase
    {
        readonly ILogger? _logger;

        public UserInfo(ILogger<UserInfo> logger)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(logger));
            _logger = logger;
        }

        public async Task<UserBase?> GetUserId(HttpClient apiClient, string username)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(username));

            string reqUrl = $"/tfd/v1/id?user_name={HttpUtility.UrlEncode(username)}";
            return await requestToApi<UserBase>(apiClient, reqUrl);
        }
        public async Task<UserBasic?> GetUserBasic(HttpClient apiClient, string ouId)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/basic?ouid={HttpUtility.UrlEncode(ouId)}";
            return await requestToApi<UserBasic>(apiClient, reqUrl);
        }
        public async Task<UserDescendant?> GetUserDescendant(HttpClient apiClient, string ouId)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/descendant?ouid={HttpUtility.UrlEncode(ouId)}";
            return await requestToApi<UserDescendant>(apiClient, reqUrl);
        }
        public async Task<UserWeapon?> GetUserWeapon(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/weapon?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await requestToApi<UserWeapon>(apiClient, reqUrl);
        }
        public async Task<UserReactor?> GetUserReactor(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/reactor?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await requestToApi<UserReactor>(apiClient, reqUrl);
        }        
        public async Task<UserExternalComponent?> GetUserExternalComponent(HttpClient apiClient, string ouId, LanguageCode langCode = LanguageCode.KO)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(ouId));

            string reqUrl = $"/tfd/v1/user/external-component?ouid={HttpUtility.UrlEncode(ouId)}&language_code={LanguageCodeConverter.Convert(langCode)}";
            return await requestToApi<UserExternalComponent>(apiClient, reqUrl);
        }
        private async Task<TUser?> requestToApi<TUser>(HttpClient apiClient, string reqUrl) where TUser : UserBase
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(reqUrl));

            HttpResponseMessage? resMsg = null;

            try
            {
                resMsg = await apiClient.GetAsync(BaseUrl + reqUrl);
                string resStr = await resMsg.Content.ReadAsStringAsync();

                if (resMsg.StatusCode == HttpStatusCode.OK)
                {
                    JsonSerializerOptions jsonOpts = new JsonSerializerOptions();
                    jsonOpts.PropertyNameCaseInsensitive = true;

                    return JsonSerializer.Deserialize<TUser>(resStr, jsonOpts);
                }
                else
                {
                    ErrorResponse? errorRes = JsonSerializer.Deserialize<ErrorResponse>(resStr);
                    if (errorRes is null)
                        throw new NullReferenceException("Failed to deserialize error response");

                    errorRes.ResponseCode = (ApiResponseCode)resMsg.StatusCode;
                    _logger.LogError("Failed to check Id:\r\n{0}", errorRes);

                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to check Id");
                return null;
            }
            finally
            {
                resMsg?.Dispose();
            }
        }
    }
}
