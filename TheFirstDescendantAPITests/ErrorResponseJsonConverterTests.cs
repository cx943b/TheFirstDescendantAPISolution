
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;
using TheFirstDescendantAPI.Responses;

namespace TheFirstDescendantAPITests
{
    public class ErrorResponseJsonConverterTests
    {
        [Fact]
        public void Deserialize()
        {
            string jsonError = "{\r\n  \"error\": {\r\n    \"name\": \"string\",\r\n    \"message\": \"string\"\r\n  }\r\n}";
            ErrorResponse? errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonError);

            Assert.NotNull(errorResponse);
        }
    }
}
