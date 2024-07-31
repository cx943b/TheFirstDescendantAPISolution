using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.User
{
    [JsonConverter(typeof(SchemeJsonConverter<UserBasic>))]
    public class UserBasic : User
    {
        public string PlatformType { get; set; } = "";
        public int MasteryRankLevel { get; set; }
        public int MasteryRankExp { get; set; }
        public string TitlePrefixId { get; set; } = "";
        public string TitleSuffixId { get; set; } = "";
        public string OsLanguage { get; set; } = "";
        public string GameLanguage { get; set; } = "";
    }
}
