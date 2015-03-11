using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAToolBox.Utility
{
    public class VendorInfo
    {
        public short Slot { get; set; }
        public int Item { get; set; }
        public byte MaxCount { get; set; }
        public long IncrTime { get; set; }
        public int ExtendedCost { get; set; }
        public int ReqCityRank { get; set; }
        public short? VerifiedBuild { get; set; }
    }

    public class ItemInfo
    {
        public int Entry { get; set; }
        public int Class { get; set; }
        public int SubClass { get; set; }
        public string Name { get; set; }
        public int Quality { get; set; }
    }

    public class CreatureInfo
    {
        public int Entry { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int Rank { get; set; }
    }

    public class ItemDBC
    {
        public ItemDBC() { }
        public ItemDBC(int entry, int _class, int subclass, int soundoverridesubclass, int material, int displayid, int inventorytype, int sheath)
        {
            Entry = entry;
            Class = _class;
            SubClass = subclass;
            SoundOverrideSubClass = soundoverridesubclass;
            Material = material;
            DisplayID = displayid;
            InventoryType = inventorytype;
            Sheath = sheath;
        }
        public int Entry { get; set; }
        public int Class { get; set; }
        public int SubClass { get; set; }
        public int SoundOverrideSubClass { get; set; }
        public int Material { get; set; }
        public int DisplayID { get; set; }
        public int InventoryType { get; set; }
        public int Sheath { get; set; }
    }

    public class CreatureTemplate
    {
        public CreatureTemplate()
        {
            Entry = new int[4];
            KillCredit = new long[2];
            Resistance = new short[6];
            Spell = new int[8];
            QuestItem = new long[6];
            Model = new int[4];
        }

        public int[] Entry { get; set; }
        public long[] KillCredit { get; set; }
        public int[] Model { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string IconName { get; set; }
        public int GossipMenuID { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }
        public short Expansion { get; set; }
        public int Faction { get; set; }
        public long NpcFlags { get; set; }
        public float SpeedWalk { get; set; }
        public float SpeedRun { get; set; }
        public float Scale { get; set; }
        public byte Rank { get; set; }
        public sbyte DamageSchool { get; set; }
        public long BaseAttackTime { get; set; }
        public long RangedAttackTime { get; set; }
        public float BaseVariance { get; set; }
        public float RangedVariance { get; set; }
        public byte UnitClass { get; set; }
        public long UnitFlags { get; set; }
        public long UnitFlags2 { get; set; }
        public long DynamicFlags { get; set; }
        public sbyte Family { get; set; }
        public sbyte TrainerType { get; set; }
        public int TrainerSpell { get; set; }
        public byte TrainerClass { get; set; }
        public byte TrainerRace { get; set; }
        public byte Type { get; set; }
        public long TypeFlags { get; set; }
        public int LootID { get; set; }
        public int PickpocketLoot { get; set; }
        public int SkinLoot { get; set; }
        public short[] Resistance { get; set; }
        public int[] Spell { get; set; }
        public int PetSpellDataID { get; set; }
        public int VehicleID { get; set; }
        public int MinMoneyLoot { get; set; }
        public int MaxMoneyLoot { get; set; }
        public string AIName { get; set; }
        public byte MovementType { get; set; }
        public byte InhabitType { get; set; }
        public float HoverHeight { get; set; }
        public float HealthModifier { get; set; }
        public float ManaModifier { get; set; }
        public float ArmorModifier { get; set; }
        public float DamageModifier { get; set; }
        public float ExperienceModifier { get; set; }
        public bool IsRacialLeader { get; set; }
        public long[] QuestItem { get; set; }
        public long MovementID { get; set; }
        public bool RegenerateHealth { get; set; }
        public long MechanicImmuneMask { get; set; }
        public long ExtraFlags { get; set; }
        public string ScriptName { get; set; }
        public short? VerifiedBuild { get; set; }
        public int WarSchool { get; set; }
    }

    public class Creature
    {
        public long Guid { get; set; }
        public int Map { get; set; }
        public int Zone { get; set; }
        public int Area { get; set; }
        public byte SpawnMask { get; set; }
        public long PhaseMask { get; set; }
        public int Model { get; set; }
        public sbyte EquipmentID { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public long SpawnTime { get; set; }
        public float SpawnDistance { get; set; }
        public int CurrentWaypoint { get; set; }
        public long CurrentHealth { get; set; }
        public long CurrentMana { get; set; }
        public byte MovementType { get; set; }
        public long NpcFlags { get; set; }
        public long UnitFlags { get; set; }
        public long DynamicFlags { get; set; }
        public short? VerifiedBuild { get; set; }
    }

    public class ItemTemplate
    {
        public ItemTemplate()
        {
            StatType = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            StatValue = new short[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            DamageMin = new float[2] { 0, 0 };
            DamageMax = new float[2] { 0, 0 };
            DamageSchool = new int[2] { 0, 0 };
            Spell = new int[5] { 0, 0, 0, 0, 0 };
            SpellTrigger = new int[5] { 0, 0, 0, 0, 0 };
            SpellCharges = new short[5] { 0, 0, 0, 0, 0 };
            SpellPPM = new float[5] { 0, 0, 0, 0, 0 };
            SpellCooldown = new int[5] { 0, 0, 0, 0, 0 };
            SpellCategory = new int[5] { 0, 0, 0, 0, 0 };
            SpellCategoryCooldown = new int[5] { 0, 0, 0, 0, 0 };
            SocketColor = new int[3] { 0, 0, 0 };
            SocketContent = new int[3] { 0, 0, 0 };
        }

        public int Entry { get; set; }
        public int Class { get; set; }
        public int Subclass { get; set; }
        public int SoundOverrideSubclass { get; set; }
        public string Name { get; set; }
        public int DisplayID { get; set; }
        public int Quality { get; set; }
        public long Flags { get; set; }
        public long FlagsExtra { get; set; }
        public byte BuyCount { get; set; }
        public long BuyPrice { get; set; }
        public long SellPrice { get; set; }
        public int InventoryType { get; set; }
        public int AllowableClass { get; set; }
        public int AllowableRace { get; set; }
        public int ItemLevel { get; set; }
        public byte RequiredLevel { get; set; }
        public int RequiredSkill { get; set; }
        public int RequiredSkillRank { get; set; }
        public int RequiredSpell { get; set; }
        public int RequiredHonorRank { get; set; }
        public int RequiredCityRank { get; set; }
        public int RequiredReputationFaction { get; set; }
        public int RequiredReputationRank { get; set; }
        public int MaxCount { get; set; }
        public int Stackable { get; set; }
        public byte ContainerSlot { get; set; }
        public byte StatsCount { get; set; }
        public int[] StatType { get; set; }
        public short[] StatValue { get; set; }
        public short ScalingStatDistribution { get; set; }
        public long ScalingStatValue { get; set; }
        public float[] DamageMin { get; set; }
        public float[] DamageMax { get; set; }
        public int[] DamageSchool { get; set; }
        public int Armor { get; set; }
        public byte HolyResistance { get; set; }
        public byte FireResistance { get; set; }
        public byte NatureResistance { get; set; }
        public byte FrostResistance { get; set; }
        public byte ShadowResistance { get; set; }
        public byte ArcaneResistance { get; set; }
        public int Speed { get; set; }
        public int AmmoType { get; set; }
        public float RangedModRange { get; set; }
        public int[] Spell { get; set; }
        public int[] SpellTrigger { get; set; }
        public short[] SpellCharges { get; set; }
        public float[] SpellPPM { get; set; }
        public int[] SpellCooldown { get; set; }
        public int[] SpellCategory { get; set; }
        public int[] SpellCategoryCooldown { get; set; }
        public int Bonding { get; set; }
        public string Description { get; set; }
        public int PageText { get; set; }
        public byte LanguageID { get; set; }
        public int PageMaterial { get; set; }
        public int StartQuest { get; set; }
        public int LockID { get; set; }
        public int Material { get; set; }
        public int Sheath { get; set; }
        public int RandomProperty { get; set; }
        public int RandomSuffix { get; set; }
        public int Block { get; set; }
        public int ItemSet { get; set; }
        public int MaxDurability { get; set; }
        public int Area { get; set; }
        public short Map { get; set; }
        public int BagFamily { get; set; }
        public int TotemCategory { get; set; }
        public int[] SocketColor { get; set; }
        public int[] SocketContent { get; set; }
        public int SocketBonus { get; set; }
        public int GemProperty { get; set; }
        public short RequiredDisenchantSkill { get; set; }
        public float ArmorDamageModifier { get; set; }
        public long Duration { get; set; }
        public short ItemLimitCategory { get; set; }
        public long HolidayID { get; set; }
        public string ScriptName { get; set; }
        public int DisenchantID { get; set; }
        public int FoodType { get; set; }
        public long MinMoneyLoot { get; set; }
        public long MaxMoneyLoot { get; set; }
        public long CustomFlags { get; set; }
        public short? VerifiedBuild { get; set; }
    }

    public class Loot
    {
        public int Entry { get; set; }
        public int Item { get; set; }
        public int Reference { get; set; }
        public float Chance { get; set; }
        public bool QuestRequired { get; set; }
        public int LootMode { get; set; }
        public byte GroupID { get; set; }
        public byte MinCount { get; set; }
        public byte MaxCount { get; set; }
        public bool IsRef { get; set; }
        public string Comment { get; set; }
    }

    public class GossipMenu
    {
        public int Menu { get; set; }
        public int NpcText { get; set; }
    }

    public class NpcText
    {
        public int Entry { get; set; }
        public int Text { get; set; }
    }

    public class GossipMenuItem
    {
        public int Menu { get; set; }
        public int ID { get; set; }
        public int Icon { get; set; }
        public int GossipTextID { get; set; }
        public byte OptionID { get; set; }
        public long NpcFlags { get; set; }
        public int ToMenu { get; set; }
        public int POI { get; set; }
        public bool BoxCoded { get; set; }
        public int BoxMoney { get; set; }
        public int BoxTextID { get; set; }
        public bool SingleTimeCheck { get; set; }
    }

    public class BroadCastText
    {
        public int ID { get; set; }
        public int Language { get; set; }
        public string MaleText { get; set; }
        public string FemaleText { get; set; }
        public int Emote0 { get; set; }
        public int Emote1 { get; set; }
        public int Emote2 { get; set; }
        public int EmoteDelay0 { get; set; }
        public int EmoteDelay1 { get; set; }
        public int EmoteDelay2 { get; set; }
        public int SoundID { get; set; }
        public int VerifiedBuild { get; set; }
    }

    public class SmartScript
    {
        public SmartScript()
        {
            EventParam = new long[4];
            ActionParam = new long[6];
            TargetParam = new long[3];
            TargetPosition = new float[4];
        }

        public int Entry { get; set; }
        public byte SourceType { get; set; }
        public int ID { get; set; }
        public int Link { get; set; }
        public byte Event { get; set; }
        public byte EventPhase { get; set; }
        public byte EventFlags { get; set; }
        public byte Chance { get; set; }
        public long[] EventParam { get; set; }
        public byte Action { get; set; }
        public long[] ActionParam { get; set; }
        public byte Target { get; set; }
        public long[] TargetParam { get; set; }
        public float[] TargetPosition { get; set; }
        public string Comment { get; set; }
    }

    public class NpcTrainerInfo
    {
        public int Entry { get; set; }
        public int Spell { get; set; }
        public long Cost { get; set; }
        public int Skill { get; set; }
        public int SkillValue { get; set; }
        public byte Level { get; set; }
        public int CityRank { get; set; }
    }

    public class ItemEnchantmentTemplate
    {
        public int ID { get; set; }
        public int Enchant { get; set; }
        public float Chance { get; set; }
    }

    public class SpellTemplate
    {
        public SpellTemplate()
        {
            Attributes = new uint[8];
            Totem = new int[2];
            Reagent = new int[8];
            ReagentCount = new uint[8];
            Effect = new int[3];
            EffectDieSides = new int[3];
            EffectBasePoints = new int[3];
            EffectPointsPerLevel = new float[3];
            EffectMechanic = new uint[3];
            EffectTargetA = new int[3];
            EffectTargetB = new int[3];
            EffectRadius = new int[3];
            EffectApplyAura = new int[3];
            EffectAmplitude = new uint[3];
            EffectMultipleValue = new float[3];
            EffectChainTargets = new uint[3];
            EffectItemType = new uint[3];
            EffectMisc = new int[3];
            EffectMiscB = new int[3];
            EffectTriggerSpell = new uint[3];
            EffectPointsPerComboPoint = new float[3];
            EffectSpellMaskA = new uint[3];
            EffectSpellMaskB = new uint[3];
            EffectSpellMaskC = new uint[3];
            EffectDamageMultiplier = new float[3];
            EffectBonusMultiplier = new float[3];
            TotemCategory = new int[2];
            Stance = new uint[2];
            StanceNot = new uint[2];
            Visual = new uint[2];
        }

        public uint ID { get; set; }
        public uint Category { get; set; }
        public int Dispel { get; set; }
        public int Mechanic { get; set; }
        public uint[] Attributes { get; set; }
        public uint[] Stance { get; set; }
        public uint[] StanceNot { get; set; }
        public uint Targets { get; set; }
        public uint TargetCreatureType { get; set; }
        public uint RequiredSpellFocus { get; set; }
        public bool RequireFacingTarget { get; set; }
        public int CasterAuraState { get; set; }
        public int TargetAuraState { get; set; }
        public int ExcludeCasterAuraState { get; set; }
        public int ExcludeTargetAuraState { get; set; }
        public uint CasterAuraSpell { get; set; }
        public uint TargetAuraSpell { get; set; }
        public uint ExcludeCasterAuraSpell { get; set; }
        public uint ExcludeTargetAuraSpell { get; set; }
        public int CastingTime { get; set; }
        public uint Cooldown { get; set; }
        public uint CategoryCooldown { get; set; }
        public uint InterruptFlags { get; set; }
        public uint AuraInterruptFlags { get; set; }
        public uint ChannelInterruptFlags { get; set; }
        public uint Proc { get; set; }
        public uint ProcChance { get; set; }
        public uint ProcCharges { get; set; }
        public uint MaxLevel { get; set; }
        public uint BaseLevel { get; set; }
        public uint Level { get; set; }
        public int Duration { get; set; }
        public int PowerType { get; set; }
        public uint PowerCost { get; set; }
        public uint PowerCostPerLevel { get; set; }
        public uint PowerCostPerSecond { get; set; }
        public uint PowerCostPerSecondPerLevel { get; set; }
        public int Range { get; set; }
        public float Speed { get; set; }
        public uint ModalNextSpell { get; set; }
        public uint StackAmount { get; set; }
        public int[] Totem { get; set; }
        public int[] Reagent { get; set; }
        public uint[] ReagentCount { get; set; }
        public int EquippedItemClass { get; set; }
        public int EquippedItemSubClassMask { get; set; }
        public int EquippedItemInventoryTypeMask { get; set; }
        public int[] Effect { get; set; }
        public int[] EffectDieSides { get; set; }
        public float[] EffectPointsPerLevel { get; set; }
        public int[] EffectBasePoints { get; set; }
        public uint[] EffectMechanic { get; set; }
        public int[] EffectTargetA { get; set; }
        public int[] EffectTargetB { get; set; }
        public int[] EffectRadius { get; set; }
        public int[] EffectApplyAura { get; set; }
        public uint[] EffectAmplitude { get; set; }
        public float[] EffectMultipleValue { get; set; }
        public uint[] EffectChainTargets { get; set; }
        public uint[] EffectItemType { get; set; }
        public int[] EffectMisc { get; set; }
        public int[] EffectMiscB { get; set; }
        public uint[] EffectTriggerSpell { get; set; }
        public float[] EffectPointsPerComboPoint { get; set; }
        public uint[] EffectSpellMaskA { get; set; }
        public uint[] EffectSpellMaskB { get; set; }
        public uint[] EffectSpellMaskC { get; set; }
        public uint[] Visual { get; set; }
        public uint Icon { get; set; }
        public uint ActiveIcon { get; set; }
        public uint Priority { get; set; }
        public string Name { get; set; }
        public uint NameFlags { get; set; }
        public string Rank { get; set; }
        public uint RankFlags { get; set; }
        public string Description { get; set; }
        public uint DescriptionFlags { get; set; }
        public string ToolTip { get; set; }
        public uint ToolTipFlags { get; set; }
        public uint PowerCostPercent { get; set; }
        public uint GlobalCategory { get; set; }
        public uint GlobalCooldown { get; set; }
        public uint MaxTargetLevel { get; set; }
        public int Family { get; set; }
        public uint FamilyMaskA { get; set; }
        public uint FamilyMaskB { get; set; }
        public uint FamilyMaskC { get; set; }
        public uint MaxAffectTargets { get; set; }
        public int DamageClass { get; set; }
        public uint PreventionType { get; set; }
        public uint StanceBarOrder { get; set; }
        public float[] EffectDamageMultiplier { get; set; }
        public uint MinFaction { get; set; }
        public uint MinReputation { get; set; }
        public uint RequiredAuraVision { get; set; }
        public int[] TotemCategory { get; set; }
        public int AreaGroup { get; set; }
        public uint SchoolMask { get; set; }
        public uint RuneCost { get; set; }
        public uint Missile { get; set; }
        public uint PowerDisplay { get; set; }
        public float[] EffectBonusMultiplier { get; set; }
        public uint DescriptionVariable { get; set; }
        public uint Difficulty { get; set; }
    }

    public class SkillLineAbility
    {
        public int ID { get; set; }
        public int Skill { get; set; }
        public int Spell { get; set; }
        public int Race { get; set; }
        public int Class { get; set; }
        public int RequiredSkillValue { get; set; }
        public int SupercededBySpell { get; set; }
        public int AccquiredMethod { get; set; }
        public int SkillLineRankHigh { get; set; }
        public int SkillLineRankLow { get; set; }
    }

    public class SkillLine
    {
        public int ID { get; set; }
        public int Category { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Icon { get; set; }
        public string Verb { get; set; }
        public int CanLink { get; set; }
    }

    public class ItemDisplayInfo
    {
        public int ID { get; set; }
        public string LeftModel { get; set; }
        public string RightModel { get; set; }
        public string LeftModelTexture { get; set; }
        public string RightModelTexture { get; set; }
        public string Icon1 { get; set; }
        public string Icon2 { get; set; }
        public int GeosetGroup1 { get; set; }
        public int GeosetGroup2 { get; set; }
        public int GeosetGroup3 { get; set; }
        public int Flags { get; set; }
        public int SpellVisualID { get; set; }
        public int GroupSoundIndex { get; set; }
        public int HelmetGeosetMale { get; set; }
        public int HelmetGeosetFemale { get; set; }
        public string UpperArmTexture { get; set; }
        public string LowerArmTexture { get; set; }
        public string HandsTexture { get; set; }
        public string UpperTorsoTexture { get; set; }
        public string LowerTorsoTexture { get; set; }
        public string UpperLegTexture { get; set; }
        public string LowerLegTexture { get; set; }
        public string FootTexture { get; set; }
        public int ItemVisual { get; set; }
        public int ParticleColorID { get; set; }
    }

    public class SpellItemEnchantment
    {
        public SpellItemEnchantment()
        {
            EnchantType = new int[3];
            Min = new int[3];
            Max = new int[3];
            Object = new int[3];
        }
        public int ID { get; set; }
        public int Charges { get; set; }
        public int[] EnchantType { get; set; }
        public int[] Min { get; set; }
        public int[] Max { get; set; }
        public int[] Object { get; set; }
        public string Name { get; set; }
        public int NameFlags { get; set; }
        public int ItemVisual { get; set; }
        public int Slot { get; set; }
        public int Item { get; set; }
        public int Condition { get; set; }
        public int SkillLine { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredLevel { get; set; }
    }

    public class ItemRandomProperty
    {
        public ItemRandomProperty()
        {
            Enchant = new int[5];
        }
        public int ID { get; set; }
        public string InnerName { get; set; }
        public int[] Enchant { get; set; }
        public string Name { get; set; }
        public int NameFlag { get; set; }
    }
}
