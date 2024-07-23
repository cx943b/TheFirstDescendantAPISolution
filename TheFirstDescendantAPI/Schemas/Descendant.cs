using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<Descendant>))]
    public class Descendant
    {
        public string DescendantId { get; set; } = "";
        public string DescendantName { get; set; } = "";
        public string DescendantImageUrl { get; set; } = "";

        public IEnumerable<DescendantStat> DescendantStats { get; set; } = Enumerable.Empty<DescendantStat>();
        public IEnumerable<DescendantSkill> DescendantSkills { get; set; } = Enumerable.Empty<DescendantSkill>();
    }

    [JsonConverter(typeof(SchemeJsonConverter<DescendantStat>))]
    public class DescendantStat
    {
        public int Level { get; set; }
        public IEnumerable<DescendantStatDetail> DescendantStatDetails { get; set; } = Enumerable.Empty<DescendantStatDetail>();

    }

    [JsonConverter(typeof(SchemeJsonConverter<DescendantStatDetail>))]
    public class DescendantStatDetail
    {
        public string StatType { get; set; } = "";
        public int StatValue { get; set; }
    }

    public class DescendantSkill
    {
        public string SkillType { get; set; } = "";
        public string SkillName { get; set; } = "";
        public string ElementType { get; set; } = "";
        public string ArcheType { get; set; } = "";
        public string SkillImageUrl { get; set; } = "";
        public string SkillDescription { get; set; } = "";
    }
}