using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Schemas;

namespace TheFirstDescendantAPI.Converters
{
    public class SchemeJsonConverter<TScheme> : JsonConverter<TScheme> where TScheme : class
    {
        public override TScheme? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TScheme result = Activator.CreateInstance<TScheme>();
            PropertyInfo[] propertyInfos = typeof(TScheme).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string? propName = null;

            if(reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Invalid JSON format");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propName = reader.GetString();
                }
                else
                {
                    if (String.IsNullOrEmpty(propName))
                        throw new NullReferenceException(nameof(propName));

                    if (reader.TokenType == JsonTokenType.StartArray)
                        propName += "s";
                    else if (reader.TokenType == JsonTokenType.Null)
                        continue;

                    propName = String.Concat(propName.Split('_'));

                    PropertyInfo? propInfo = propertyInfos.FirstOrDefault(p => String.Compare(p.Name, propName, StringComparison.OrdinalIgnoreCase) == 0);
                    if (propInfo == null)
                        throw new NullReferenceException(nameof(propInfo));

                    propInfo.SetValue(result, JsonSerializer.Deserialize(ref reader, propInfo.PropertyType, options));
                }
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, TScheme value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var propInfo in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                writer.WritePropertyName(propInfo.Name);
                JsonSerializer.Serialize(writer, propInfo.GetValue(value), options);
            }

            writer.WriteEndObject();
        }
    }
}
