using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Responses;

namespace TheFirstDescendantAPI.Converters
{
    public class ErrorResponseJsonConverter : JsonConverter<ErrorResponse>
    {
        public override ErrorResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? propName = null;
            ErrorResponse errorResponse = new ErrorResponse();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if(reader.TokenType == JsonTokenType.PropertyName)
                {
                    propName = reader.GetString();

                    if(String.IsNullOrEmpty(propName))
                        throw new NullReferenceException(nameof(propName));
                }
                else
                {
                    // propName not null here
                    propName = Char.ToUpper(propName![0]) + propName.Substring(1);
                    switch (propName)
                    {
                        case nameof(ErrorResponse.Name): errorResponse.Name = JsonSerializer.Deserialize<string>(ref reader, options)!; break;
                        case nameof(errorResponse.Message): errorResponse.Message = JsonSerializer.Deserialize<string>(ref reader, options)!; break;
                    }
                }
            }

            // Need read one more, WHY?
            reader.Read();

            return errorResponse;
        }

        // Not Use but wrote code
        public override void Write(Utf8JsonWriter writer, ErrorResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach(var propInfo in value.GetType().GetProperties(System.Reflection.BindingFlags.Public))
            {
                writer.WritePropertyName(propInfo.Name);
                JsonSerializer.Serialize(writer, propInfo.GetValue(value), options);
            }

            writer.WriteEndObject();
        }
    }
}
