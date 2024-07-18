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

        public async Task<User?> CheckUser(HttpClient apiClient, string username)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(apiClient));
            ArgumentException.ThrowIfNullOrEmpty(nameof(username));

            string reqUrl = BaseUrl + $"/tfd/v1/id?user_name={HttpUtility.UrlEncode(username)}";
            HttpResponseMessage? resMsg = null;
            
            try
            {
                resMsg = await apiClient.GetAsync(reqUrl);
                string resStr = await resMsg.Content.ReadAsStringAsync();

                if (resMsg.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<User>(resStr);
                }
                else
                {
                    JsonSerializerOptions jsonOpts = new JsonSerializerOptions();
                    jsonOpts.PropertyNameCaseInsensitive = true;

                    ErrorResponse? errorRes = JsonSerializer.Deserialize<ErrorResponse>(resStr, jsonOpts);
                    if(errorRes is null)
                        throw new NullReferenceException("Failed to deserialize error response");

                    errorRes.ResponseCode = (ApiResponseCode)resMsg.StatusCode;
                    _logger.LogError("Failed to check Id:\r\n{0}", errorRes);

                    return null;
                }
            }
            catch(Exception ex)
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
