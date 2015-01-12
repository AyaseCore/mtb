using System;
using System.Collections.Generic;
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
using MSAToolBox.Utility;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// SpellAttributesPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SpellAttributesPanel : UserControl
    {
        private SpellTemplate _spell;
        private List<CheckBox> attr;
        private List<CheckBox> attrEx;
        private List<CheckBox> attrEx2;
        private List<CheckBox> attrEx3;
        private List<CheckBox> attrEx4;
        private List<CheckBox> attrEx5;
        private List<CheckBox> attrEx6;
        private List<CheckBox> attrEx7;

        public void Load(SpellTemplate spell)
        {
            if (spell == null)
                return;
            _spell = spell;
            for (int i = 0; i != 32; ++i)
            {
                attr[i].IsChecked = (_spell.Attributes[0] & (1 << i)) != 0;
                attrEx[i].IsChecked = (_spell.Attributes[1] & (1 << i)) != 0;
                attrEx2[i].IsChecked = (_spell.Attributes[2] & (1 << i)) != 0;
                attrEx3[i].IsChecked = (_spell.Attributes[3] & (1 << i)) != 0;
                attrEx4[i].IsChecked = (_spell.Attributes[4] & (1 << i)) != 0;
                attrEx5[i].IsChecked = (_spell.Attributes[5] & (1 << i)) != 0;
                attrEx6[i].IsChecked = (_spell.Attributes[6] & (1 << i)) != 0;
                attrEx7[i].IsChecked = (_spell.Attributes[7] & (1 << i)) != 0;
            }
        }

        private static string[] sAttr = {
            "UNKNOWN 0", 
            "ON NEXT RANGED",
            "ON NEXT SWING (PLAYER)",
            "IS REPLENISHMENT",
            "ABILITY",
            "TRADE SPELL",
            "PASSIVE SPELL",
            "HIDDEN CLIENT-SIDE",
            "HIDE IN COMBAT LOG",
            "TARGET MAIN-HAND ITEM",
            "ON NEXT SWING (NPCS)",
            "UNKNOWN 11",
            "DAYTIME ONLY",
            "NIGHT ONLY",
            "INDOORS ONLY",
            "OUTDOORS ONLY",
            "NO SHAPESHIFT",
            "REQUIRES STEALTH",
            "DON'T AFFECT SHEATH STATE",
            "SPELL DAMAGE DEPENDS ON CASTER LEVEL",
            "STOPS AUTO-ATTACK",
            "IMPOSSIBLE TO DODGE PARRY OR BLOCK",
            "TRACK TARGET WHILE CASTING",
            "CASTABLE WHILE DEAD",
            "CASTABLE WHILE MOUNTED",
            "START COOLDOWN AFTER AURA FADES",
            "NEGATIVE",
            "CASTABLE WHILE SITTING",
            "CANNOT BE USED IN COMBAT",
            "UNAFFECTED BY INVULNERABILITY",
            "BREAKABLE BY DAMAGE",
            "AURA CANNOT BE CANCELLED"
        };
        private static string[] sAttrEx = {
            "DISMISS PET",
            "DRAINS ALL POWER",
            "CHANNELED 1",
            "CANNOT BE REDIRECTED",
            "UNKNOWN 4",
            "DOES NOT BREAK STEALTH",
            "CHANNELED 2",
            "CANNOT BE REFLECTED",
            "CANNOT TARGET IN COMBAT",
            "MELEE COMBAT START",
            "GENERATES NO THREAT",
            "UNKNOWN 11",
            "PICKPOCKET",
            "FAR SIGHT",
            "TRACK TARGET WHILE CHANNELING",
            "REMOVE AURAS ON IMMUNITY",
            "UNAFFECTED BY SCHOOL IMMUNE",
            "UNAUTOSCALABLE BY PET",
            "STUN, POLYMORPH, DAZE, HEX",
            "CANNOT TARGET SELF",
            "REQUIRES COMBO POINTS ON TARGET 1",
            "UNKNOWN 21",
            "REQUIRED COMBO POINTS ON TARGET 2",
            "UNKNOWN 23",
            "FISHING",
            "UNKNOWN 25",
            "FOCUS TARGETING MACRO",
            "UNKNOWN 27",
            "HIDDEN IN AURA BAR",
            "CHANNEL DISPLAY NAME",
            "ENABLE SPELL WHEN DODGED",
            "UNKNOWN 31"
        };
        private static string[] sAttrEx2 = {
            "CAN TARGET DEAD UNIT OR CORPSE",
            "VANISH, SHADOWFORM, GHOST",
            "CAN TARGET NOT IN LINE OF SIGHT",
            "UNKNOWN 3",
            "DISPLAY IN STANCE BAR",
            "AUTOREPEAT FLAG",
            "REQUIRES UNTAPPED TARGET",
            "UNKNOWN 7",
            "UNKNOWN 8",
            "UNKNOWN 9",
            "UNKNOWN 10 (TAME)",
            "HEALTH FUNNEL",
            "CLEAVE, HEART STRIKE, MAUL, SUNDER ARMOR, SWIPE",
            "PRESERVE ENCHANT IN ARENA",
            "UNKNOWN 14",
            "UNKNOWN 15",
            "TAME BEAST",
            "DON'T RESET AUTO ACTIONS",
            "REQUIRES DEAD PET",
            "DON'T NEED SHAPESHIFT",
            "UNKNOWN 20",
            "DAMAGE REDUCED SHIELD",
            "AMBUSH, BACKSTAB, CHEAP SHOT, DEATH GRIP, GARROTE, JUDGEMENTS, MUTILATE, POUNCE, RAVAGE, SHIV, SHRED",
            "ARCANE CONCENTRATION",
            "UNKNOWN 24",
            "UNKNOWN 25",
            "UNAFFECTED BY SCHOOL IMMUNITY",
            "REQUIRES FISHING POLE",
            "UNKNOWN 28",
            "CANNOT CRIT",
            "TRIGGERED CAN TRIGGER PROC",
            "FOOD BUFF"
        };
        private static string[] sAttrEx3 = {
            "UNKNOWN 0",
            "UNKNOWN 1",
            "UNKNOWN 2",
            "BLOCKABLE SPELL",
            "IGNORE RESURRECTION TIMER",
            "UNKNOWN 5",
            "UNKNOWN 6",
            "STACK FOR DIFFERENT CASTERS",
            "ONLY TARGET PLAYERS",
            "TRIGGERED CAN TRIGGER PROC 2",
            "REQUIRES MAIN-HAND",
            "BATTLEGROUND ONLY",
            "ONLY TARGET GHOSTS",
            "HIDE CHANNEL BAR",
            "HONORLESS TARGET",
            "AUTO-SHOOT",
            "CANNOT TRIGGER PROC",
            "NO INITIAL AGGRO",
            "CANNOT MISS",
            "DISABLE PROCS",
            "DEATH PERSISTENT",
            "UNKNOWN 21",
            "REQUIRES WANDS",
            "UNKNOWN 23",
            "REQUIRES OFF-HAND",
            "UNKNOWN 25",
            "CAN PROC WITH TRIGGERED",
            "DRAIN SOUL",
            "UNKNOWN 28",
            "NO DONE BONUS",
            "DO NOT DISPLAY RANGE",
            "UNKNOWN 31"
        };
        private static string[] sAttrEx4 = {
            "IGNORE ALL REISTANCES",
            "PROC ONLY ON CASTER",
            "CONTINUE TO TICK WHILE OFFLINE",
            "UNKNOWN 3",
            "UNKNOWN 4",
            "UNKNOWN 5",
            "NOT STEALABLE",
            "TRIGGERED",
            "FIXED DAMAGE",
            "ACTIVATE FROM EVENT",
            "SPELL VS EXTENDED COST",
            "UNKNOWN 11",
            "UNKNOWN 12",
            "UNKNOWN 13",
            "DAMAGE DOESN'T BREAK AURAS",
            "UNKNOWN 15",
            "NOT USABLE IN ARENA",
            "USABLE IN ARENA",
            "AREA TARGET CHAIN",
            "UNKNOWN 19",
            "DON'T CHECK SELFCAST POWER",
            "UNKNOWN 21",
            "UNKNOWN 22",
            "UNKNOWN 23",
            "UNKNOWN 24",
            "PET SCALING",
            "CAN ONLY BE CASTED IN OUTLAND",
            "UNKNOWN 27",
            "AIMED SHOT",
            "UNKNOWN 29",
            "UNKNOWN 30",
            "POLYMORPH"
        };
        private static string[] sAttrEx5 = {
            "UNKNOWN 0",
            "NO REAGENT WHILE PREPARATION",
            "UNKNOWN 2",
            "USABLE WHILE STUNNED",
            "UNKNOWN 4",
            "SINGLE-TARGET SPELL",
            "UNKNOWN 6",
            "UNKNOWN 7",
            "UNKNOWN 8",
            "START PERIODIC AT AURA APPLY",
            "HIDE DURATION",
            "ALLOW TARGET OF TARGET AS TARGET",
            "CLEAVE",
            "HASTE AFFECT DURATION",
            "UNKNOWN 14",
            "INFLICT ON MULTIPLE TARGETS",
            "SPECIAL ITEM CLASS CHECK",
            "USABLE WHILE FEARED",
            "USABLE FEARED CONFUSED",
            "DON'T TURN DURING CASTING",
            "UNKNOWN 20",
            "UNKNOWN 21",
            "UNKNOWN 22",
            "UNKNOWN 23",
            "UNKNOWN 24",
            "UNKNOWN 25",
            "UNKNOWN 26",
            "DON'T SHOW AURA IF SELF-CAST",
            "DON'T SHOW AURA IF NOT SELF-CAST",
            "UNKNOWN 29",
            "UNKNOWN 30",
            "AOE TAUNT"
        };
        private static string[] sAttrEx6 = {
            "DON'T DISPLAY COOLDOWN",
            "ONLY IN ARENA",
            "IGNORE CASTER AURAS",
            "ASSIST IGNORE IMMUNE FLAG",
            "UNKNOWN 4",
            "UNKNOWN 5",
            "SPELL CAST EVENT",
            "UNKNOWN 7",
            "CAN'T TARGET CROWD-CONTROLLED",
            "UNKNOWN 9",
            "CAN TARGET POSSESSED FRIENDS",
            "NOT IN RAID INSTANCE",
            "CASTABLE WHILE ON VEHICLE",
            "CAN TARGET INVISIBLE",
            "UNKNOWN 14",
            "UNKNOWN 15",
            "UNKNOWN 16",
            "MOUNT",
            "CAST BY CHARMER",
            "UNKNOWN 19",
            "ONLY VISIBLE TO CASTER",
            "CLIENT UI TARGET EFFECTS",
            "UNKNOWN 22",
            "UNKNOWN 23",
            "CAN TARGET UNTARGETABLE",
            "EXORCISM, FLASH OF LIGHT",
            "UNKNOWN 26",
            "UNKNOWN 27",
            "DEATH GRIP",
            "NOT DONE PERCENT DAMAGE MODS",
            "UNKNOWN 30",
            "IGNORE CATEGORY COOLDOWN MODS"
        };
        private static string[] sAttrEx7 = {
            "FEIGN DEATH",
            "UNKNOWN 1",
            "RE-ACTIVATE AT RESURRECT",
            "CHEAT SPELL",
            "SOULSTONE RESURRECTION",
            "TOTEM",
            "NO PUSHBACK ON DAMAGE",
            "UNKNOWN 7",
            "HORDE ONLY",
            "ALLIANCE ONLY",
            "DISPEL CHARGES",
            "INTERRUPT ONLY NON-PLAYER",
            "UNKNOWN 12",
            "UNKNOWN 13",
            "RAISE DEAD",
            "UNKNOWN 15",
            "RESTORE SECONDARY POWER",
            "UNKNOWN 17",
            "CHARGE",
            "ZONE TELEPORT",
            "BLINK, DIVINE SHIELD, ICE BLOCK",
            "UNKNOWN 21",
            "UNKNOWN 22",
            "UNKNOWN 23",
            "UNKNOWN 24",
            "UNKNOWN 25",
            "UNKNOWN 26",
            "UNKNOWN 27",
            "CONSOLIDATED RAID BUFF",
            "UNKNOWN 29",
            "UNKNOWN 30",
            "CLIENT INDICATOR"
        };

        public SpellAttributesPanel()
        {
            InitializeComponent();
            InitAttributesPanel();
        }

        private void InitAttributesPanel()
        {
            attr = new List<CheckBox>();
            foreach (string s in sAttr)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR0)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attr_Click;
                attrPanel.Children.Add(c);
                attr.Add(c);
            }

            attrEx = new List<CheckBox>();
            foreach (string s in sAttrEx)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR1)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx_Click;
                attrExPanel.Children.Add(c);
                attrEx.Add(c);
            }

            attrEx2 = new List<CheckBox>();
            foreach (string s in sAttrEx2)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR2)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx2_Click;
                attrEx2Panel.Children.Add(c);
                attrEx2.Add(c);
            }

            attrEx3 = new List<CheckBox>();
            foreach (string s in sAttrEx3)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR3)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx3_Click;
                attrEx3Panel.Children.Add(c);
                attrEx3.Add(c);
            }

            attrEx4 = new List<CheckBox>();
            foreach (string s in sAttrEx4)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR4)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx4_Click;
                attrEx4Panel.Children.Add(c);
                attrEx4.Add(c);
            }

            attrEx5 = new List<CheckBox>();
            foreach (string s in sAttrEx5)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR5)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx5_Click;
                attrEx5Panel.Children.Add(c);
                attrEx5.Add(c);
            }

            attrEx6 = new List<CheckBox>();
            foreach (string s in sAttrEx6)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR6)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx6_Click;
                attrEx6Panel.Children.Add(c);
                attrEx6.Add(c);
            }

            attrEx7 = new List<CheckBox>();
            foreach (string s in sAttrEx7)
            {
                CheckBox c = new CheckBox();
                c.Content = "(ATRR7)" + s;
                c.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                c.Click += attrEx7_Click;
                attrEx7Panel.Children.Add(c);
                attrEx7.Add(c);
            }
        }

        private void attr_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attr.Count; ++i)
            {
                if (attr[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[0] = flags;
        }

        private void attrEx_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx.Count; ++i)
            {
                if (attrEx[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[1] = flags;
        }

        private void attrEx2_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx2.Count; ++i)
            {
                if (attrEx2[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[2] = flags;
        }

        private void attrEx3_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx3.Count; ++i)
            {
                if (attrEx3[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[3] = flags;
        }

        private void attrEx4_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx4.Count; ++i)
            {
                if (attrEx[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[4] = flags;
        }

        private void attrEx5_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx5.Count; ++i)
            {
                if (attrEx5[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[5] = flags;
        }

        private void attrEx6_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx6.Count; ++i)
            {
                if (attrEx6[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[6] = flags;
        }

        private void attrEx7_Click(object sender, RoutedEventArgs e)
        {
            if (_spell == null)
                return;
            uint flags = 0;
            for (int i = 0; i != attrEx7.Count; ++i)
            {
                if (attrEx7[i].IsChecked == true)
                    flags += (uint)Math.Pow(2, i);
            }

            _spell.Attributes[7] = flags;
        }
    }
}
