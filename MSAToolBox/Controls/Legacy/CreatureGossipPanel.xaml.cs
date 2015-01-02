using MSAToolBox.LegacyServices;
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
using System.Threading;
using System.Windows.Media.Animation;
using MSAToolBox.SubWindows.Legacy;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// LegacyCreatureGossipControl.xaml 的交互逻辑
    /// </summary>
    public partial class CreatureGossipPanel : UserControl
    {
        private Dictionary<int, string> LanguageDefines;
        private Dictionary<int, string> MenuOptionTypes;
        private Dictionary<int, string> GossipIconDefines;
        private GossipMenu GossipData;
        private bool IsLoading;
        public static Dictionary<int, string> CreatureNames;
        private GossipNavigator GossipNavigation;
        private const int MAX_GOSSIP_ITEM = 32;
        private Dictionary<int, string> Emotes;

        public CreatureGossipPanel()
        {
            InitializeComponent();
            InitDefines();
        }

        private void AssignDefine(ComboBox c, Dictionary<int, string> dict)
        {
            this.Dispatcher.Invoke(() =>
            {
                c.SelectedValuePath = "Key";
                c.DisplayMemberPath = "Value";
                c.ItemsSource = dict;
                c.SelectedIndex = 0;
            });
        }

        private void InitDefines()
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    LanguageDefines = client.GetLanguages();
                    MenuOptionTypes = client.GetGossipMenuOptionTypes();
                    GossipIconDefines = client.GetGossipIconDefines();
                    CreatureNames = client.GetCreatureNames();
                    Emotes = client.GetEmotes();
                    AssignDefine(gossipNpcTextLanguage, LanguageDefines);
                    AssignDefine(gossipOptionType1, MenuOptionTypes);
                    AssignDefine(gossipOptionType2, MenuOptionTypes);
                    AssignDefine(gossipOptionType3, MenuOptionTypes);
                    AssignDefine(gossipOptionType4, MenuOptionTypes);
                    AssignDefine(gossipOptionType5, MenuOptionTypes);
                    AssignDefine(gossipOptionType6, MenuOptionTypes);
                    AssignDefine(gossipOptionType7, MenuOptionTypes);
                    AssignDefine(gossipOptionType8, MenuOptionTypes);
                    AssignDefine(gossipOptionType9, MenuOptionTypes);
                    AssignDefine(gossipOptionType10, MenuOptionTypes);
                    AssignDefine(gossipIcon1, GossipIconDefines);
                    AssignDefine(gossipIcon2, GossipIconDefines);
                    AssignDefine(gossipIcon3, GossipIconDefines);
                    AssignDefine(gossipIcon4, GossipIconDefines);
                    AssignDefine(gossipIcon5, GossipIconDefines);
                    AssignDefine(gossipIcon6, GossipIconDefines);
                    AssignDefine(gossipIcon7, GossipIconDefines);
                    AssignDefine(gossipIcon8, GossipIconDefines);
                    AssignDefine(gossipIcon9, GossipIconDefines);
                    AssignDefine(gossipIcon10, GossipIconDefines);
                    AssignDefine(npcTextEmote1, Emotes);
                    AssignDefine(npcTextEmote2, Emotes);
                    AssignDefine(npcTextEmote3, Emotes);
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        public void Load(int id)
        {
            IsLoading = true;
            Update();
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    GossipData = client.GetGossipMenu(id);
                    Load(GossipData);
                    FlashMessage(Colors.Green, "菜单" + id + "已载入。");
                };
            }
            catch (Exception /*ex*/) { FlashMessage(Colors.Red, "获取菜单" + id + "失败。"); }
        }

        public void Load(GossipMenu menu)
        {
            IsLoading = true;

            GossipData = menu;

            if (GossipData == null)
            {
                this.Dispatcher.Invoke(() =>
                {
                    gossipNpcName.Text = "菜单不存在。";
                });
                return;
            }

            this.Dispatcher.Invoke(() =>
            {
                gossipID.Text = GossipData.ID.ToString();
                gossipNpcTextLanguage.SelectedValue = GossipData.NpcTextLanguage;
                gossipNpcTextMale.Text = GossipData.NpcTextMale;
                gossipNpcTextFemale.Text = GossipData.NpcTextFemale;
                npcTextID.Text = GossipData.NpcTextID.ToString();
                npcTextEmote1.SelectedValue = GossipData.Emote1;
                npcTextEmote2.SelectedValue = GossipData.Emote2;
                npcTextEmote3.SelectedValue = GossipData.Emote3;

                if (GossipData.Options != null)
                {
                    if (GossipData.Options[0] != null)
                    {
                        gossipMenu1.Text = GossipData.Options[0].Text;
                        gossipOptionType1.SelectedValue = GossipData.Options[0].Type;
                        gossipIcon1.SelectedValue = GossipData.Options[0].Icon;
                        gossipIcon1.IsEnabled = true;
                        gossipMenuGo1.IsEnabled = true;
                        gossipOptionType1.IsEnabled = true;
                        gossipSetOptionAttr1.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu1.Text = "";
                        gossipOptionType1.SelectedValue = 0;
                        gossipMenuGo1.IsEnabled = false;
                        gossipOptionType1.IsEnabled = false;
                        gossipSetOptionAttr1.IsEnabled = false;
                        gossipIcon1.SelectedValue = 0;
                        gossipIcon1.IsEnabled = false;
                    }

                    if (GossipData.Options[1] != null)
                    {
                        gossipMenu2.Text = GossipData.Options[1].Text;
                        gossipOptionType2.SelectedValue = GossipData.Options[1].Type;
                        gossipIcon2.SelectedValue = GossipData.Options[1].Icon;
                        gossipIcon2.IsEnabled = true;
                        gossipMenuGo2.IsEnabled = true;
                        gossipOptionType2.IsEnabled = true;
                        gossipSetOptionAttr2.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu2.Text = "";
                        gossipOptionType2.SelectedValue = 0;
                        gossipMenuGo2.IsEnabled = false;
                        gossipOptionType2.IsEnabled = false;
                        gossipSetOptionAttr2.IsEnabled = false;
                        gossipIcon2.SelectedValue = 0;
                        gossipIcon2.IsEnabled = false;
                    }

                    if (GossipData.Options[2] != null)
                    {
                        gossipMenu3.Text = GossipData.Options[2].Text;
                        gossipOptionType3.SelectedValue = GossipData.Options[2].Type;
                        gossipIcon3.SelectedValue = GossipData.Options[2].Icon;
                        gossipIcon3.IsEnabled = true;
                        gossipMenuGo3.IsEnabled = true;
                        gossipOptionType3.IsEnabled = true;
                        gossipSetOptionAttr3.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu3.Text = "";
                        gossipOptionType3.SelectedValue = 0;
                        gossipMenuGo3.IsEnabled = false;
                        gossipOptionType3.IsEnabled = false;
                        gossipSetOptionAttr3.IsEnabled = false;
                        gossipIcon3.SelectedValue = 0;
                        gossipIcon3.IsEnabled = false;
                    }

                    if (GossipData.Options[3] != null)
                    {
                        gossipMenu4.Text = GossipData.Options[3].Text;
                        gossipOptionType4.SelectedValue = GossipData.Options[3].Type;
                        gossipIcon4.SelectedValue = GossipData.Options[3].Icon;
                        gossipIcon4.IsEnabled = true;
                        gossipMenuGo4.IsEnabled = true;
                        gossipOptionType4.IsEnabled = true;
                        gossipSetOptionAttr4.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu4.Text = "";
                        gossipOptionType4.SelectedValue = 0;
                        gossipMenuGo4.IsEnabled = false;
                        gossipOptionType4.IsEnabled = false;
                        gossipSetOptionAttr4.IsEnabled = false;
                        gossipIcon4.SelectedValue = 0;
                        gossipIcon4.IsEnabled = false;
                    }

                    if (GossipData.Options[4] != null)
                    {
                        gossipMenu5.Text = GossipData.Options[4].Text;
                        gossipOptionType5.SelectedValue = GossipData.Options[4].Type;
                        gossipIcon5.SelectedValue = GossipData.Options[4].Icon;
                        gossipIcon5.IsEnabled = true;
                        gossipMenuGo5.IsEnabled = true;
                        gossipOptionType5.IsEnabled = true;
                        gossipSetOptionAttr5.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu5.Text = "";
                        gossipOptionType5.SelectedValue = 0;
                        gossipMenuGo5.IsEnabled = false;
                        gossipOptionType5.IsEnabled = false;
                        gossipSetOptionAttr5.IsEnabled = false;
                        gossipIcon5.SelectedValue = 0;
                        gossipIcon5.IsEnabled = false;
                    }

                    if (GossipData.Options[5] != null)
                    {
                        gossipMenu6.Text = GossipData.Options[5].Text;
                        gossipOptionType6.SelectedValue = GossipData.Options[5].Type;
                        gossipIcon6.SelectedValue = GossipData.Options[5].Icon;
                        gossipIcon6.IsEnabled = true;
                        gossipMenuGo6.IsEnabled = true;
                        gossipOptionType6.IsEnabled = true;
                        gossipSetOptionAttr6.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu6.Text = "";
                        gossipOptionType6.SelectedValue = 0;
                        gossipMenuGo6.IsEnabled = false;
                        gossipOptionType6.IsEnabled = false;
                        gossipSetOptionAttr6.IsEnabled = false;
                        gossipIcon6.SelectedValue = 0;
                        gossipIcon6.IsEnabled = false;
                    }

                    if (GossipData.Options[6] != null)
                    {
                        gossipMenu7.Text = GossipData.Options[6].Text;
                        gossipOptionType7.SelectedValue = GossipData.Options[6].Type;
                        gossipIcon7.SelectedValue = GossipData.Options[6].Icon;
                        gossipIcon7.IsEnabled = true;
                        gossipMenuGo7.IsEnabled = true;
                        gossipOptionType7.IsEnabled = true;
                        gossipSetOptionAttr7.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu7.Text = "";
                        gossipOptionType7.SelectedValue = 0;
                        gossipMenuGo7.IsEnabled = false;
                        gossipOptionType7.IsEnabled = false;
                        gossipSetOptionAttr7.IsEnabled = false;
                        gossipIcon7.SelectedValue = 0;
                        gossipIcon7.IsEnabled = false;
                    }

                    if (GossipData.Options[7] != null)
                    {
                        gossipMenu8.Text = GossipData.Options[7].Text;
                        gossipOptionType8.SelectedValue = GossipData.Options[7].Type;
                        gossipIcon8.SelectedValue = GossipData.Options[7].Icon;
                        gossipIcon8.IsEnabled = true;
                        gossipMenuGo8.IsEnabled = true;
                        gossipOptionType8.IsEnabled = true;
                        gossipSetOptionAttr8.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu8.Text = "";
                        gossipOptionType8.SelectedValue = 0;
                        gossipMenuGo8.IsEnabled = false;
                        gossipOptionType8.IsEnabled = false;
                        gossipSetOptionAttr8.IsEnabled = false;
                        gossipIcon8.SelectedValue = 0;
                        gossipIcon8.IsEnabled = false;
                    }

                    if (GossipData.Options[8] != null)
                    {
                        gossipMenu9.Text = GossipData.Options[8].Text;
                        gossipOptionType9.SelectedValue = GossipData.Options[8].Type;
                        gossipIcon9.SelectedValue = GossipData.Options[8].Icon;
                        gossipIcon9.IsEnabled = true;
                        gossipMenuGo9.IsEnabled = true;
                        gossipOptionType9.IsEnabled = true;
                        gossipSetOptionAttr9.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu9.Text = "";
                        gossipOptionType9.SelectedValue = 0;
                        gossipMenuGo9.IsEnabled = false;
                        gossipOptionType9.IsEnabled = false;
                        gossipSetOptionAttr9.IsEnabled = false;
                        gossipIcon9.SelectedValue = 0;
                        gossipIcon9.IsEnabled = false;
                    }

                    if (GossipData.Options[9] != null)
                    {
                        gossipMenu10.Text = GossipData.Options[9].Text;
                        gossipOptionType10.SelectedValue = GossipData.Options[9].Type;
                        gossipIcon10.SelectedValue = GossipData.Options[9].Icon;
                        gossipIcon10.IsEnabled = true;
                        gossipMenuGo10.IsEnabled = true;
                        gossipOptionType10.IsEnabled = true;
                        gossipSetOptionAttr10.IsEnabled = true;
                    }
                    else
                    {
                        gossipMenu10.Text = "";
                        gossipOptionType10.SelectedValue = 0;
                        gossipMenuGo10.IsEnabled = false;
                        gossipOptionType10.IsEnabled = false;
                        gossipSetOptionAttr10.IsEnabled = false;
                        gossipIcon10.SelectedValue = 0;
                        gossipIcon10.IsEnabled = false;
                    }
                }
                else
                {
                    gossipMenu1.Text = "";
                    gossipOptionType1.SelectedValue = 0;
                    gossipMenuGo1.IsEnabled = false;
                    gossipOptionType1.IsEnabled = false;
                    gossipSetOptionAttr1.IsEnabled = false;
                    gossipMenu2.Text = "";
                    gossipOptionType2.SelectedValue = 0;
                    gossipMenuGo2.IsEnabled = false;
                    gossipOptionType2.IsEnabled = false;
                    gossipSetOptionAttr2.IsEnabled = false;
                    gossipMenu3.Text = "";
                    gossipOptionType3.SelectedValue = 0;
                    gossipMenuGo3.IsEnabled = false;
                    gossipOptionType3.IsEnabled = false;
                    gossipSetOptionAttr3.IsEnabled = false;
                    gossipMenu4.Text = "";
                    gossipOptionType4.SelectedValue = 0;
                    gossipMenuGo4.IsEnabled = false;
                    gossipOptionType4.IsEnabled = false;
                    gossipSetOptionAttr4.IsEnabled = false;
                    gossipMenu5.Text = "";
                    gossipOptionType5.SelectedValue = 0;
                    gossipMenuGo5.IsEnabled = false;
                    gossipOptionType5.IsEnabled = false;
                    gossipSetOptionAttr5.IsEnabled = false;
                    gossipMenu6.Text = "";
                    gossipOptionType6.SelectedValue = 0;
                    gossipMenuGo6.IsEnabled = false;
                    gossipOptionType6.IsEnabled = false;
                    gossipSetOptionAttr6.IsEnabled = false;
                    gossipMenu7.Text = "";
                    gossipOptionType7.SelectedValue = 0;
                    gossipMenuGo7.IsEnabled = false;
                    gossipOptionType7.IsEnabled = false;
                    gossipSetOptionAttr7.IsEnabled = false;
                    gossipMenu8.Text = "";
                    gossipOptionType8.SelectedValue = 0;
                    gossipMenuGo8.IsEnabled = false;
                    gossipOptionType8.IsEnabled = false;
                    gossipSetOptionAttr8.IsEnabled = false;
                    gossipMenu9.Text = "";
                    gossipOptionType9.SelectedValue = 0;
                    gossipMenuGo9.IsEnabled = false;
                    gossipOptionType9.IsEnabled = false;
                    gossipSetOptionAttr9.IsEnabled = false;
                    gossipMenu10.Text = "";
                    gossipOptionType10.SelectedValue = 0;
                    gossipMenuGo10.IsEnabled = false;
                    gossipOptionType10.IsEnabled = false;
                    gossipSetOptionAttr10.IsEnabled = false;
                    gossipIcon1.SelectedValue = 0;
                    gossipIcon1.IsEnabled = false;
                    gossipIcon2.SelectedValue = 0;
                    gossipIcon2.IsEnabled = false;
                    gossipIcon3.SelectedValue = 0;
                    gossipIcon3.IsEnabled = false;
                    gossipIcon4.SelectedValue = 0;
                    gossipIcon4.IsEnabled = false;
                    gossipIcon5.SelectedValue = 0;
                    gossipIcon5.IsEnabled = false;
                    gossipIcon6.SelectedValue = 0;
                    gossipIcon6.IsEnabled = false;
                    gossipIcon7.SelectedValue = 0;
                    gossipIcon7.IsEnabled = false;
                    gossipIcon8.SelectedValue = 0;
                    gossipIcon8.IsEnabled = false;
                    gossipIcon9.SelectedValue = 0;
                    gossipIcon9.IsEnabled = false;
                    gossipIcon10.SelectedValue = 0;
                    gossipIcon10.IsEnabled = false;
                }

                gossipMenu1.IsEnabled = true;
                gossipMenu2.IsEnabled = true;
                gossipMenu3.IsEnabled = true;
                gossipMenu4.IsEnabled = true;
                gossipMenu5.IsEnabled = true;
                gossipMenu6.IsEnabled = true;
                gossipMenu7.IsEnabled = true;
                gossipMenu8.IsEnabled = true;
                gossipMenu9.IsEnabled = true;
                gossipMenu10.IsEnabled = true;
                gossipNpcTextLanguage.IsEnabled = true;
                npcTextTab.IsEnabled = true;
                gossipAssignToBothGender.IsEnabled = true;
                gossipGo.IsEnabled = true;

                IsLoading = false;
            });
        }

        private void Save()
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    GossipMenu menu = client.SaveGossipMenu(GossipData);
                    if (menu == null)
                    {
                        FlashMessage(Colors.Red, "保存失败。");
                        return;
                    }
                    FlashMessage(Colors.Green, "菜单" + GossipData.ID + "保存成功。");
                    Load(menu);
                }
            }
            catch (System.Exception /*ex*/) { FlashMessage(Colors.Red, "保存失败。"); }
        }

        private void Update()
        {
            if (GossipData == null)
                return;

            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    GossipMenu menu = client.SaveGossipMenu(GossipData);
                    if (menu == null)
                    {
                        FlashMessage(Colors.Red, "保存失败。");
                        return;
                    }
                    FlashMessage(Colors.Green, "菜单" + menu.ID + "保存成功。");
                }
            }
            catch (System.Exception /*ex*/)
            {
                FlashMessage(Colors.Red, "保存失败。");
            }
        }

        private void UpdateGossipMenuOption(string text, int optionID)
        {
            if (GossipData.Options == null)
            {
                if (text != "")
                {
                    GossipData.Options = new GossipMenuOption[MAX_GOSSIP_ITEM];
                    GossipData.Options[optionID] = new GossipMenuOption()
                    {
                        Icon = 0,
                        Text = text,
                        OptionBroadcastTextID = 0,
                        Type = 0,
                        NpcFlags = 0,
                        ActionMenu = 0,
                        ActionPOI = 0,
                        ShowCodeBox = false,
                        BoxMoney = 0,
                        BoxBroadcastTextID = 0,
                        SingleTimeCheck = false
                    };
                }
            }
            else
            {
                if (text == "")
                {
                    GossipData.Options[optionID] = null;
                }
                else
                {
                    if (GossipData.Options[optionID] != null)
                        GossipData.Options[optionID].Text = text;
                    else
                    {
                        GossipData.Options[optionID] = new GossipMenuOption()
                        {
                            Icon = 0,
                            Text = text,
                            OptionBroadcastTextID = 0,
                            Type = 0,
                            NpcFlags = 0,
                            ActionMenu = 0,
                            ActionPOI = 0,
                            ShowCodeBox = false,
                            BoxMoney = 0,
                            BoxBroadcastTextID = 0,
                            SingleTimeCheck = false
                        };
                    }
                }
            }
        }

        public void FlashMessage(Color color, string text)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                statusLabel.Foreground = new SolidColorBrush(color);
                statusLabel.Content = text;
                Storyboard anim = FindResource("FlashMessage") as Storyboard;
                anim.Begin();
            }));
        }

        private void UpdateGossipMenuOptionType(int type, int optionID)
        {
            if (GossipData == null || GossipData.Options == null)
                return;

            if (GossipData.Options[optionID] != null)
                GossipData.Options[optionID].Type = type;
        }

        private GossipMenu CreateGossipMenu()
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    GossipMenu menu = client.CreateNewGossipMenu();
                    return menu;
                }
            }
            catch (System.Exception /*ex*/)
            {
                return null;
            }
        }

        private int NavigateToMenu(int optionID)
        {
            int navigateForward = 0;

            if (GossipData.Options[optionID] != null && GossipData.Options[optionID].ActionMenu != 0)
            {
                navigateForward = GossipData.Options[optionID].ActionMenu;
                Load(GossipData.Options[optionID].ActionMenu);
            }
            else
            {
                GossipMenu menu = CreateGossipMenu();
                if (menu != null)
                {
                    GossipData.Options[optionID].ActionMenu = menu.ID;
                    navigateForward = menu.ID;
                    Load(menu.ID);
                }
            }

            gossipPrevMenu.IsEnabled = true;
            return navigateForward;
        }

        private void gossipMenuGo1_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(0));
        }

        private void gossipMenuGo2_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(1));
        }

        private void gossipMenuGo3_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(2));
        }

        private void gossipMenuGo4_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(3));
        }

        private void gossipMenuGo5_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(4));
        }

        private void gossipMenuGo6_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(5));
        }

        private void gossipMenuGo7_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(6));
        }

        private void gossipMenuGo8_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(7));
        }

        private void gossipMenuGo9_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(8));
        }

        private void gossipMenuGo10_Click(object sender, RoutedEventArgs e)
        {
            GossipNavigation.Next(NavigateToMenu(9));
        }

        private void gossipMenu1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu1.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo1.IsEnabled = false;
                    gossipOptionType1.IsEnabled = false;
                    gossipSetOptionAttr1.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo1.IsEnabled = true;
                    gossipOptionType1.IsEnabled = true;
                    gossipSetOptionAttr1.IsEnabled = true;
                }
            }
        }

        private void gossipMenu2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu2.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo2.IsEnabled = false;
                    gossipOptionType2.IsEnabled = false;
                    gossipSetOptionAttr2.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo2.IsEnabled = true;
                    gossipOptionType2.IsEnabled = true;
                    gossipSetOptionAttr2.IsEnabled = true;
                }
            }
        }

        private void gossipMenu3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu3.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo3.IsEnabled = false;
                    gossipOptionType3.IsEnabled = false;
                    gossipSetOptionAttr3.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo3.IsEnabled = true;
                    gossipOptionType3.IsEnabled = true;
                    gossipSetOptionAttr3.IsEnabled = true;
                }
            }
        }

        private void gossipMenu4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu4.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo4.IsEnabled = false;
                    gossipOptionType4.IsEnabled = false;
                    gossipSetOptionAttr4.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo4.IsEnabled = true;
                    gossipOptionType4.IsEnabled = true;
                    gossipSetOptionAttr4.IsEnabled = true;
                }
            }
        }

        private void gossipMenu5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu5.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo5.IsEnabled = false;
                    gossipOptionType5.IsEnabled = false;
                    gossipSetOptionAttr5.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo5.IsEnabled = true;
                    gossipOptionType5.IsEnabled = true;
                    gossipSetOptionAttr5.IsEnabled = true;
                }
            }
        }

        private void gossipMenu6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu6.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo6.IsEnabled = false;
                    gossipOptionType6.IsEnabled = false;
                    gossipSetOptionAttr6.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo6.IsEnabled = true;
                    gossipOptionType6.IsEnabled = true;
                    gossipSetOptionAttr6.IsEnabled = true;
                }
            }
        }

        private void gossipMenu7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu7.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo7.IsEnabled = false;
                    gossipOptionType7.IsEnabled = false;
                    gossipSetOptionAttr7.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo7.IsEnabled = true;
                    gossipOptionType7.IsEnabled = true;
                    gossipSetOptionAttr7.IsEnabled = true;
                }
            }
        }

        private void gossipMenu8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu8.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo8.IsEnabled = false;
                    gossipOptionType8.IsEnabled = false;
                    gossipSetOptionAttr8.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo8.IsEnabled = true;
                    gossipOptionType8.IsEnabled = true;
                    gossipSetOptionAttr8.IsEnabled = true;
                }
            }
        }

        private void gossipMenu9_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu9.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo9.IsEnabled = false;
                    gossipOptionType9.IsEnabled = false;
                    gossipSetOptionAttr9.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo9.IsEnabled = true;
                    gossipOptionType9.IsEnabled = true;
                    gossipSetOptionAttr9.IsEnabled = true;
                }
            }
        }

        private void gossipMenu10_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gossipMenu1.Text == "")
            {
                // delete menu option item.
                {
                    gossipMenuGo10.IsEnabled = false;
                    gossipOptionType10.IsEnabled = false;
                    gossipSetOptionAttr10.IsEnabled = false;
                }
            }
            else
            {
                // update or add menu option item.
                {
                    gossipMenuGo10.IsEnabled = true;
                    gossipOptionType10.IsEnabled = true;
                    gossipSetOptionAttr10.IsEnabled = true;
                }
            }
        }

        private void gossipGo_Click(object sender, RoutedEventArgs e)
        {
            int menuID = 0;
            gossipGo.IsEnabled = false;
            if (showNpcEntryText.IsChecked == true)
            {
                int npcEntry = Convert.ToInt32(gossipNpcID.Text);
                try
                {
                    using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                    {
                        menuID = client.GetOrCreateCreatureGossipID(npcEntry);
                        GossipNavigation = new GossipNavigator(menuID);
                    }
                }
                catch (System.Exception /*ex*/) { }
            }
            else
            {
                menuID = Convert.ToInt32(gossipID.Text);
                GossipNavigation = new GossipNavigator(menuID);
            }
            new Thread(() => Load(menuID)).Start();
        }

        private void CheckGossipMenuItemExistence(int id)
        {
            if (GossipData.Options[id] == null)
            {
                GossipData.Options[id] = new GossipMenuOption()
                {
                    Icon = 0,
                    Text = "",
                    OptionBroadcastTextID = 0,
                    Type = 0,
                    NpcFlags = 0,
                    ActionMenu = 0,
                    ActionPOI = 0,
                    ShowCodeBox = false,
                    BoxMoney = 0,
                    BoxText = "",
                    BoxBroadcastTextID = 0,
                    SingleTimeCheck = false,
                };
            }
        }

        private void gossipSetOptionAttr1_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(0);
            new CreatureNpcFlagsSelector(GossipData, 0).Show();
        }

        private void gossipSetOptionAttr2_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(1);
            new CreatureNpcFlagsSelector(GossipData, 1).Show();
        }

        private void gossipSetOptionAttr3_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(2);
            new CreatureNpcFlagsSelector(GossipData, 2).Show();
        }

        private void gossipSetOptionAttr4_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(3);
            new CreatureNpcFlagsSelector(GossipData, 3).Show();
        }

        private void gossipSetOptionAttr5_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(4);
            new CreatureNpcFlagsSelector(GossipData, 4).Show();
        }

        private void gossipSetOptionAttr6_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(5);
            new CreatureNpcFlagsSelector(GossipData, 5).Show();
        }

        private void gossipSetOptionAttr7_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(6);
            new CreatureNpcFlagsSelector(GossipData, 6).Show();
        }

        private void gossipSetOptionAttr8_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(7);
            new CreatureNpcFlagsSelector(GossipData, 7).Show();
        }

        private void gossipSetOptionAttr9_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(8);
            new CreatureNpcFlagsSelector(GossipData, 8).Show();
        }

        private void gossipSetOptionAttr10_Click(object sender, RoutedEventArgs e)
        {
            CheckGossipMenuItemExistence(9);
            new CreatureNpcFlagsSelector(GossipData, 9).Show();
        }

        private void gossipMenuSave_Click(object sender, RoutedEventArgs e)
        {
            if (GossipData == null)
                return;

            new Thread(Save).Start();
        }

        private void gossipMenu1_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu1.Text, 0);
        }

        private void gossipMenu2_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu2.Text, 1);
        }

        private void gossipMenu3_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu3.Text, 2);
        }

        private void gossipMenu4_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu4.Text, 3);
        }

        private void gossipMenu5_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu5.Text, 4);
        }

        private void gossipMenu6_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu6.Text, 5);
        }

        private void gossipMenu7_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu7.Text, 6);
        }

        private void gossipMenu8_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu8.Text, 7);
        }

        private void gossipMenu9_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu9.Text, 8);
        }

        private void gossipMenu10_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateGossipMenuOption(gossipMenu10.Text, 9);
        }

        private void gossipOptionType1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType1.SelectedValue, 0);
        }

        private void gossipOptionType2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType2.SelectedValue, 1);
        }

        private void gossipOptionType3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType3.SelectedValue, 2);
        }

        private void gossipOptionType4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType4.SelectedValue, 3);
        }

        private void gossipOptionType5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType5.SelectedValue, 4);
        }

        private void gossipOptionType6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType6.SelectedValue, 5);
        }

        private void gossipOptionType7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType7.SelectedValue, 6);
        }

        private void gossipOptionType8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType8.SelectedValue, 7);
        }

        private void gossipOptionType9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType9.SelectedValue, 8);
        }

        private void gossipOptionType10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading)
                return;
            UpdateGossipMenuOptionType((int)gossipOptionType10.SelectedValue, 9);
        }

        private void npcTextID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GossipData == null)
                return;

            GossipData.ID = Convert.ToInt32(npcTextID.Text);
        }

        private void gossipNpcTextMale_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GossipData == null)
                return;

            GossipData.NpcTextMale = gossipNpcTextMale.Text;
        }

        private void gossipNpcTextFemale_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GossipData == null)
                return;

            GossipData.NpcTextFemale = gossipNpcTextFemale.Text;
        }

        private void gossipID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gossipID.Text);
                gossipGo.IsEnabled = true;
            }
            catch (System.Exception /*ex*/)
            {
                gossipGo.IsEnabled = false;
            }
        }

        private void gossipNpcID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gossipNpcID.Text);
                gossipGo.IsEnabled = true;
                string name = "生物不存在。";
                CreatureNames.TryGetValue(id, out name);
                gossipNpcName.Text = name;
            }
            catch (System.Exception /*ex*/)
            {
                gossipGo.IsEnabled = false;
                gossipNpcName.Text = "";

            }
        }

        private void showNpcEntryText_Click(object sender, RoutedEventArgs e)
        {
            bool showNpc = showNpcEntryText.IsChecked == true ? true : false;
            if (showNpc)
            {
                gossipID.Visibility = Visibility.Hidden;
                gossipNpcID.Visibility = Visibility.Visible;
            }
            else
            {
                gossipID.Visibility = Visibility.Visible;
                gossipNpcID.Visibility = Visibility.Hidden;
            }
        }

        private void gossipPrevMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GossipNavigation.Current == 0)
                return;

            if (GossipNavigation.Current == 1)
                gossipPrevMenu.IsEnabled = false;

            Load(GossipNavigation.Prev());
        }

        private void npcTextEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading || GossipData == null)
                return;
            GossipData.Emote1 = (int)npcTextEmote1.SelectedValue;
        }

        private void npcTextEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading || GossipData == null)
                return;
            GossipData.Emote2 = (int)npcTextEmote2.SelectedValue;
        }

        private void npcTextEmote3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoading || GossipData == null)
                return;
            GossipData.Emote3 = (int)npcTextEmote3.SelectedValue;
        }

        private void UpdateGossipIcon(int icon, int optionID)
        {
            if (IsLoading || GossipData == null || GossipData.Options == null)
                return;

            if (GossipData.Options[optionID] != null)
                GossipData.Options[optionID].Icon = icon;
        }

        private void gossipIcon1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon1.SelectedValue, 0);
        }

        private void gossipIcon2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon2.SelectedValue, 1);
        }

        private void gossipIcon3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon3.SelectedValue, 2);
        }

        private void gossipIcon4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon4.SelectedValue, 3);
        }

        private void gossipIcon5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon5.SelectedValue, 4);
        }

        private void gossipIcon6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon6.SelectedValue, 5);
        }

        private void gossipIcon7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon7.SelectedValue, 6);
        }

        private void gossipIcon8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon8.SelectedValue, 7);
        }

        private void gossipIcon9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon9.SelectedValue, 8);
        }

        private void gossipIcon10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGossipIcon((int)gossipIcon10.SelectedValue, 9);
        }
    }

    public class GossipNavigator
    {
        public int Current { get; set; }
        private List<int> NavigationData { get; set; }

        public GossipNavigator(int menuID)
        {
            Current = 0;
            NavigationData = new List<int>();
            NavigationData.Add(menuID);
        }

        public void Next(int menuID)
        {
            Current++;
            if (Current == NavigationData.Count)
                NavigationData.Add(menuID);
            else
                NavigationData[Current] = menuID;
        }

        public int Prev()
        {
            if (Current == 0)
                return 0;

            Current--;
            return NavigationData[Current];
        }
    }
}
