﻿using System.Text.Json.Serialization;
using TheFirstDescendantAPI.Converters;

namespace TheFirstDescendantAPI.Schemas
{
    [JsonConverter(typeof(SchemeJsonConverter<WeaponMeatadata>))]
    public class WeaponMeatadata
    {
        public string WeaponId { get; set; } = "";
        public string WeaponName { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string WeaponType { get; set; } = "";
        public string WeaponTier { get; set; } = "";
        public string WeaponRoundsType { get; set; } = "";
        public string WeaponPerkAbilityName { get; set; } = "";
        public string WeaponPerkAbilityDescription { get; set; } = "";
        public string WeaponPerkAbilityImageUrl { get; set; } = "";

        public IEnumerable<WeaponBaseStat> BaseStats { get; set; } = Enumerable.Empty<WeaponBaseStat>();
        public IEnumerable<FirearmAtk> FirearmAtks { get; set; } = Enumerable.Empty<FirearmAtk>();
    }

    [JsonConverter(typeof(SchemeJsonConverter<WeaponBaseStat>))]
    public class WeaponBaseStat
    {
        public string StatId { get; set; } = "";
        public float StatValue { get; set; }
    }
    [JsonConverter(typeof(SchemeJsonConverter<FirearmAtk>))]
    public class FirearmAtk
    {
        public int Level { get; set; }
        public IEnumerable<Firearm> Firearms { get; set; } = Enumerable.Empty<Firearm>();
    }

    [JsonConverter(typeof(SchemeJsonConverter<Firearm>))]
    public class Firearm
    {
        public string FirearmAtkType { get; set; } = "";
        public float FirearmAtkValue { get; set; }
    }
}