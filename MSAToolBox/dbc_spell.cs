//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSAToolBox
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbc_spell
    {
        public long ID { get; set; }
        public long Category { get; set; }
        public long Dispel { get; set; }
        public long Mechanic { get; set; }
        public long Attributes { get; set; }
        public long AttributesEx { get; set; }
        public long AttributesEx2 { get; set; }
        public long AttributesEx3 { get; set; }
        public long AttributesEx4 { get; set; }
        public long AttributesEx5 { get; set; }
        public long AttributesEx6 { get; set; }
        public long AttributesEx7 { get; set; }
        public long Stance1 { get; set; }
        public Nullable<long> Stance2 { get; set; }
        public long StanceNot1 { get; set; }
        public Nullable<long> StanceNot2 { get; set; }
        public long Targets { get; set; }
        public long TargetCreatureType { get; set; }
        public long RequiredSpellFocus { get; set; }
        public long FacingCasterFlags { get; set; }
        public long CasterAuraState { get; set; }
        public long TargetAuraState { get; set; }
        public long CasterAuraStateNot { get; set; }
        public long TargetAuraStateNot { get; set; }
        public long CasterAuraSpell { get; set; }
        public long TargetAuraSpell { get; set; }
        public long ExcludeCasterAuraSpell { get; set; }
        public long ExcludeTargetAuraSpell { get; set; }
        public long CastingTimeIndex { get; set; }
        public long RecoveryTime { get; set; }
        public long CategoryRecoveryTime { get; set; }
        public long InterruptFlags { get; set; }
        public long AuraInterruptFlags { get; set; }
        public long ChannelInterruptFlags { get; set; }
        public long ProcFlags { get; set; }
        public int ProcChance { get; set; }
        public long ProcCharges { get; set; }
        public int MaxLevel { get; set; }
        public int BaseLevel { get; set; }
        public int SpellLevel { get; set; }
        public int DurationIndex { get; set; }
        public short PowerType { get; set; }
        public int PowerCost { get; set; }
        public int PowerCostPerLevel { get; set; }
        public int PowerCostPerSecond { get; set; }
        public Nullable<int> PowerCostPerSecondPerLevel { get; set; }
        public int RangeIndex { get; set; }
        public float Speed { get; set; }
        public int ModalNextLevel { get; set; }
        public long StackAmount { get; set; }
        public long Totem1 { get; set; }
        public long Totem2 { get; set; }
        public int Reagent1 { get; set; }
        public int Reagent2 { get; set; }
        public int Reagent3 { get; set; }
        public int Reagent4 { get; set; }
        public int Reagent5 { get; set; }
        public int Reagent6 { get; set; }
        public int Reagent7 { get; set; }
        public int Reagent8 { get; set; }
        public int ReagentCount1 { get; set; }
        public int ReagentCount2 { get; set; }
        public int ReagentCount3 { get; set; }
        public int ReagentCount4 { get; set; }
        public int ReagentCount5 { get; set; }
        public int ReagentCount6 { get; set; }
        public int ReagentCount7 { get; set; }
        public int ReagentCount8 { get; set; }
        public short EquippedItemClass { get; set; }
        public long EquippedItemSubClassMask { get; set; }
        public long EquippedItemInventoryTypeMask { get; set; }
        public int Effect1 { get; set; }
        public int Effect2 { get; set; }
        public int Effect3 { get; set; }
        public int EffectDieSides1 { get; set; }
        public int EffectDieSides2 { get; set; }
        public int EffectDieSides3 { get; set; }
        public float EffectRealPointsPerLevel1 { get; set; }
        public float EffectRealPointsPerLevel2 { get; set; }
        public float EffectRealPointsPerLevel3 { get; set; }
        public int EffectBasePoints1 { get; set; }
        public int EffectBasePoints2 { get; set; }
        public int EffectBasePoints3 { get; set; }
        public int EffectMechanic1 { get; set; }
        public int EffectMechanic2 { get; set; }
        public int EffectMechanic3 { get; set; }
        public int EffectImplicitTargetA1 { get; set; }
        public int EffectImplicitTargetA2 { get; set; }
        public int EffectImplicitTargetA3 { get; set; }
        public int EffectImplicitTargetB1 { get; set; }
        public int EffectImplicitTargetB2 { get; set; }
        public int EffectImplicitTargetB3 { get; set; }
        public int EffectRadiusIndex1 { get; set; }
        public int EffectRadiusIndex2 { get; set; }
        public int EffectRadiusIndex3 { get; set; }
        public int EffectApplyAuraName1 { get; set; }
        public int EffectApplyAuraName2 { get; set; }
        public int EffectApplyAuraName3 { get; set; }
        public long EffectAmplitude1 { get; set; }
        public long EffectAmplitude2 { get; set; }
        public long EffectAmplitude3 { get; set; }
        public float EffectMultipleValue1 { get; set; }
        public float EffectMultipleValue2 { get; set; }
        public float EffectMultipleValue3 { get; set; }
        public int EffectChainTarget1 { get; set; }
        public int EffectChainTarget2 { get; set; }
        public int EffectChainTarget3 { get; set; }
        public long EffectItemType1 { get; set; }
        public long EffectItemType2 { get; set; }
        public long EffectItemType3 { get; set; }
        public int EffectMiscValue1 { get; set; }
        public int EffectMiscValue2 { get; set; }
        public int EffectMiscValue3 { get; set; }
        public int EffectMiscValueB1 { get; set; }
        public int EffectMiscValueB2 { get; set; }
        public int EffectMiscValueB3 { get; set; }
        public long EffectTriggerSpell1 { get; set; }
        public long EffectTriggerSpell2 { get; set; }
        public long EffectTriggerSpell3 { get; set; }
        public float EffectPointsPerComboPoint1 { get; set; }
        public float EffectPointsPerComboPoint2 { get; set; }
        public float EffectPointsPerComboPoint3 { get; set; }
        public long EffectSpellClassMaskA1 { get; set; }
        public long EffectSpellClassMaskA2 { get; set; }
        public long EffectSpellClassMaskA3 { get; set; }
        public long EffectSpellClassMaskB1 { get; set; }
        public long EffectSpellClassMaskB2 { get; set; }
        public long EffectSpellClassMaskB3 { get; set; }
        public long EffectSpellClassMaskC1 { get; set; }
        public long EffectSpellClassMaskC2 { get; set; }
        public long EffectSpellClassMaskC3 { get; set; }
        public long SpellVisual1 { get; set; }
        public long SpellVisual2 { get; set; }
        public long SpellIconID { get; set; }
        public long ActiveIconID { get; set; }
        public int SpellPriority { get; set; }
        public string C_SpellName1 { get; set; }
        public string C_SpellName2 { get; set; }
        public string C_SpellName3 { get; set; }
        public string C_SpellName4 { get; set; }
        public string C_SpellName5 { get; set; }
        public string C_SpellName6 { get; set; }
        public string C_SpellName7 { get; set; }
        public string C_SpellName8 { get; set; }
        public string C_SpellName9 { get; set; }
        public string C_SpellName10 { get; set; }
        public string C_SpellName11 { get; set; }
        public string C_SpellName12 { get; set; }
        public string C_SpellName13 { get; set; }
        public string C_SpellName14 { get; set; }
        public string C_SpellName15 { get; set; }
        public string C_SpellName16 { get; set; }
        public long SpellNameFlag { get; set; }
        public string C_Rank1 { get; set; }
        public string C_Rank2 { get; set; }
        public string C_Rank3 { get; set; }
        public string C_Rank4 { get; set; }
        public string C_Rank5 { get; set; }
        public string C_Rank6 { get; set; }
        public string C_Rank7 { get; set; }
        public string C_Rank8 { get; set; }
        public string C_Rank9 { get; set; }
        public string C_Rank10 { get; set; }
        public string C_Rank11 { get; set; }
        public string C_Rank12 { get; set; }
        public string C_Rank13 { get; set; }
        public string C_Rank14 { get; set; }
        public string C_Rank15 { get; set; }
        public string C_Rank16 { get; set; }
        public long RankFlags { get; set; }
        public string C_Description1 { get; set; }
        public string C_Description2 { get; set; }
        public string C_Description3 { get; set; }
        public string C_Description4 { get; set; }
        public string C_Description5 { get; set; }
        public string C_Description6 { get; set; }
        public string C_Description7 { get; set; }
        public string C_Description8 { get; set; }
        public string C_Description9 { get; set; }
        public string C_Description10 { get; set; }
        public string C_Description11 { get; set; }
        public string C_Description12 { get; set; }
        public string C_Description13 { get; set; }
        public string C_Description14 { get; set; }
        public string C_Description15 { get; set; }
        public string C_Description16 { get; set; }
        public long DescriptionFlags { get; set; }
        public string C_ToolTip1 { get; set; }
        public string C_ToolTip2 { get; set; }
        public string C_ToolTip3 { get; set; }
        public string C_ToolTip4 { get; set; }
        public string C_ToolTip5 { get; set; }
        public string C_ToolTip6 { get; set; }
        public string C_ToolTip7 { get; set; }
        public string C_ToolTip8 { get; set; }
        public string C_ToolTip9 { get; set; }
        public string C_ToolTip10 { get; set; }
        public string C_ToolTip11 { get; set; }
        public string C_ToolTip12 { get; set; }
        public string C_ToolTip13 { get; set; }
        public string C_ToolTip14 { get; set; }
        public string C_ToolTip15 { get; set; }
        public string C_ToolTip16 { get; set; }
        public long ToolTipFlags { get; set; }
        public int PowerCostPercentage { get; set; }
        public long StartRecoveryCategory { get; set; }
        public long StartRecoveryTime { get; set; }
        public int MaxTargetLevel { get; set; }
        public int SpellFamilyName { get; set; }
        public long SpellFamilyFlags1 { get; set; }
        public long SpellFamilyFlags2 { get; set; }
        public long SpellFamilyFlags3 { get; set; }
        public int MaxAffectedTargets { get; set; }
        public int DmgClass { get; set; }
        public long PreventionType { get; set; }
        public short StanceBarOrder { get; set; }
        public float DmgMultiplier1 { get; set; }
        public float DmgMultiplier2 { get; set; }
        public float DmgMultiplier3 { get; set; }
        public long MinFactionId { get; set; }
        public int MinReputation { get; set; }
        public int RequiredAuraVision { get; set; }
        public int TotemCategory1 { get; set; }
        public int TotemCategory2 { get; set; }
        public short AreaGroupId { get; set; }
        public long SchoolMask { get; set; }
        public int RuneCostID { get; set; }
        public int SpellMissileID { get; set; }
        public short PowerDisplayId { get; set; }
        public float EffectCoeffs1 { get; set; }
        public float EffectCoeffs2 { get; set; }
        public float EffectCoeffs3 { get; set; }
        public short SpellDescriptionVariableID { get; set; }
        public int SpellDifficultyId { get; set; }
    }
}
