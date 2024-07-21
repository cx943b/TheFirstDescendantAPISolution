using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Xunit.Abstractions;

namespace TheFirstDescendantAPITests
{
    public abstract class TestBase
    {
        readonly IConfiguration _config;

        protected readonly ITestOutputHelper _output;
        protected readonly ILoggerFactory _loggerFac;
        protected readonly HttpClient _apiClient;
        protected readonly string _ouId;

        public TestBase(ITestOutputHelper output)
        {
            _output = output;
            _config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();

            string? apiKey = _config.GetRequiredSection("Api_Key").Value ?? throw new NullReferenceException("Failed to get Api_Key from AppSettings"); ;
            _ouId = _config.GetRequiredSection("OuId").Value ?? throw new NullReferenceException("Failed to get OuId from AppSettings");

            _apiClient = new HttpClient();
            _apiClient.DefaultRequestHeaders.Add("x-nxopen-api-key", apiKey);
            _apiClient.DefaultRequestHeaders.Add("accept", "application/json");

            _loggerFac = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.AddSimpleConsole(simpleBuilder =>
                {
                    simpleBuilder.SingleLine = false;
                    simpleBuilder.TimestampFormat = "[HH:mm:ss] ";
                    simpleBuilder.IncludeScopes = true;
                });
            });
        }
    }
}