using MSAToolBox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Reflection;
using System.Collections.ObjectModel;
using MSAToolBox.SubWindows;
using MSAToolBox.SubWindows.Legacy;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// SpellPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SpellPanel : UserControl
    {
        public static ObservableCollection<SpellTemplate> spells;

        public SpellPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            AssignDefines();
            spells = new ObservableCollection<SpellTemplate>();
            LoadSpellDBC(ref spells, "Spell.dbc");
            this.Dispatcher.Invoke(new Action(() =>
            {
                spellList.ItemsSource = spells;
            }));
            spellIconPanel.Load();
        }

        public void LoadSpellDBC(ref ObservableCollection<SpellTemplate> sp, string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int rowCount = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringBlockSize = r.ReadInt32();
                int dataSize = 20 + records * rowSize;
                for (int i = 0; i != records; ++i)
                {
                    SpellTemplate spell = new SpellTemplate();
                    spell.ID = r.ReadUInt32();
                    spell.Category = r.ReadUInt32();
                    spell.Dispel = r.ReadInt32();
                    spell.Mechanic = r.ReadInt32();
                    for (int j = 0; j != spell.Attributes.Length; ++j)
                        spell.Attributes[j] = r.ReadUInt32();
                    spell.Stance[0] = r.ReadUInt32();
                    spell.Stance[1] = r.ReadUInt32();
                    spell.StanceNot[0] = r.ReadUInt32();
                    spell.StanceNot[1] = r.ReadUInt32();
                    spell.Targets = r.ReadUInt32();
                    spell.TargetCreatureType = r.ReadUInt32();
                    spell.RequiredSpellFocus = r.ReadUInt32();
                    spell.RequireFacingTarget = r.ReadUInt32() == 0 ? false : true;
                    spell.CasterAuraState = r.ReadInt32();
                    spell.TargetAuraState = r.ReadInt32();
                    spell.ExcludeCasterAuraState = r.ReadInt32();
                    spell.ExcludeTargetAuraState = r.ReadInt32();
                    spell.CasterAuraSpell = r.ReadUInt32();
                    spell.TargetAuraSpell = r.ReadUInt32();
                    spell.ExcludeCasterAuraSpell = r.ReadUInt32();
                    spell.ExcludeTargetAuraSpell = r.ReadUInt32();
                    spell.CastingTime = r.ReadInt32();
                    spell.Cooldown = r.ReadUInt32();
                    spell.CategoryCooldown = r.ReadUInt32();
                    spell.InterruptFlags = r.ReadUInt32();
                    spell.AuraInterruptFlags = r.ReadUInt32();
                    spell.ChannelInterruptFlags = r.ReadUInt32();
                    spell.Proc = r.ReadUInt32();
                    spell.ProcChance = r.ReadUInt32();
                    spell.ProcCharges = r.ReadUInt32();
                    spell.MaxLevel = r.ReadUInt32();
                    spell.BaseLevel = r.ReadUInt32();
                    spell.Level = r.ReadUInt32();
                    spell.Duration = r.ReadInt32();
                    spell.PowerType = r.ReadInt32();
                    spell.PowerCost = r.ReadUInt32();
                    spell.PowerCostPerLevel = r.ReadUInt32();
                    spell.PowerCostPerSecond = r.ReadUInt32();
                    spell.PowerCostPerSecondPerLevel = r.ReadUInt32();
                    spell.Range = r.ReadInt32();
                    spell.Speed = r.ReadSingle();
                    spell.ModalNextSpell = r.ReadUInt32();
                    spell.StackAmount = r.ReadUInt32();
                    spell.Totem[0] = r.ReadInt32();
                    spell.Totem[1] = r.ReadInt32();
                    for (int j = 0; j != spell.Reagent.Length; ++j)
                        spell.Reagent[j] = r.ReadInt32();
                    for (int j = 0; j != spell.ReagentCount.Length; ++j)
                        spell.ReagentCount[j] = r.ReadUInt32();
                    spell.EquippedItemClass = r.ReadInt32();
                    spell.EquippedItemSubClassMask = r.ReadInt32();
                    spell.EquippedItemInventoryTypeMask = r.ReadInt32();
                    spell.Effect[0] = r.ReadInt32();
                    spell.Effect[1] = r.ReadInt32();
                    spell.Effect[2] = r.ReadInt32();
                    spell.EffectDieSides[0] = r.ReadInt32();
                    spell.EffectDieSides[1] = r.ReadInt32();
                    spell.EffectDieSides[2] = r.ReadInt32();
                    spell.EffectPointsPerLevel[0] = r.ReadSingle();
                    spell.EffectPointsPerLevel[1] = r.ReadSingle();
                    spell.EffectPointsPerLevel[2] = r.ReadSingle();
                    spell.EffectBasePoints[0] = r.ReadInt32();
                    spell.EffectBasePoints[1] = r.ReadInt32();
                    spell.EffectBasePoints[2] = r.ReadInt32();
                    spell.EffectMechanic[0] = r.ReadUInt32();
                    spell.EffectMechanic[1] = r.ReadUInt32();
                    spell.EffectMechanic[2] = r.ReadUInt32();
                    spell.EffectTargetA[0] = r.ReadInt32();
                    spell.EffectTargetA[1] = r.ReadInt32();
                    spell.EffectTargetA[2] = r.ReadInt32();
                    spell.EffectTargetB[0] = r.ReadInt32();
                    spell.EffectTargetB[1] = r.ReadInt32();
                    spell.EffectTargetB[2] = r.ReadInt32();
                    spell.EffectRadius[0] = r.ReadInt32();
                    spell.EffectRadius[1] = r.ReadInt32();
                    spell.EffectRadius[2] = r.ReadInt32();
                    spell.EffectApplyAura[0] = r.ReadInt32();
                    spell.EffectApplyAura[1] = r.ReadInt32();
                    spell.EffectApplyAura[2] = r.ReadInt32();
                    spell.EffectAmplitude[0] = r.ReadUInt32();
                    spell.EffectAmplitude[1] = r.ReadUInt32();
                    spell.EffectAmplitude[2] = r.ReadUInt32();
                    spell.EffectMultipleValue[0] = r.ReadSingle();
                    spell.EffectMultipleValue[1] = r.ReadSingle();
                    spell.EffectMultipleValue[2] = r.ReadSingle();
                    spell.EffectChainTargets[0] = r.ReadUInt32();
                    spell.EffectChainTargets[1] = r.ReadUInt32();
                    spell.EffectChainTargets[2] = r.ReadUInt32();
                    spell.EffectItemType[0] = r.ReadUInt32();
                    spell.EffectItemType[1] = r.ReadUInt32();
                    spell.EffectItemType[2] = r.ReadUInt32();
                    spell.EffectMisc[0] = r.ReadInt32();
                    spell.EffectMisc[1] = r.ReadInt32();
                    spell.EffectMisc[2] = r.ReadInt32();
                    spell.EffectMiscB[0] = r.ReadInt32();
                    spell.EffectMiscB[1] = r.ReadInt32();
                    spell.EffectMiscB[2] = r.ReadInt32();
                    spell.EffectTriggerSpell[0] = r.ReadUInt32();
                    spell.EffectTriggerSpell[1] = r.ReadUInt32();
                    spell.EffectTriggerSpell[2] = r.ReadUInt32();
                    spell.EffectPointsPerComboPoint[0] = r.ReadSingle();
                    spell.EffectPointsPerComboPoint[1] = r.ReadSingle();
                    spell.EffectPointsPerComboPoint[2] = r.ReadSingle();
                    spell.EffectSpellMaskA[0] = r.ReadUInt32();
                    spell.EffectSpellMaskB[0] = r.ReadUInt32();
                    spell.EffectSpellMaskC[0] = r.ReadUInt32();
                    spell.EffectSpellMaskA[1] = r.ReadUInt32();
                    spell.EffectSpellMaskB[1] = r.ReadUInt32();
                    spell.EffectSpellMaskC[1] = r.ReadUInt32();
                    spell.EffectSpellMaskA[2] = r.ReadUInt32();
                    spell.EffectSpellMaskB[2] = r.ReadUInt32();
                    spell.EffectSpellMaskC[2] = r.ReadUInt32();
                    spell.Visual[0] = r.ReadUInt32();
                    spell.Visual[1] = r.ReadUInt32();
                    spell.Icon = r.ReadUInt32();
                    spell.ActiveIcon = r.ReadUInt32();
                    spell.Priority = r.ReadUInt32();
                    stream.Position += 16;
                    spell.Name = DBC.ReadString(r, dataSize);
                    stream.Position += 44;
                    spell.NameFlags = r.ReadUInt32();
                    stream.Position += 16;
                    spell.Rank = DBC.ReadString(r, dataSize);
                    stream.Position += 44;
                    spell.RankFlags = r.ReadUInt32();
                    stream.Position += 16;
                    spell.Description = DBC.ReadString(r, dataSize);
                    stream.Position += 44;
                    spell.DescriptionFlags = r.ReadUInt32();
                    stream.Position += 16;
                    spell.ToolTip = DBC.ReadString(r, dataSize);
                    stream.Position += 44;
                    spell.ToolTipFlags = r.ReadUInt32();
                    spell.PowerCostPercent = r.ReadUInt32();
                    spell.GlobalCategory = r.ReadUInt32();
                    spell.GlobalCooldown = r.ReadUInt32();
                    spell.MaxTargetLevel = r.ReadUInt32();
                    spell.Family = r.ReadInt32();
                    spell.FamilyMaskA = r.ReadUInt32();
                    spell.FamilyMaskB = r.ReadUInt32();
                    spell.FamilyMaskC = r.ReadUInt32();
                    spell.MaxAffectTargets = r.ReadUInt32();
                    spell.DamageClass = r.ReadInt32();
                    spell.PreventionType = r.ReadUInt32();
                    spell.StanceBarOrder = r.ReadUInt32();
                    spell.EffectDamageMultiplier[0] = r.ReadSingle();
                    spell.EffectDamageMultiplier[1] = r.ReadSingle();
                    spell.EffectDamageMultiplier[2] = r.ReadSingle();
                    spell.MinFaction = r.ReadUInt32();
                    spell.MinReputation = r.ReadUInt32();
                    spell.RequiredAuraVision = r.ReadUInt32();
                    spell.TotemCategory[0] = r.ReadInt32();
                    spell.TotemCategory[1] = r.ReadInt32();
                    spell.AreaGroup = r.ReadInt32();
                    spell.SchoolMask = r.ReadUInt32();
                    spell.RuneCost = r.ReadUInt32();
                    spell.Missile = r.ReadUInt32();
                    spell.PowerDisplay = r.ReadUInt32();
                    spell.EffectBonusMultiplier[0] = r.ReadSingle();
                    spell.EffectBonusMultiplier[1] = r.ReadSingle();
                    spell.EffectBonusMultiplier[2] = r.ReadSingle();
                    spell.DescriptionVariable = r.ReadUInt32();
                    spell.Difficulty = r.ReadUInt32();
                    sp.Add(spell);
                }
                r.Close();
            }
        }

        public static void WriteSpellDBC(ObservableCollection<SpellTemplate> sp, List<string> outputPath)
        {
            using (FileStream stream = File.Create("Spell.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, sp.Count, 234, 936);
                List<string> dbcStrings = new List<string>();
                int stringPos = 1;
                foreach (var spell in sp)
                {
                    w.Write(spell.ID);
                    w.Write(spell.Category);
                    w.Write(spell.Dispel);
                    w.Write(spell.Mechanic);
                    for (int i = 0; i != spell.Attributes.Length; ++i)
                        w.Write(spell.Attributes[i]);
                    w.Write(spell.Stance[0]);
                    w.Write(spell.Stance[1]);
                    w.Write(spell.StanceNot[0]);
                    w.Write(spell.StanceNot[1]);
                    w.Write(spell.Targets);
                    w.Write(spell.TargetCreatureType);
                    w.Write(spell.RequiredSpellFocus);
                    w.Write(spell.RequireFacingTarget == false ? 0 : 1);
                    w.Write(spell.CasterAuraState);
                    w.Write(spell.TargetAuraState);
                    w.Write(spell.ExcludeCasterAuraState);
                    w.Write(spell.ExcludeTargetAuraState);
                    w.Write(spell.CasterAuraSpell);
                    w.Write(spell.TargetAuraSpell);
                    w.Write(spell.ExcludeCasterAuraSpell);
                    w.Write(spell.ExcludeTargetAuraSpell);
                    w.Write(spell.CastingTime);
                    w.Write(spell.Cooldown);
                    w.Write(spell.CategoryCooldown);
                    w.Write(spell.InterruptFlags);
                    w.Write(spell.AuraInterruptFlags);
                    w.Write(spell.ChannelInterruptFlags);
                    w.Write(spell.Proc);
                    w.Write(spell.ProcChance);
                    w.Write(spell.ProcCharges);
                    w.Write(spell.MaxLevel);
                    w.Write(spell.BaseLevel);
                    w.Write(spell.Level);
                    w.Write(spell.Duration);
                    w.Write(spell.PowerType);
                    w.Write(spell.PowerCost);
                    w.Write(spell.PowerCostPerLevel);
                    w.Write(spell.PowerCostPerSecond);
                    w.Write(spell.PowerCostPerSecondPerLevel);
                    w.Write(spell.Range);
                    w.Write(spell.Speed);
                    w.Write(spell.ModalNextSpell);
                    w.Write(spell.StackAmount);
                    w.Write(spell.Totem[0]);
                    w.Write(spell.Totem[1]);
                    for (int i = 0; i != spell.Reagent.Length; ++i)
                        w.Write(spell.Reagent[i]);
                    for (int i = 0; i != spell.ReagentCount.Length; ++i)
                        w.Write(spell.ReagentCount[i]);
                    w.Write(spell.EquippedItemClass);
                    w.Write(spell.EquippedItemSubClassMask);
                    w.Write(spell.EquippedItemInventoryTypeMask);
                    w.Write(spell.Effect[0]);
                    w.Write(spell.Effect[1]);
                    w.Write(spell.Effect[2]);
                    w.Write(spell.EffectDieSides[0]);
                    w.Write(spell.EffectDieSides[1]);
                    w.Write(spell.EffectDieSides[2]);
                    w.Write(spell.EffectPointsPerLevel[0]);
                    w.Write(spell.EffectPointsPerLevel[1]);
                    w.Write(spell.EffectPointsPerLevel[2]);
                    w.Write(spell.EffectBasePoints[0]);
                    w.Write(spell.EffectBasePoints[1]);
                    w.Write(spell.EffectBasePoints[2]);
                    w.Write(spell.EffectMechanic[0]);
                    w.Write(spell.EffectMechanic[1]);
                    w.Write(spell.EffectMechanic[2]);
                    w.Write(spell.EffectTargetA[0]);
                    w.Write(spell.EffectTargetA[1]);
                    w.Write(spell.EffectTargetA[2]);
                    w.Write(spell.EffectTargetB[0]);
                    w.Write(spell.EffectTargetB[1]);
                    w.Write(spell.EffectTargetB[2]);
                    w.Write(spell.EffectRadius[0]);
                    w.Write(spell.EffectRadius[1]);
                    w.Write(spell.EffectRadius[2]);
                    w.Write(spell.EffectApplyAura[0]);
                    w.Write(spell.EffectApplyAura[1]);
                    w.Write(spell.EffectApplyAura[2]);
                    w.Write(spell.EffectAmplitude[0]);
                    w.Write(spell.EffectAmplitude[1]);
                    w.Write(spell.EffectAmplitude[2]);
                    w.Write(spell.EffectMultipleValue[0]);
                    w.Write(spell.EffectMultipleValue[1]);
                    w.Write(spell.EffectMultipleValue[2]);
                    w.Write(spell.EffectChainTargets[0]);
                    w.Write(spell.EffectChainTargets[1]);
                    w.Write(spell.EffectChainTargets[2]);
                    w.Write(spell.EffectItemType[0]);
                    w.Write(spell.EffectItemType[1]);
                    w.Write(spell.EffectItemType[2]);
                    w.Write(spell.EffectMisc[0]);
                    w.Write(spell.EffectMisc[1]);
                    w.Write(spell.EffectMisc[2]);
                    w.Write(spell.EffectMiscB[0]);
                    w.Write(spell.EffectMiscB[1]);
                    w.Write(spell.EffectMiscB[2]);
                    w.Write(spell.EffectTriggerSpell[0]);
                    w.Write(spell.EffectTriggerSpell[1]);
                    w.Write(spell.EffectTriggerSpell[2]);
                    w.Write(spell.EffectPointsPerComboPoint[0]);
                    w.Write(spell.EffectPointsPerComboPoint[1]);
                    w.Write(spell.EffectPointsPerComboPoint[2]);
                    w.Write(spell.EffectSpellMaskA[0]);
                    w.Write(spell.EffectSpellMaskB[0]);
                    w.Write(spell.EffectSpellMaskC[0]);
                    w.Write(spell.EffectSpellMaskA[1]);
                    w.Write(spell.EffectSpellMaskB[1]);
                    w.Write(spell.EffectSpellMaskC[1]);
                    w.Write(spell.EffectSpellMaskA[2]);
                    w.Write(spell.EffectSpellMaskB[2]);
                    w.Write(spell.EffectSpellMaskC[2]);
                    w.Write(spell.Visual[0]);
                    w.Write(spell.Visual[1]);
                    w.Write(spell.Icon);
                    w.Write(spell.ActiveIcon);
                    w.Write(spell.Priority);
                    DBC.WriteZeros(w, 4);
                    if (spell.Name == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Name + "\0").Length;
                        dbcStrings.Add(spell.Name);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.NameFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.Rank == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Rank + "\0").Length;
                        dbcStrings.Add(spell.Rank);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.RankFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.Description == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Description + "\0").Length;
                        dbcStrings.Add(spell.Description);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.DescriptionFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.ToolTip == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.ToolTip + "\0").Length;
                        dbcStrings.Add(spell.ToolTip);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.ToolTipFlags);
                    w.Write(spell.PowerCostPercent);
                    w.Write(spell.GlobalCategory);
                    w.Write(spell.GlobalCooldown);
                    w.Write(spell.MaxTargetLevel);
                    w.Write(spell.Family);
                    w.Write(spell.FamilyMaskA);
                    w.Write(spell.FamilyMaskB);
                    w.Write(spell.FamilyMaskC);
                    w.Write(spell.MaxAffectTargets);
                    w.Write(spell.DamageClass);
                    w.Write(spell.PreventionType);
                    w.Write(spell.StanceBarOrder);
                    w.Write(spell.EffectDamageMultiplier[0]);
                    w.Write(spell.EffectDamageMultiplier[1]);
                    w.Write(spell.EffectDamageMultiplier[2]);
                    w.Write(spell.MinFaction);
                    w.Write(spell.MinReputation);
                    w.Write(spell.RequiredAuraVision);
                    w.Write(spell.TotemCategory[0]);
                    w.Write(spell.TotemCategory[1]);
                    w.Write(spell.AreaGroup);
                    w.Write(spell.SchoolMask);
                    w.Write(spell.RuneCost);
                    w.Write(spell.Missile);
                    w.Write(spell.PowerDisplay);
                    w.Write(spell.EffectBonusMultiplier[0]);
                    w.Write(spell.EffectBonusMultiplier[1]);
                    w.Write(spell.EffectBonusMultiplier[2]);
                    w.Write(spell.DescriptionVariable);
                    w.Write(spell.Difficulty);
                }
                w.Write((byte)0);
                foreach (string s in dbcStrings)
                    w.Write(Encoding.UTF8.GetBytes(s + "\0"));
                stream.Position = 16;
                w.Write(stringPos);
                w.Close();

                foreach (var path in outputPath)
                    File.Copy("Spell.dbc", path, true);
            }
        }

        public static void WriteClientDBC(ObservableCollection<SpellTemplate> sp, string path)
        {
            using (FileStream stream = File.Create(path))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, sp.Count, 234, 936);
                List<string> dbcStrings = new List<string>();
                int stringPos = 1;
                foreach (var spell in sp)
                {
                    w.Write(spell.ID);
                    w.Write(spell.Category);
                    w.Write(spell.Dispel);
                    w.Write(spell.Mechanic);
                    for (int i = 0; i != spell.Attributes.Length; ++i)
                        w.Write(spell.Attributes[i]);
                    w.Write(spell.Stance[0]);
                    w.Write(spell.Stance[1]);
                    w.Write(spell.StanceNot[0]);
                    w.Write(spell.StanceNot[1]);
                    w.Write(spell.Targets);
                    w.Write(spell.TargetCreatureType);
                    w.Write(spell.RequiredSpellFocus);
                    w.Write(spell.RequireFacingTarget == false ? 0 : 1);
                    w.Write(spell.CasterAuraState);
                    w.Write(spell.TargetAuraState);
                    w.Write(spell.ExcludeCasterAuraState);
                    w.Write(spell.ExcludeTargetAuraState);
                    w.Write(spell.CasterAuraSpell);
                    w.Write(spell.TargetAuraSpell);
                    w.Write(spell.ExcludeCasterAuraSpell);
                    w.Write(spell.ExcludeTargetAuraSpell);
                    w.Write(spell.CastingTime);
                    w.Write(spell.Cooldown);
                    w.Write(spell.CategoryCooldown);
                    w.Write(spell.InterruptFlags);
                    w.Write(spell.AuraInterruptFlags);
                    w.Write(spell.ChannelInterruptFlags);
                    w.Write(spell.Proc);
                    w.Write(spell.ProcChance);
                    w.Write(spell.ProcCharges);
                    w.Write(spell.MaxLevel);
                    w.Write(spell.BaseLevel);
                    w.Write(spell.Level);
                    w.Write(spell.Duration);
                    w.Write(spell.PowerType);
                    w.Write(spell.PowerCost);
                    w.Write(spell.PowerCostPerLevel);
                    w.Write(spell.PowerCostPerSecond);
                    w.Write(spell.PowerCostPerSecondPerLevel);
                    w.Write(spell.Range);
                    w.Write(spell.Speed);
                    w.Write(spell.ModalNextSpell);
                    w.Write(spell.StackAmount);
                    w.Write(spell.Totem[0]);
                    w.Write(spell.Totem[1]);
                    for (int i = 0; i != spell.Reagent.Length; ++i)
                        w.Write(spell.Reagent[i]);
                    for (int i = 0; i != spell.ReagentCount.Length; ++i)
                        w.Write(spell.ReagentCount[i]);
                    w.Write(spell.EquippedItemClass);
                    w.Write(spell.EquippedItemSubClassMask);
                    w.Write(spell.EquippedItemInventoryTypeMask);
                    w.Write(ReplaceEffect(spell.Effect[0]));
                    w.Write(ReplaceEffect(spell.Effect[1]));
                    w.Write(ReplaceEffect(spell.Effect[2]));
                    w.Write(spell.EffectDieSides[0]);
                    w.Write(spell.EffectDieSides[1]);
                    w.Write(spell.EffectDieSides[2]);
                    w.Write(spell.EffectPointsPerLevel[0]);
                    w.Write(spell.EffectPointsPerLevel[1]);
                    w.Write(spell.EffectPointsPerLevel[2]);
                    w.Write(spell.EffectBasePoints[0]);
                    w.Write(spell.EffectBasePoints[1]);
                    w.Write(spell.EffectBasePoints[2]);
                    w.Write(spell.EffectMechanic[0]);
                    w.Write(spell.EffectMechanic[1]);
                    w.Write(spell.EffectMechanic[2]);
                    w.Write(spell.EffectTargetA[0]);
                    w.Write(spell.EffectTargetA[1]);
                    w.Write(spell.EffectTargetA[2]);
                    w.Write(spell.EffectTargetB[0]);
                    w.Write(spell.EffectTargetB[1]);
                    w.Write(spell.EffectTargetB[2]);
                    w.Write(spell.EffectRadius[0]);
                    w.Write(spell.EffectRadius[1]);
                    w.Write(spell.EffectRadius[2]);
                    w.Write(ReplaceAura(spell.EffectApplyAura[0]));
                    w.Write(ReplaceAura(spell.EffectApplyAura[1]));
                    w.Write(ReplaceAura(spell.EffectApplyAura[2]));
                    w.Write(spell.EffectAmplitude[0]);
                    w.Write(spell.EffectAmplitude[1]);
                    w.Write(spell.EffectAmplitude[2]);
                    w.Write(spell.EffectMultipleValue[0]);
                    w.Write(spell.EffectMultipleValue[1]);
                    w.Write(spell.EffectMultipleValue[2]);
                    w.Write(spell.EffectChainTargets[0]);
                    w.Write(spell.EffectChainTargets[1]);
                    w.Write(spell.EffectChainTargets[2]);
                    w.Write(spell.EffectItemType[0]);
                    w.Write(spell.EffectItemType[1]);
                    w.Write(spell.EffectItemType[2]);
                    w.Write(spell.EffectMisc[0]);
                    w.Write(spell.EffectMisc[1]);
                    w.Write(spell.EffectMisc[2]);
                    w.Write(spell.EffectMiscB[0]);
                    w.Write(spell.EffectMiscB[1]);
                    w.Write(spell.EffectMiscB[2]);
                    w.Write(spell.EffectTriggerSpell[0]);
                    w.Write(spell.EffectTriggerSpell[1]);
                    w.Write(spell.EffectTriggerSpell[2]);
                    w.Write(spell.EffectPointsPerComboPoint[0]);
                    w.Write(spell.EffectPointsPerComboPoint[1]);
                    w.Write(spell.EffectPointsPerComboPoint[2]);
                    w.Write(spell.EffectSpellMaskA[0]);
                    w.Write(spell.EffectSpellMaskB[0]);
                    w.Write(spell.EffectSpellMaskC[0]);
                    w.Write(spell.EffectSpellMaskA[1]);
                    w.Write(spell.EffectSpellMaskB[1]);
                    w.Write(spell.EffectSpellMaskC[1]);
                    w.Write(spell.EffectSpellMaskA[2]);
                    w.Write(spell.EffectSpellMaskB[2]);
                    w.Write(spell.EffectSpellMaskC[2]);
                    w.Write(spell.Visual[0]);
                    w.Write(spell.Visual[1]);
                    w.Write(spell.Icon);
                    w.Write(spell.ActiveIcon);
                    w.Write(spell.Priority);
                    DBC.WriteZeros(w, 4);
                    if (spell.Name == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Name + "\0").Length;
                        dbcStrings.Add(spell.Name);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.NameFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.Rank == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Rank + "\0").Length;
                        dbcStrings.Add(spell.Rank);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.RankFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.Description == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.Description + "\0").Length;
                        dbcStrings.Add(spell.Description);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.DescriptionFlags);
                    DBC.WriteZeros(w, 4);
                    if (spell.ToolTip == "")
                        w.Write(0);
                    else
                    {
                        w.Write(stringPos);
                        stringPos += Encoding.UTF8.GetBytes(spell.ToolTip + "\0").Length;
                        dbcStrings.Add(spell.ToolTip);
                    }
                    DBC.WriteZeros(w, 11);
                    w.Write(spell.ToolTipFlags);
                    w.Write(spell.PowerCostPercent);
                    w.Write(spell.GlobalCategory);
                    w.Write(spell.GlobalCooldown);
                    w.Write(spell.MaxTargetLevel);
                    w.Write(spell.Family);
                    w.Write(spell.FamilyMaskA);
                    w.Write(spell.FamilyMaskB);
                    w.Write(spell.FamilyMaskC);
                    w.Write(spell.MaxAffectTargets);
                    w.Write(spell.DamageClass);
                    w.Write(spell.PreventionType);
                    w.Write(spell.StanceBarOrder);
                    w.Write(spell.EffectDamageMultiplier[0]);
                    w.Write(spell.EffectDamageMultiplier[1]);
                    w.Write(spell.EffectDamageMultiplier[2]);
                    w.Write(spell.MinFaction);
                    w.Write(spell.MinReputation);
                    w.Write(spell.RequiredAuraVision);
                    w.Write(spell.TotemCategory[0]);
                    w.Write(spell.TotemCategory[1]);
                    w.Write(spell.AreaGroup);
                    w.Write(spell.SchoolMask);
                    w.Write(spell.RuneCost);
                    w.Write(spell.Missile);
                    w.Write(spell.PowerDisplay);
                    w.Write(spell.EffectBonusMultiplier[0]);
                    w.Write(spell.EffectBonusMultiplier[1]);
                    w.Write(spell.EffectBonusMultiplier[2]);
                    w.Write(spell.DescriptionVariable);
                    w.Write(spell.Difficulty);
                }
                w.Write((byte)0);
                foreach (string s in dbcStrings)
                    w.Write(Encoding.UTF8.GetBytes(s + "\0"));
                stream.Position = 16;
                w.Write(stringPos);
                w.Close();
            }
        }

        private void spellList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (spellTab.DataContext != null)
            //{
            //    SpellTemplate spell = spellTab.DataContext as SpellTemplate;
            //    UpdateSpell(spell);
            //}
            if (spellList.SelectedItem == null)
                return;
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            spellTab.DataContext = spellList.SelectedItem;
            spellIconPanel.Load(spell);
            spellAttributes.Load((SpellTemplate)(spellList.SelectedItem));
            school1.IsChecked = (spell.SchoolMask & 1) != 0;
            school2.IsChecked = (spell.SchoolMask & 2) != 0;
            school3.IsChecked = (spell.SchoolMask & 4) != 0;
            school4.IsChecked = (spell.SchoolMask & 8) != 0;
            school5.IsChecked = (spell.SchoolMask & 16) != 0;
            school6.IsChecked = (spell.SchoolMask & 32) != 0;
            school7.IsChecked = (spell.SchoolMask & 64) != 0;
            preventionType1.IsChecked = (spell.PreventionType & 1) != 0;
            preventionType2.IsChecked = (spell.PreventionType & 2) != 0;
        }

        public void AssignDefines()
        {
            damageClass.ItemsSource = DataDefine.SpellDamageClass;
            dispel.ItemsSource = DataDefine.SpellDispel;
            mechanic.ItemsSource = DataDefine.SpellMechanic;
            range.ItemsSource = DataDefine.SpellRange;
            duration.ItemsSource = DataDefine.SpellDuration;
            casttime.ItemsSource = DataDefine.SpellCastTime;
            powertype.ItemsSource = DataDefine.SpellPowerType;
            spellfamily.ItemsSource = DataDefine.SpellFamily;
            casteraurastate.ItemsSource = DataDefine.SpellAuraState;
            targetaurastate.ItemsSource = DataDefine.SpellAuraState;
            xcasteraurastate.ItemsSource = DataDefine.SpellAuraState;
            xtargetaurastate.ItemsSource = DataDefine.SpellAuraState;
            totemcategory1.ItemsSource = DataDefine.TotemCategory;
            totemcategory2.ItemsSource = DataDefine.TotemCategory;
            ef1.ItemsSource = DataDefine.SpellEffect;
            ef2.ItemsSource = DataDefine.SpellEffect;
            ef3.ItemsSource = DataDefine.SpellEffect;
            ef1m.ItemsSource = DataDefine.SpellMechanic;
            ef2m.ItemsSource = DataDefine.SpellMechanic;
            ef3m.ItemsSource = DataDefine.SpellMechanic;
            ef1ta.ItemsSource = DataDefine.SpellEffectTarget;
            ef2ta.ItemsSource = DataDefine.SpellEffectTarget;
            ef3ta.ItemsSource = DataDefine.SpellEffectTarget;
            ef1tb.ItemsSource = DataDefine.SpellEffectTarget;
            ef2tb.ItemsSource = DataDefine.SpellEffectTarget;
            ef3tb.ItemsSource = DataDefine.SpellEffectTarget;
            ef1r.ItemsSource = DataDefine.SpellEffectRadius;
            ef2r.ItemsSource = DataDefine.SpellEffectRadius;
            ef3r.ItemsSource = DataDefine.SpellEffectRadius;
            ef1au.ItemsSource = DataDefine.SpellAura;
            ef2au.ItemsSource = DataDefine.SpellAura;
            ef3au.ItemsSource = DataDefine.SpellAura;
        }

        private void exportDBC_Click(object sender, RoutedEventArgs e)
        {
            WriteSpellDBC(spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc", MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc" });
        }

        private void copySpell_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = new SpellTemplate();
            SpellTemplate spell2copy = spellList.SelectedItem as SpellTemplate;
            spell.ID = (from d in spells select d.ID).Max() + 1;
            spell.Category = spell2copy.Category;
            spell.Dispel = spell2copy.Dispel;
            spell.Mechanic = spell2copy.Mechanic;
            spell.Attributes[0] = spell2copy.Attributes[0];
            spell.Attributes[1] = spell2copy.Attributes[1];
            spell.Attributes[2] = spell2copy.Attributes[2];
            spell.Attributes[3] = spell2copy.Attributes[3];
            spell.Attributes[4] = spell2copy.Attributes[4];
            spell.Attributes[5] = spell2copy.Attributes[5];
            spell.Attributes[6] = spell2copy.Attributes[6];
            spell.Attributes[7] = spell2copy.Attributes[7];
            spell.Stance[0] = spell2copy.Stance[0];
            spell.Stance[1] = spell2copy.Stance[1];
            spell.StanceNot[0] = spell2copy.StanceNot[0];
            spell.StanceNot[1] = spell2copy.StanceNot[1];
            spell.Targets = spell2copy.Targets;
            spell.TargetCreatureType = spell2copy.TargetCreatureType;
            spell.RequiredSpellFocus = spell2copy.RequiredSpellFocus;
            spell.RequireFacingTarget = spell2copy.RequireFacingTarget;
            spell.CasterAuraState = spell2copy.CasterAuraState;
            spell.TargetAuraState = spell2copy.TargetAuraState;
            spell.ExcludeCasterAuraState = spell2copy.ExcludeCasterAuraState;
            spell.ExcludeTargetAuraState = spell2copy.ExcludeTargetAuraState;
            spell.CasterAuraSpell = spell2copy.CasterAuraSpell;
            spell.TargetAuraSpell = spell2copy.TargetAuraSpell;
            spell.ExcludeCasterAuraSpell = spell2copy.ExcludeCasterAuraSpell;
            spell.ExcludeTargetAuraSpell = spell2copy.ExcludeTargetAuraSpell;
            spell.CastingTime = spell2copy.CastingTime;
            spell.Cooldown = spell2copy.Cooldown;
            spell.CategoryCooldown = spell2copy.CategoryCooldown;
            spell.InterruptFlags = spell2copy.InterruptFlags;
            spell.AuraInterruptFlags = spell2copy.AuraInterruptFlags;
            spell.ChannelInterruptFlags = spell2copy.ChannelInterruptFlags;
            spell.Proc = spell2copy.Proc;
            spell.ProcChance = spell2copy.ProcChance;
            spell.ProcCharges = spell2copy.ProcCharges;
            spell.MaxLevel = spell2copy.MaxLevel;
            spell.BaseLevel = spell2copy.BaseLevel;
            spell.Level = spell2copy.Level;
            spell.Duration = spell2copy.Duration;
            spell.PowerType = spell2copy.PowerType;
            spell.PowerCost = spell2copy.PowerCost;
            spell.PowerCostPerLevel = spell2copy.PowerCostPerLevel;
            spell.PowerCostPerSecond = spell2copy.PowerCostPerSecond;
            spell.PowerCostPerSecondPerLevel = spell2copy.PowerCostPerSecondPerLevel;
            spell.Range = spell2copy.Range;
            spell.Speed = spell2copy.Speed;
            spell.ModalNextSpell = spell2copy.ModalNextSpell;
            spell.StackAmount = spell2copy.StackAmount;
            spell.Totem[0] = spell2copy.Totem[0];
            spell.Totem[1] = spell2copy.Totem[1];
            spell.Reagent[0] = spell2copy.Reagent[0];
            spell.Reagent[1] = spell2copy.Reagent[1];
            spell.Reagent[2] = spell2copy.Reagent[2];
            spell.Reagent[3] = spell2copy.Reagent[3];
            spell.Reagent[4] = spell2copy.Reagent[4];
            spell.Reagent[5] = spell2copy.Reagent[5];
            spell.Reagent[6] = spell2copy.Reagent[6];
            spell.Reagent[7] = spell2copy.Reagent[7];
            spell.ReagentCount[0] = spell2copy.ReagentCount[0];
            spell.ReagentCount[1] = spell2copy.ReagentCount[1];
            spell.ReagentCount[2] = spell2copy.ReagentCount[2];
            spell.ReagentCount[3] = spell2copy.ReagentCount[3];
            spell.ReagentCount[4] = spell2copy.ReagentCount[4];
            spell.ReagentCount[5] = spell2copy.ReagentCount[5];
            spell.ReagentCount[6] = spell2copy.ReagentCount[6];
            spell.ReagentCount[7] = spell2copy.ReagentCount[7];
            spell.EquippedItemClass = spell2copy.EquippedItemClass;
            spell.EquippedItemSubClassMask = spell2copy.EquippedItemSubClassMask;
            spell.EquippedItemInventoryTypeMask = spell2copy.EquippedItemInventoryTypeMask;
            spell.Effect[0] = spell2copy.Effect[0];
            spell.Effect[1] = spell2copy.Effect[1];
            spell.Effect[2] = spell2copy.Effect[2];
            spell.EffectDieSides[0] = spell2copy.EffectDieSides[0];
            spell.EffectDieSides[1] = spell2copy.EffectDieSides[1];
            spell.EffectDieSides[2] = spell2copy.EffectDieSides[2];
            spell.EffectPointsPerLevel[0] = spell2copy.EffectPointsPerLevel[0];
            spell.EffectPointsPerLevel[1] = spell2copy.EffectPointsPerLevel[1];
            spell.EffectPointsPerLevel[2] = spell2copy.EffectPointsPerLevel[2];
            spell.EffectBasePoints[0] = spell2copy.EffectBasePoints[0];
            spell.EffectBasePoints[1] = spell2copy.EffectBasePoints[1];
            spell.EffectBasePoints[2] = spell2copy.EffectBasePoints[2];
            spell.EffectMechanic[0] = spell2copy.EffectMechanic[0];
            spell.EffectMechanic[1] = spell2copy.EffectMechanic[1];
            spell.EffectMechanic[2] = spell2copy.EffectMechanic[2];
            spell.EffectTargetA[0] = spell2copy.EffectTargetA[0];
            spell.EffectTargetA[1] = spell2copy.EffectTargetA[1];
            spell.EffectTargetA[2] = spell2copy.EffectTargetA[2];
            spell.EffectTargetB[0] = spell2copy.EffectTargetB[0];
            spell.EffectTargetB[1] = spell2copy.EffectTargetB[1];
            spell.EffectTargetB[2] = spell2copy.EffectTargetB[2];
            spell.EffectRadius[0] = spell2copy.EffectRadius[0];
            spell.EffectRadius[1] = spell2copy.EffectRadius[1];
            spell.EffectRadius[2] = spell2copy.EffectRadius[2];
            spell.EffectApplyAura[0] = spell2copy.EffectApplyAura[0];
            spell.EffectApplyAura[1] = spell2copy.EffectApplyAura[1];
            spell.EffectApplyAura[2] = spell2copy.EffectApplyAura[2];
            spell.EffectAmplitude[0] = spell2copy.EffectAmplitude[0];
            spell.EffectAmplitude[1] = spell2copy.EffectAmplitude[1];
            spell.EffectAmplitude[2] = spell2copy.EffectAmplitude[2];
            spell.EffectMultipleValue[0] = spell2copy.EffectMultipleValue[0];
            spell.EffectMultipleValue[1] = spell2copy.EffectMultipleValue[1];
            spell.EffectMultipleValue[2] = spell2copy.EffectMultipleValue[2];
            spell.EffectChainTargets[0] = spell2copy.EffectChainTargets[0];
            spell.EffectChainTargets[1] = spell2copy.EffectChainTargets[1];
            spell.EffectChainTargets[2] = spell2copy.EffectChainTargets[2];
            spell.EffectItemType[0] = spell2copy.EffectItemType[0];
            spell.EffectItemType[1] = spell2copy.EffectItemType[1];
            spell.EffectItemType[2] = spell2copy.EffectItemType[2];
            spell.EffectMisc[0] = spell2copy.EffectMisc[0];
            spell.EffectMisc[1] = spell2copy.EffectMisc[1];
            spell.EffectMisc[2] = spell2copy.EffectMisc[2];
            spell.EffectMiscB[0] = spell2copy.EffectMiscB[0];
            spell.EffectMiscB[1] = spell2copy.EffectMiscB[1];
            spell.EffectMiscB[2] = spell2copy.EffectMiscB[2];
            spell.EffectTriggerSpell[0] = spell2copy.EffectTriggerSpell[0];
            spell.EffectTriggerSpell[1] = spell2copy.EffectTriggerSpell[1];
            spell.EffectTriggerSpell[2] = spell2copy.EffectTriggerSpell[2];
            spell.EffectPointsPerComboPoint[0] = spell2copy.EffectPointsPerComboPoint[0];
            spell.EffectPointsPerComboPoint[1] = spell2copy.EffectPointsPerComboPoint[1];
            spell.EffectPointsPerComboPoint[2] = spell2copy.EffectPointsPerComboPoint[2];
            spell.EffectSpellMaskA[0] = spell2copy.EffectSpellMaskA[0];
            spell.EffectSpellMaskA[1] = spell2copy.EffectSpellMaskA[1];
            spell.EffectSpellMaskA[2] = spell2copy.EffectSpellMaskA[2];
            spell.EffectSpellMaskB[0] = spell2copy.EffectSpellMaskB[0];
            spell.EffectSpellMaskB[1] = spell2copy.EffectSpellMaskB[1];
            spell.EffectSpellMaskB[2] = spell2copy.EffectSpellMaskB[2];
            spell.EffectSpellMaskC[0] = spell2copy.EffectSpellMaskC[0];
            spell.EffectSpellMaskC[1] = spell2copy.EffectSpellMaskC[1];
            spell.EffectSpellMaskC[2] = spell2copy.EffectSpellMaskC[2];
            spell.Visual[0] = spell2copy.Visual[0];
            spell.Visual[1] = spell2copy.Visual[1];
            spell.Icon = spell2copy.Icon;
            spell.ActiveIcon = spell2copy.ActiveIcon;
            spell.Priority = spell2copy.Priority;
            spell.Name = spell2copy.Name;
            spell.NameFlags = spell2copy.NameFlags;
            spell.Rank = spell2copy.Rank;
            spell.RankFlags = spell2copy.RankFlags;
            spell.Description = spell2copy.Description;
            spell.DescriptionFlags = spell2copy.DescriptionFlags;
            spell.ToolTip = spell2copy.ToolTip;
            spell.ToolTipFlags = spell2copy.ToolTipFlags;
            spell.PowerCostPercent = spell2copy.PowerCostPercent;
            spell.GlobalCategory = spell2copy.GlobalCategory;
            spell.GlobalCooldown = spell2copy.GlobalCooldown;
            spell.MaxTargetLevel = spell2copy.MaxTargetLevel;
            spell.Family = spell2copy.Family;
            spell.FamilyMaskA = spell2copy.FamilyMaskA;
            spell.FamilyMaskB = spell2copy.FamilyMaskB;
            spell.FamilyMaskC = spell2copy.FamilyMaskC;
            spell.MaxAffectTargets = spell2copy.MaxAffectTargets;
            spell.DamageClass = spell2copy.DamageClass;
            spell.PreventionType = spell2copy.PreventionType;
            spell.StanceBarOrder = spell2copy.StanceBarOrder;
            spell.EffectDamageMultiplier[0] = spell2copy.EffectDamageMultiplier[0];
            spell.EffectDamageMultiplier[1] = spell2copy.EffectDamageMultiplier[1];
            spell.EffectDamageMultiplier[2] = spell2copy.EffectDamageMultiplier[2];
            spell.MinFaction = spell2copy.MinFaction;
            spell.MinReputation = spell2copy.MinReputation;
            spell.RequiredAuraVision = spell2copy.RequiredAuraVision;
            spell.TotemCategory[0] = spell2copy.TotemCategory[0];
            spell.TotemCategory[1] = spell2copy.TotemCategory[1];
            spell.AreaGroup = spell2copy.AreaGroup;
            spell.SchoolMask = spell2copy.SchoolMask;
            spell.RuneCost = spell2copy.RuneCost;
            spell.Missile = spell2copy.Missile;
            spell.PowerDisplay = spell2copy.PowerDisplay;
            spell.EffectBonusMultiplier[0] = spell2copy.EffectBonusMultiplier[0];
            spell.EffectBonusMultiplier[1] = spell2copy.EffectBonusMultiplier[1];
            spell.DescriptionVariable = spell2copy.DescriptionVariable;
            spell.Difficulty = spell2copy.Difficulty;
            spells.Add(spell);
        }

        public static SpellTemplate CreateNewSpell()
        {
            SpellTemplate spell = new SpellTemplate();
            spell.ID = (from d in spells select d.ID).Max() + 1;
            spell.Category = 0;
            spell.Dispel = 0;
            spell.Mechanic = 0;
            spell.Attributes[0] = 0;
            spell.Attributes[1] = 0;
            spell.Attributes[2] = 0;
            spell.Attributes[3] = 0;
            spell.Attributes[4] = 0;
            spell.Attributes[5] = 0;
            spell.Attributes[6] = 0;
            spell.Attributes[7] = 0;
            spell.Stance[0] = 0;
            spell.Stance[1] = 0;
            spell.StanceNot[0] = 0;
            spell.StanceNot[1] = 0;
            spell.Targets = 0;
            spell.TargetCreatureType = 0;
            spell.RequiredSpellFocus = 0;
            spell.RequireFacingTarget = false;
            spell.CasterAuraState = 0;
            spell.TargetAuraState = 0;
            spell.ExcludeCasterAuraState = 0;
            spell.ExcludeTargetAuraState = 0;
            spell.CasterAuraSpell = 0;
            spell.TargetAuraSpell = 0;
            spell.ExcludeCasterAuraSpell = 0;
            spell.ExcludeTargetAuraSpell = 0;
            spell.CastingTime = 0;
            spell.Cooldown = 0;
            spell.CategoryCooldown = 0;
            spell.InterruptFlags = 0;
            spell.AuraInterruptFlags = 0;
            spell.ChannelInterruptFlags = 0;
            spell.Proc = 0;
            spell.ProcChance = 0;
            spell.ProcCharges = 0;
            spell.MaxLevel = 0;
            spell.BaseLevel = 0;
            spell.Level = 0;
            spell.Duration = 0;
            spell.PowerType = 0;
            spell.PowerCost = 0;
            spell.PowerCostPerLevel = 0;
            spell.PowerCostPerSecond = 0;
            spell.PowerCostPerSecondPerLevel = 0;
            spell.Range = 0;
            spell.Speed = 0;
            spell.ModalNextSpell = 0;
            spell.StackAmount = 0;
            spell.Totem[0] = 0;
            spell.Totem[1] = 0;
            spell.Reagent[0] = 0;
            spell.Reagent[1] = 0;
            spell.Reagent[2] = 0;
            spell.Reagent[3] = 0;
            spell.Reagent[4] = 0;
            spell.Reagent[5] = 0;
            spell.Reagent[6] = 0;
            spell.Reagent[7] = 0;
            spell.ReagentCount[0] = 0;
            spell.ReagentCount[1] = 0;
            spell.ReagentCount[2] = 0;
            spell.ReagentCount[3] = 0;
            spell.ReagentCount[4] = 0;
            spell.ReagentCount[5] = 0;
            spell.ReagentCount[6] = 0;
            spell.ReagentCount[7] = 0;
            spell.EquippedItemClass = -1;
            spell.EquippedItemSubClassMask = 0;
            spell.EquippedItemInventoryTypeMask = 0;
            spell.Effect[0] = 0;
            spell.Effect[1] = 0;
            spell.Effect[2] = 0;
            spell.EffectDieSides[0] = 0;
            spell.EffectDieSides[1] = 0;
            spell.EffectDieSides[2] = 0;
            spell.EffectPointsPerLevel[0] = 0;
            spell.EffectPointsPerLevel[1] = 0;
            spell.EffectPointsPerLevel[2] = 0;
            spell.EffectBasePoints[0] = 0;
            spell.EffectBasePoints[1] = 0;
            spell.EffectBasePoints[2] = 0;
            spell.EffectMechanic[0] = 0;
            spell.EffectMechanic[1] = 0;
            spell.EffectMechanic[2] = 0;
            spell.EffectTargetA[0] = 0;
            spell.EffectTargetA[1] = 0;
            spell.EffectTargetA[2] = 0;
            spell.EffectTargetB[0] = 0;
            spell.EffectTargetB[1] = 0;
            spell.EffectTargetB[2] = 0;
            spell.EffectRadius[0] = 0;
            spell.EffectRadius[1] = 0;
            spell.EffectRadius[2] = 0;
            spell.EffectApplyAura[0] = 0;
            spell.EffectApplyAura[1] = 0;
            spell.EffectApplyAura[2] = 0;
            spell.EffectAmplitude[0] = 0;
            spell.EffectAmplitude[1] = 0;
            spell.EffectAmplitude[2] = 0;
            spell.EffectMultipleValue[0] = 0;
            spell.EffectMultipleValue[1] = 0;
            spell.EffectMultipleValue[2] = 0;
            spell.EffectChainTargets[0] = 0;
            spell.EffectChainTargets[1] = 0;
            spell.EffectChainTargets[2] = 0;
            spell.EffectItemType[0] = 0;
            spell.EffectItemType[1] = 0;
            spell.EffectItemType[2] = 0;
            spell.EffectMisc[0] = 0;
            spell.EffectMisc[1] = 0;
            spell.EffectMisc[2] = 0;
            spell.EffectMiscB[0] = 0;
            spell.EffectMiscB[1] = 0;
            spell.EffectMiscB[2] = 0;
            spell.EffectTriggerSpell[0] = 0;
            spell.EffectTriggerSpell[1] = 0;
            spell.EffectTriggerSpell[2] = 0;
            spell.EffectPointsPerComboPoint[0] = 0;
            spell.EffectPointsPerComboPoint[1] = 0;
            spell.EffectPointsPerComboPoint[2] = 0;
            spell.EffectSpellMaskA[0] = 0;
            spell.EffectSpellMaskA[1] = 0;
            spell.EffectSpellMaskA[2] = 0;
            spell.EffectSpellMaskB[0] = 0;
            spell.EffectSpellMaskB[1] = 0;
            spell.EffectSpellMaskB[2] = 0;
            spell.EffectSpellMaskC[0] = 0;
            spell.EffectSpellMaskC[1] = 0;
            spell.EffectSpellMaskC[2] = 0;
            spell.Visual[0] = 0;
            spell.Visual[1] = 0;
            spell.Icon = 0;
            spell.ActiveIcon = 0;
            spell.Priority = 0;
            spell.Name = "";
            spell.NameFlags = 0;
            spell.Rank = "";
            spell.RankFlags = 0;
            spell.Description = "";
            spell.DescriptionFlags = 0;
            spell.ToolTip = "";
            spell.ToolTipFlags = 0;
            spell.PowerCostPercent = 0;
            spell.GlobalCategory = 0;
            spell.GlobalCooldown = 0;
            spell.MaxTargetLevel = 0;
            spell.Family = 0;
            spell.FamilyMaskA = 0;
            spell.FamilyMaskB = 0;
            spell.FamilyMaskC = 0;
            spell.MaxAffectTargets = 0;
            spell.DamageClass = 0;
            spell.PreventionType = 0;
            spell.StanceBarOrder = 0;
            spell.EffectDamageMultiplier[0] = 0;
            spell.EffectDamageMultiplier[1] = 0;
            spell.EffectDamageMultiplier[2] = 0;
            spell.MinFaction = 0;
            spell.MinReputation = 0;
            spell.RequiredAuraVision = 0;
            spell.TotemCategory[0] = 0;
            spell.TotemCategory[1] = 0;
            spell.AreaGroup = 0;
            spell.SchoolMask = 0;
            spell.RuneCost = 0;
            spell.Missile = 0;
            spell.PowerDisplay = 0;
            spell.EffectBonusMultiplier[0] = 0;
            spell.EffectBonusMultiplier[1] = 0;
            spell.DescriptionVariable = 0;
            spell.Difficulty = 0;
            spells.Add(spell);
            return spell;
        }

        private void deleteSpell_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            spells.Remove(spell);
        }

        private void UpdateItemListFilter()
        {
            spellList.Items.Filter = delegate(object obj)
            {
                string name = spellFilter.Text;
                if (name == "")
                    return true;
                SpellTemplate spell = (SpellTemplate)obj;
                return spell.Name.Contains(name) || spell.ID.ToString().Contains(name);
            };
        }

        private void spellFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateItemListFilter();
        }

        private void addToSkill811Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 811);
        }

        private void AddToSkill(int spell, int skill/*, int race = 0, int _class = 0*/)
        {
            if (SkillLinePanel.SkillLineAbilities == null)
                return;

            var sk = (from d in SkillLinePanel.SkillLineAbilities where d.Spell == spell select d).SingleOrDefault();

            if (sk != null)
                sk.Skill = skill;
            else
            {
                SkillLinePanel.SkillLineAbilities.Add(new SkillLineAbility()
                {
                    ID = (from d in SkillLinePanel.SkillLineAbilities select d.ID).Max() + 1,
                    Skill = skill,
                    Spell = spell,
                    Race = 0,
                    Class = 0,
                    RequiredSkillValue = 1,
                    SupercededBySpell = 0,
                    AccquiredMethod = 0,
                    SkillLineRankHigh = 0,
                    SkillLineRankLow = 0
                });
            }

            SkillLinePanel.SaveDBC();
        }

        private void addToSkill812Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 812);
        }

        private void addToSkill813Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 813);
        }

        private void school_Click(object sender, RoutedEventArgs e)
        {
            UpdateSchoolMask();
        }

        private void UpdateSchoolMask()
        {
            if (spellList.SelectedItem == null)
                return;
            uint flags = 0;
            if (school1.IsChecked == true)
                flags += 1;
            if (school2.IsChecked == true)
                flags += 2;
            if (school3.IsChecked == true)
                flags += 4;
            if (school4.IsChecked == true)
                flags += 8;
            if (school5.IsChecked == true)
                flags += 16;
            if (school6.IsChecked == true)
                flags += 32;
            if (school7.IsChecked == true)
                flags += 64;
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            spell.SchoolMask = flags;
        }

        private void UpdatePreventionTypeMask()
        {
            if (spellList.SelectedItem == null)
                return;
            uint flags = 0;
            if (preventionType1.IsChecked == true)
                flags += 1;
            if (preventionType2.IsChecked == true)
                flags += 2;
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            spell.SchoolMask = flags;
        }

        private void preventionType_Click(object sender, RoutedEventArgs e)
        {
            UpdatePreventionTypeMask();
        }

        private void selectFamilyMask_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellFamilySelector(spell, 0).Show();
        }

        private void selectEffectMask1_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellFamilySelector(spell, 1).Show();
        }

        private void selectEffectMask3_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellFamilySelector(spell, 3).Show();
        }

        private void selectEffectMask2_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellFamilySelector(spell, 2).Show();
        }

        private void spellProc_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellProcSelector(spell).Show();
        }

        private void spellCastInterrupt_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellCastInterruptSelector(spell).Show();
        }

        private void auraInterrupt_Click(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = spellList.SelectedItem as SpellTemplate;
            new SpellAuraInterruptSelector(spell).Show();
        }

        private void addToSkill129Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 129);
        }

        private void addToSkill164Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 164);
        }

        private void addToSkill165Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 165);
        }

        private void addToSkill171Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 171);
        }

        private void addToSkill182Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 182);
        }

        private void addToSkill185Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 185);
        }

        private void addToSkill186Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 186);
        }

        private void addToSkill197Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 197);
        }

        private void addToSkill202Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 202);
        }

        private void addToSkill333Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 333);
        }

        private void addToSkill356Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 356);
        }

        private void addToSkill393Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 393);
        }

        private void addToSkill755Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 755);
        }

        private void addToSkill773Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 773);
        }

        private void addToSkill789Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 789);
        }

        private void addToSkill790Btn_Click(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 790);
        }

        private void spellSave_Click(object sender, RoutedEventArgs e)
        {
            WriteSpellDBC(spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc" });
            WriteClientDBC(spells, MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc");
        }

        private void ModRating()
        {
            foreach (var spell in spells)
            {
                for (int i=0; i!=3; i++)
                {
                    if (spell.EffectApplyAura[i] == 189)
                    {
                        spell.EffectBasePoints[i] = 0;
                        spell.EffectDieSides[i] = 1;
                    }
                }
            }
            WriteSpellDBC(spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc", MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc" });
        }

        private void ModInterrupt()
        {
            var spelllist = from d in spells where d.ID >= 81242 select d;
            foreach (var spell in spelllist)
            {
                if (spell.Attributes[0] == 0x10030)
                {
                    spell.ProcChance = 100;
                    spell.InterruptFlags = 17;
                }
            }
            WriteSpellDBC(spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc", MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc" });
        }

        private void FlushSpells()
        {
            foreach (var spell in spells)
            {
                for (int i = 0; i != 3; ++i)
                {
                    if (spell.Effect[i] > 164) spell.Effect[i] = 0;
                    if (spell.EffectApplyAura[i] > 316) spell.EffectApplyAura[i] = 0;
                }
            }
            WriteSpellDBC(spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc", MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc" });
        }

        private static int ReplaceEffect(int effect)
        {
            if (effect < 165)
                return effect;
            return 3;
        }

        private static int ReplaceAura(int aura)
        {
            if (aura < 317)
                return aura;
            return 4;
        }

        private void CopySpells()
        {
            ObservableCollection<SpellTemplate> original_spells = new ObservableCollection<SpellTemplate>();
            ObservableCollection<SpellTemplate> new_spells = new ObservableCollection<SpellTemplate>();
            LoadSpellDBC(ref original_spells, "Spell_A.dbc");
            LoadSpellDBC(ref new_spells, "Spell_B.dbc");
            var new_sp = from d in original_spells where d.ID > 80865 select d;
            foreach (var n in new_sp)
                new_spells.Add(n);
            WriteSpellDBC(new_spells, new List<string>() { "Spell_New.dbc" });
        }

        private void addToSkill795Btn_Checked(object sender, RoutedEventArgs e)
        {
            var spell = spellList.SelectedValue as SpellTemplate;
            int entry = (int)spell.ID;
            AddToSkill(entry, 795);
        }
    }
}
