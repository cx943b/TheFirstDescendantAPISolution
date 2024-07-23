using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using TheFirstDescendantAPI.Responses;

namespace TheFirstDescendantAPI
{
    public abstract class ApiBase
    {
        const string BaseUrl = "https://open.api.nexon.com";
        protected readonly ILogger? _Logger;

        protected ApiBase(ILogger logger)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(logger));
            _Logger = logger;
        }

        protected async Task<TScheme?> RequestToApi<TScheme>(HttpClient apiClient, string reqUrl) where TScheme : class
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
                    return JsonSerializer.Deserialize<TScheme>(resStr);
                }
                else
                {
                    ErrorResponse? errorRes = JsonSerializer.Deserialize<ErrorResponse>(resStr);
                    if (errorRes is null)
                        throw new NullReferenceException("Failed to deserialize error response");

                    errorRes.ResponseCode = (ApiResponseCode)resMsg.StatusCode;
                    _Logger.LogError("Failed to check Id:\r\n{0}", errorRes);

                    return null;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Failed to check Id");
                return null;
            }
            finally
            {
                resMsg?.Dispose();
            }
        }
    }
}
