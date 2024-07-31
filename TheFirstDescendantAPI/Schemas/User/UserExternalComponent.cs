using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.User
{
    [JsonConverter(typeof(SchemeJsonConverter<UserExternalComponent>))]
    public class UserExternalComponent : User
    {
        public IEnumerable<ExternalComponent> ExternalComponents { get; set; } = Enumerable.Empty<ExternalComponent>();
    }
}
