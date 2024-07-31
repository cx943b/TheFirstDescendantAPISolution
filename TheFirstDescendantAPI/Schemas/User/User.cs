using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.User
{
    [JsonConverter(typeof(SchemeJsonConverter<UserBase>))]
    public class UserBase
    {
        public string OuId { get; set; } = "";
    }
    [JsonConverter(typeof(SchemeJsonConverter<User>))]
    public class User : UserBase
    {
        public string Username { get; set; } = "";
    }
}
