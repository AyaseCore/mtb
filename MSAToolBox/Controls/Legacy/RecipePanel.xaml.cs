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
    /// RecipePanel.xaml 的交互逻辑
    /// </summary>
    public partial class RecipePanel : UserControl
    {
        public static RecipePanel self;
        private List<ProfessionDefine> PDefines;
        public RecipePanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            self = this;
            InitDefine();
            rt1.DisplayMemberPath = "Value";
            rt1.SelectedValuePath = "Key";
            rt2.DisplayMemberPath = "Value";
            rt2.SelectedValuePath = "Key";
            rt1.ItemsSource = LegacyMorpher.DefineStore.TotemCategory;
            rt2.ItemsSource = LegacyMorpher.DefineStore.TotemCategory;
        }

        private void InitDefine()
        {
            PDefines = new List<ProfessionDefine>();
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 164,
                Name = "锻造学",
                Prefix = "设计图：",
                DisplayID = 129385,
                SpellVisual = 395,
                SpellIcon = 1,
                TotemCategory1 = 162,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 1,
                RecipeSubClass = 4
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 165,
                Name = "制铠术",
                Prefix = "图纸：",
                DisplayID = 129386,
                SpellVisual = 395,
                SpellIcon = 1,
                TotemCategory1 = 162,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 1,
                RecipeSubClass = 1
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 171,
                Name = "炼金术",
                Prefix = "配方：",
                DisplayID = 129390,
                SpellVisual = 92,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 633,
                RecipeSubClass = 6
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 185,
                Name = "烹饪学",
                Prefix = "食谱：",
                DisplayID = 129389,
                SpellVisual = 3881,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 4,
                RecipeSubClass = 5
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 197,
                Name = "制衣术",
                Prefix = "图样：",
                DisplayID = 129387,
                SpellVisual = 1168,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 57048,
                Totem2 = 0,
                SpellFocus = 2,
                RecipeSubClass = 2
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 202,
                Name = "工程学",
                Prefix = "蓝图：",
                DisplayID = 129388,
                SpellVisual = 395,
                SpellIcon = 1,
                TotemCategory1 = 14,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 1653,
                RecipeSubClass = 3
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 333,
                Name = "附魔术",
                Prefix = "公式：",
                DisplayID = 129444,
                SpellVisual = 0,
                SpellIcon = 0,
                TotemCategory1 = 6,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 1651,
                RecipeSubClass = 8
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 755,
                Name = "宝石学",
                Prefix = "图鉴：",
                DisplayID = 129445,
                SpellVisual = 7373,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 20815,
                Totem2 = 0,
                SpellFocus = 1652,
                RecipeSubClass = 10
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 129,
                Name = "急救术",
                Prefix = "手册：",
                DisplayID = 129446,
                SpellVisual = 0,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 7
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 186,
                Name = "勘探学",
                Prefix = "手记：",
                DisplayID = 129447,
                SpellVisual = 390,
                SpellIcon = 0,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 3,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 773,
                Name = "铭文学",
                Prefix = "铭文：",
                DisplayID = 129456,
                SpellVisual = 10130,
                SpellIcon = 0,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 39505,
                Totem2 = 0,
                SpellFocus = 1589,
                RecipeSubClass = 11
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 632,
                Name = "制毒",
                Prefix = "密函：",
                DisplayID = 129448,
                SpellVisual = 12720,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 790,
                Name = "探索与历险",
                Prefix = "卷轴：",
                DisplayID = 129452,
                SpellVisual = 1168,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 852,
                Name = "制弓",
                Prefix = "构图：",
                DisplayID = 129449,
                SpellVisual = 10130,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 853,
                Name = "御法",
                Prefix = "法则：",
                DisplayID = 129454,
                SpellVisual = 7749,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 854,
                Name = "塑魔",
                Prefix = "秘典：",
                DisplayID = 129450,
                SpellVisual = 7749,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            PDefines.Add(new ProfessionDefine()
            {
                SkillLine = 855,
                Name = "封咒",
                Prefix = "书卷：",
                DisplayID = 129455,
                SpellVisual = 7749,
                SpellIcon = 1,
                TotemCategory1 = 0,
                TotemCategory2 = 0,
                Totem1 = 0,
                Totem2 = 0,
                SpellFocus = 0,
                RecipeSubClass = 0
            });
            type.DisplayMemberPath = "Name";
            type.SelectedValuePath = "SkillLine";
            type.ItemsSource = PDefines;
            type.DisplayMemberPath = "Name";
            type.SelectedValuePath = "SkillLine";
            type.ItemsSource = PDefines;
        }

        private void SaveRecipe()
        {
            // save spell
            SpellTemplate spell = SpellPanel.CreateNewSpell();
            recipeSpellEntry.Text = spell.ID.ToString();
            ProfessionDefine define = type.SelectedItem as ProfessionDefine;
            spell.Attributes[0] = 0x10030;
            spell.Attributes[1] = 0x400;
            spell.Icon = (uint)define.SpellIcon;
            spell.Visual[0] = (uint)define.SpellVisual;
            spell.Name = recipeItemName.Text;
            spell.CastingTime = 22; // 3.5 sec
            spell.InterruptFlags = 17;
            spell.ProcChance = 101;
            spell.TotemCategory[0] = Convert.ToInt32(rt1.SelectedValue);
            spell.TotemCategory[1] = Convert.ToInt32(rt2.SelectedValue);
            spell.Totem[0] = Convert.ToInt32(rti1.Text);
            spell.Totem[1] = Convert.ToInt32(rti2.Text);
            spell.RequiredSpellFocus = Convert.ToUInt32(rf.Text);
            spell.Effect[0] = 24;
            spell.EffectTargetA[0] = 1;
            spell.EffectItemType[0] = Convert.ToUInt32(i1i.Text);
            spell.EffectBasePoints[0] = Convert.ToInt32(i1c.Text) - 1;
            spell.EffectDieSides[0] = 1;
            spell.Reagent[0] = Convert.ToInt32(r1i.Text);
            spell.Reagent[1] = Convert.ToInt32(r2i.Text);
            spell.Reagent[2] = Convert.ToInt32(r3i.Text);
            spell.Reagent[3] = Convert.ToInt32(r4i.Text);
            spell.Reagent[4] = Convert.ToInt32(r5i.Text);
            spell.Reagent[5] = Convert.ToInt32(r6i.Text);
            spell.Reagent[6] = Convert.ToInt32(r7i.Text);
            spell.Reagent[7] = Convert.ToInt32(r8i.Text);
            spell.ReagentCount[0] = Convert.ToUInt32(r1c.Text);
            spell.ReagentCount[1] = Convert.ToUInt32(r2c.Text);
            spell.ReagentCount[2] = Convert.ToUInt32(r3c.Text);
            spell.ReagentCount[3] = Convert.ToUInt32(r4c.Text);
            spell.ReagentCount[4] = Convert.ToUInt32(r5c.Text);
            spell.ReagentCount[5] = Convert.ToUInt32(r6c.Text);
            spell.ReagentCount[6] = Convert.ToUInt32(r7c.Text);
            spell.ReagentCount[7] = Convert.ToUInt32(r8c.Text);

            SpellPanel.WriteSpellDBC(SpellPanel.spells, new List<string>() { MainWindow.SERVER_PATH + "dbc/Spell.dbc", MainWindow.CLIENT_PATH + "DBFilesClient/Spell.dbc" });

            // save item - only recipe.
            ItemTemplate item = LegacyWorld.CreateItemTemplate();
            item.Name = define.Prefix + recipeItemName.Text;
            item.Description = "教你学会制作" + recipeItemName.Text + "。";
            item.DisplayID = define.DisplayID;
            item.RequiredSkill = define.SkillLine;
            item.RequiredSkillRank = Convert.ToInt32(rs.Text);
            item.Class = 9;
            item.Subclass = define.RecipeSubClass;
            item.AllowableClass = -1;
            item.AllowableRace = -1;
            item.Flags = 64;
            item.Quality = 1;
            item.Spell[0] = 483;
            item.SpellTrigger[0] = 0;
            item.SpellCharges[0] = -1;
            item.Spell[1] = Convert.ToInt32(recipeSpellEntry.Text);
            item.SpellTrigger[1] = 6;
            LegacyWorld.SaveItemTemplate(item, false);

            // save skillline
            SkillLinePanel.AddToSkill((int)spell.ID, Convert.ToInt32(type.SelectedValue), Convert.ToInt32(recipeRequiredSkillValue.Text), Convert.ToInt32(recipeSkillGoYellow.Text), Convert.ToInt32(recipeSkillGoGray.Text));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveRecipe();
        }

        private void i1f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == recipeItemName.Text select d.Entry).FirstOrDefault();
            i1i.Text = item.ToString();
        }

        private void r1f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r1.Text select d.Entry).FirstOrDefault();
            r1i.Text = item.ToString();
        }

        private void r2f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r2.Text select d.Entry).FirstOrDefault();
            r2i.Text = item.ToString();
        }

        private void r3f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r3.Text select d.Entry).FirstOrDefault();
            r3i.Text = item.ToString();
        }

        private void r4f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r4.Text select d.Entry).FirstOrDefault();
            r4i.Text = item.ToString();
        }

        private void r5f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r5.Text select d.Entry).FirstOrDefault();
            r5i.Text = item.ToString();
        }

        private void r6f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r6.Text select d.Entry).FirstOrDefault();
            r6i.Text = item.ToString();
        }

        private void r7f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r7.Text select d.Entry).FirstOrDefault();
            r7i.Text = item.ToString();
        }

        private void r8f_Click(object sender, RoutedEventArgs e)
        {
            int item = (from d in ItemPanel.ItemList where d.Name == r8.Text select d.Entry).FirstOrDefault();
            r8i.Text = item.ToString();
        }

        public void AddItem(string name, int item)
        {
            recipeItemName.Text = name;
            i1i.Text = item.ToString();
        }

        public void AddReagent(string name, int item, int index = 0)
        {
            switch (index)
            {
                case 0:
                    r1.Text = name;
                    r1i.Text = item.ToString();
                    break;
                case 1:
                    r2.Text = name;
                    r2i.Text = item.ToString();
                    break;
                case 2:
                    r3.Text = name;
                    r3i.Text = item.ToString();
                    break;
                case 3:
                    r4.Text = name;
                    r4i.Text = item.ToString();
                    break;
                case 4:
                    r5.Text = name;
                    r5i.Text = item.ToString();
                    break;
                case 5:
                    r6.Text = name;
                    r6i.Text = item.ToString();
                    break;
                case 6:
                    r7.Text = name;
                    r7i.Text = item.ToString();
                    break;
                case 7:
                    r8.Text = name;
                    r8i.Text = item.ToString();
                    break;
                case -1:
                    if (r1i.Text == "0")
                    {
                        r1.Text = name;
                        r1i.Text = item.ToString();
                    }
                    else if (r2i.Text == "0")
                    {
                        r2.Text = name;
                        r2i.Text = item.ToString();
                    }
                    else if (r3i.Text == "0")
                    {
                        r3.Text = name;
                        r3i.Text = item.ToString();
                    }
                    else if (r4i.Text == "0")
                    {
                        r4.Text = name;
                        r4i.Text = item.ToString();
                    }
                    else if (r5i.Text == "0")
                    {
                        r5.Text = name;
                        r5i.Text = item.ToString();
                    }
                    else if (r6i.Text == "0")
                    {
                        r6.Text = name;
                        r6i.Text = item.ToString();
                    }
                    else if (r7i.Text == "0")
                    {
                        r7.Text = name;
                        r7i.Text = item.ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProfessionDefine define = type.SelectedItem as ProfessionDefine;
            rt1.SelectedValue = define.TotemCategory1;
            rt2.SelectedValue = define.TotemCategory2;
            rti1.Text = define.Totem1.ToString();
            rti2.Text = define.Totem2.ToString();
            rf.Text = define.SpellFocus.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            self.AddReagent("fuckyou", 1234);
        }
    }

    public class ProfessionDefine
    {
        public int SkillLine { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int DisplayID { get; set; }
        public int SpellVisual { get; set; }
        public int SpellIcon { get; set; }
        public int TotemCategory1 { get; set; }
        public int TotemCategory2 { get; set; }
        public int Totem1 { get; set; }
        public int Totem2 { get; set; }
        public int SpellFocus { get; set; }
        public int RecipeSubClass { get; set; }
    }
}
