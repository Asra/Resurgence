using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public sealed class Stats : IEquatable<Stats>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [NotMapped] // Since this is a complex type, we'll store individual values instead
    public SortedDictionary<Stat, int> Values { get; private set; } = new SortedDictionary<Stat, int>();
    
    [NotMapped]
    public int Count => Values.Sum(pair => Math.Abs(pair.Value));

    // We'll store the stats as individual columns
    public int MinAC { get; set; }
    public int MaxAC { get; set; }
    public int MinMAC { get; set; }
    public int MaxMAC { get; set; }
    public int MinDC { get; set; }
    public int MaxDC { get; set; }
    public int MinMC { get; set; }
    public int MaxMC { get; set; }
    public int MinSC { get; set; }
    public int MaxSC { get; set; }
    public int Accuracy { get; set; }
    public int Agility { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int AttackSpeed { get; set; }
    public int Luck { get; set; }
    public int BagWeight { get; set; }
    public int HandWeight { get; set; }
    public int WearWeight { get; set; }
    public int Reflect { get; set; }
    public int Strong { get; set; }
    public int Holy { get; set; }
    public int Freezing { get; set; }
    public int PoisonAttack { get; set; }
    public int MagicResist { get; set; }
    public int PoisonResist { get; set; }
    public int HealthRecovery { get; set; }
    public int SpellRecovery { get; set; }
    public int PoisonRecovery { get; set; }
    public int CriticalRate { get; set; }
    public int CriticalDamage { get; set; }
    public int MaxACRatePercent { get; set; }
    public int MaxMACRatePercent { get; set; }
    public int MaxDCRatePercent { get; set; }
    public int MaxMCRatePercent { get; set; }
    public int MaxSCRatePercent { get; set; }
    public int AttackSpeedRatePercent { get; set; }
    public int HPRatePercent { get; set; }
    public int MPRatePercent { get; set; }
    public int HPDrainRatePercent { get; set; }
    public int ExpRatePercent { get; set; }
    public int ItemDropRatePercent { get; set; }
    public int GoldDropRatePercent { get; set; }
    public int MineRatePercent { get; set; }
    public int GemRatePercent { get; set; }
    public int FishRatePercent { get; set; }
    public int CraftRatePercent { get; set; }
    public int SkillGainMultiplier { get; set; }
    public int AttackBonus { get; set; }
    public int LoverExpRatePercent { get; set; }
    public int MentorDamageRatePercent { get; set; }
    public int MentorExpRatePercent { get; set; }
    public int DamageReductionPercent { get; set; }
    public int EnergyShieldPercent { get; set; }
    public int EnergyShieldHPGain { get; set; }
    public int ManaPenaltyPercent { get; set; }
    public int TeleportManaPenaltyPercent { get; set; }
    public int Hero { get; set; }
    public int Unknown { get; set; }

    [NotMapped]
    public int this[Stat stat]
    {
        get
        {
            return !Values.TryGetValue(stat, out int result) ? 0 : result;
        }
        set
        {
            if (value == 0)
            {
                if (Values.ContainsKey(stat))
                {
                    Values.Remove(stat);
                }
                return;
            }
            Values[stat] = value;
            
            // Update the corresponding property
            switch (stat)
            {
                case Stat.MinAC:
                    MinAC = value;
                    break;
                case Stat.MaxAC:
                    MaxAC = value;
                    break;
                case Stat.MinMAC:
                    MinMAC = value;
                    break;
                case Stat.MaxMAC:
                    MaxMAC = value;
                    break;
                case Stat.MinDC:
                    MinDC = value;
                    break;
                case Stat.MaxDC:
                    MaxDC = value;
                    break;
                case Stat.MinMC:
                    MinMC = value;
                    break;
                case Stat.MaxMC:
                    MaxMC = value;
                    break;
                case Stat.MinSC:
                    MinSC = value;
                    break;
                case Stat.MaxSC:
                    MaxSC = value;
                    break;
                case Stat.Accuracy:
                    Accuracy = value;
                    break;
                case Stat.Agility:
                    Agility = value;
                    break;
                case Stat.HP:
                    HP = value;
                    break;
                case Stat.MP:
                    MP = value;
                    break;
                case Stat.AttackSpeed:
                    AttackSpeed = value;
                    break;
                case Stat.Luck:
                    Luck = value;
                    break;
                case Stat.BagWeight:
                    BagWeight = value;
                    break;
                case Stat.HandWeight:
                    HandWeight = value;
                    break;
                case Stat.WearWeight:
                    WearWeight = value;
                    break;
                case Stat.Reflect:
                    Reflect = value;
                    break;
                case Stat.Strong:
                    Strong = value;
                    break;
                case Stat.Holy:
                    Holy = value;
                    break;
                case Stat.Freezing:
                    Freezing = value;
                    break;
                case Stat.PoisonAttack:
                    PoisonAttack = value;
                    break;
                case Stat.MagicResist:
                    MagicResist = value;
                    break;
                case Stat.PoisonResist:
                    PoisonResist = value;
                    break;
                case Stat.HealthRecovery:
                    HealthRecovery = value;
                    break;
                case Stat.SpellRecovery:
                    SpellRecovery = value;
                    break;
                case Stat.PoisonRecovery:
                    PoisonRecovery = value;
                    break;
                case Stat.CriticalRate:
                    CriticalRate = value;
                    break;
                case Stat.CriticalDamage:
                    CriticalDamage = value;
                    break;
                case Stat.MaxACRatePercent:
                    MaxACRatePercent = value;
                    break;
                case Stat.MaxMACRatePercent:
                    MaxMACRatePercent = value;
                    break;
                case Stat.MaxDCRatePercent:
                    MaxDCRatePercent = value;
                    break;
                case Stat.MaxMCRatePercent:
                    MaxMCRatePercent = value;
                    break;
                case Stat.MaxSCRatePercent:
                    MaxSCRatePercent = value;
                    break;
                case Stat.AttackSpeedRatePercent:
                    AttackSpeedRatePercent = value;
                    break;
                case Stat.HPRatePercent:
                    HPRatePercent = value;
                    break;
                case Stat.MPRatePercent:
                    MPRatePercent = value;
                    break;
                case Stat.HPDrainRatePercent:
                    HPDrainRatePercent = value;
                    break;
                case Stat.ExpRatePercent:
                    ExpRatePercent = value;
                    break;
                case Stat.ItemDropRatePercent:
                    ItemDropRatePercent = value;
                    break;
                case Stat.GoldDropRatePercent:
                    GoldDropRatePercent = value;
                    break;
                case Stat.MineRatePercent:
                    MineRatePercent = value;
                    break;
                case Stat.GemRatePercent:
                    GemRatePercent = value;
                    break;
                case Stat.FishRatePercent:
                    FishRatePercent = value;
                    break;
                case Stat.CraftRatePercent:
                    CraftRatePercent = value;
                    break;
                case Stat.SkillGainMultiplier:
                    SkillGainMultiplier = value;
                    break;
                case Stat.AttackBonus:
                    AttackBonus = value;
                    break;
                case Stat.LoverExpRatePercent:
                    LoverExpRatePercent = value;
                    break;
                case Stat.MentorDamageRatePercent:
                    MentorDamageRatePercent = value;
                    break;
                case Stat.MentorExpRatePercent:
                    MentorExpRatePercent = value;
                    break;
                case Stat.DamageReductionPercent:
                    DamageReductionPercent = value;
                    break;
                case Stat.EnergyShieldPercent:
                    EnergyShieldPercent = value;
                    break;
                case Stat.EnergyShieldHPGain:
                    EnergyShieldHPGain = value;
                    break;
                case Stat.ManaPenaltyPercent:
                    ManaPenaltyPercent = value;
                    break;
                case Stat.TeleportManaPenaltyPercent:
                    TeleportManaPenaltyPercent = value;
                    break;
                case Stat.Hero:
                    Hero = value;
                    break;
                case Stat.Unknown:
                    Unknown = value;
                    break;
            }
        }
    }

    public Stats() { }

    public Stats(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public Stats(BinaryReader reader, int version = int.MaxValue, int customVersion = int.MaxValue)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Values[(Stat)reader.ReadByte()] = reader.ReadInt32();
    }

    public void Add(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Values.Count);

        foreach (KeyValuePair<Stat, int> pair in Values)
        {
            writer.Write((byte)pair.Key);
            writer.Write(pair.Value);
        }
    }

    public void Clear()
    {
        Values.Clear();
    }

    public bool Equals(Stats other)
    {
        if (Values.Count != other.Values.Count) return false;

        foreach (KeyValuePair<Stat, int> value in Values)
            if (other[value.Key] != value.Value) return false;

        return true;
    }
}

public enum StatFormula : byte
{
    Health,
    Mana,
    Weight,
    Stat
}

public enum Stat : byte
{
    MinAC = 0,
    MaxAC = 1,
    MinMAC = 2,
    MaxMAC = 3,
    MinDC = 4,
    MaxDC = 5,
    MinMC = 6,
    MaxMC = 7,
    MinSC = 8,
    MaxSC = 9,

    Accuracy = 10,
    Agility = 11,
    HP = 12,
    MP = 13,
    AttackSpeed = 14,
    Luck = 15,
    BagWeight = 16,
    HandWeight = 17,
    WearWeight = 18,
    Reflect = 19,
    Strong = 20,
    Holy = 21,
    Freezing = 22,
    PoisonAttack = 23,

    MagicResist = 30,
    PoisonResist = 31,
    HealthRecovery = 32,
    SpellRecovery = 33,
    PoisonRecovery = 34, //TODO - Should this be in seconds or milliseconds??
    CriticalRate = 35,
    CriticalDamage = 36,

    MaxACRatePercent = 40,
    MaxMACRatePercent = 41,
    MaxDCRatePercent = 42,
    MaxMCRatePercent = 43,
    MaxSCRatePercent = 44,
    AttackSpeedRatePercent = 45,
    HPRatePercent = 46,
    MPRatePercent = 47,
    HPDrainRatePercent = 48,

    ExpRatePercent = 100,
    ItemDropRatePercent = 101,
    GoldDropRatePercent = 102,
    MineRatePercent = 103,
    GemRatePercent = 104,
    FishRatePercent = 105,
    CraftRatePercent = 106,
    SkillGainMultiplier = 107,
    AttackBonus = 108,

    LoverExpRatePercent = 120,
    MentorDamageRatePercent = 121,
    MentorExpRatePercent = 123,
    DamageReductionPercent = 124,
    EnergyShieldPercent = 125,
    EnergyShieldHPGain = 126,
    ManaPenaltyPercent = 127,
    TeleportManaPenaltyPercent = 128,
    Hero = 129,

    Unknown = 255
}