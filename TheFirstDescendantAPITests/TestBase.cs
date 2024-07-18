using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TheFirstDescendantAPITests
{
    public abstract class TestBase
    {
        readonly IConfiguration _config;

        protected readonly ILoggerFactory _loggerFac;
        protected readonly HttpClient _apiClient;

        public TestBase()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();

            string? apiKey = _config.GetRequiredSection("Api_Key").Value;
            if (apiKey is null)
                throw new NullReferenceException("Failed to get Api_Key from AppSettings");

            _apiClient = new HttpClient();
            _apiClient.DefaultRequestHeaders.Add("x-nxopen-api-key", apiKey);
            _apiClient.DefaultRequestHeaders.Add("accept", "application/json");

            _loggerFac = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog();
                builder.AddConsole();
            });
        }
    }
}