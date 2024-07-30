using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas.Metadata
{
    [JsonConverter(typeof(SchemeJsonConverter<RewardMetadata>))]
    public class RewardMetadata : IMetadata
    {
        public string MapId { get; set; } = "";
        public string MapName { get; set; } = "";

        public IEnumerable<BattleZone> BattleZones { get; set; } = Enumerable.Empty<BattleZone>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<BattleZone>))]
    public class BattleZone
    {
        public string BattleZoneId { get; set; } = "";
        public string BattleZoneName { get; set; } = "";

        public IEnumerable<BattleZoneReward> Rewards { get; set; } = Enumerable.Empty<BattleZoneReward>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<BattleZoneReward>))]
    public class BattleZoneReward
    {
        public int Rotation { get; set; }
        public string RewardType { get; set; } = "";
        public string ReactorElementType { get; set; } = "";
        public string WeaponRoundsType { get; set; } = "";
        public string ArcheType { get; set; } = "";
    }
}