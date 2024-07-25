using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<ReactorMetadata>))]
    public class ReactorMetadata
    {
        public string ReactorId { get; set; } = "";
        public string ReactorName { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string ReactorTier { get; set; } = "";
        public string OptimizedConditionType { get; set; } = "";

        public IEnumerable<ReactorSkillPower> ReactorSkillPowers { get; set; } = Enumerable.Empty<ReactorSkillPower>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<ReactorSkillPower>))]
    public class ReactorSkillPower
    {
        public int Level { get; set; }
        public float SkillAtkPower { get; set; }
        public float SubSkillAtkPower { get; set; }

        public IEnumerable<ReactorSkillPowerCoefficient> SkillPowerCoefficients { get; set; } = Enumerable.Empty<ReactorSkillPowerCoefficient>();
        public IEnumerable<ReactorEnchantEffect> EnchantEffects { get; set; } = Enumerable.Empty<ReactorEnchantEffect>();
    }
    [JsonConverter(typeof(SchemeJsonConverter<ReactorSkillPowerCoefficient>))]
    public class ReactorSkillPowerCoefficient
    {
        public string CoefficientStatId { get; set; } = "";
        public float CoefficientStatValue { get; set; }
    }
    [JsonConverter(typeof(SchemeJsonConverter<ReactorEnchantEffect>))]
    public class ReactorEnchantEffect
    {
        public int EnchantLevel { get; set; }
        public string StatType { get; set; } = "";
        public float Value { get; set; }
    }
}