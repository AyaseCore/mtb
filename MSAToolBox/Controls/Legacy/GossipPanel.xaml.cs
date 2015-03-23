using MSAToolBox.Utility;
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
using MSAToolBox.SubWindows.Legacy;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// GossipPanel.xaml 的交互逻辑
    /// </summary>
    public partial class GossipPanel : UserControl
    {
        public static List<GossipMenu> GossipMenuData;
        public static List<GossipMenuItem> GossipMenuItemData;

        private GossipMenu _SelectedGossipMenu;
        private GossipMenuItem _SelectedMenuItem;
        private NpcText _SelectedNpcText;

        private bool MenuLoaded = false;
        private bool MenuItemLoaded = false;

        public GossipPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            Util.AssignDefine(gossipText0BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText1BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText2BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText3BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText4BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText5BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText6BctLanguage, LegacyWorld.GetLanguages());
            Util.AssignDefine(gossipText7BctLanguage, LegacyWorld.GetLanguages());

            Util.AssignDefine(gossipText0BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText0BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText0BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText1BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText1BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText1BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText2BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText2BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText2BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText3BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText3BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText3BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText4BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText4BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText4BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText5BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText5BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText5BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText6BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText6BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText6BctEmote2, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText7BctEmote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText7BctEmote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(gossipText7BctEmote2, LegacyWorld.GetEmotes());

            Util.AssignDefine(menuItemIcon, LegacyWorld.GetGossipIconDefines());
            Util.AssignDefine(menuItemOptionType, LegacyWorld.GetGossipMenuOptionTypes());

            GossipMenuData = LegacyWorld.GetAllGossipMenu();
            gossipMenuList.ItemsSource = GossipMenuData;

            MenuLoaded = true;
        }

        public void LoadGossipMenus()
        {
            GossipMenuData = LegacyWorld.GetAllGossipMenu();
            gossipMenuList.ItemsSource = GossipMenuData;
        }

        private void SaveGossipTextBct(int id)
        {
            BroadCastText text = GetGossipTextBct(id);
            if (text != null)
                LegacyWorld.SaveBroadCastText(text);
        }

        private BroadCastText GetGossipTextBct(int id)
        {
            BroadCastText text = new BroadCastText();
            switch (id)
            {
                case 0:
                    if (gossipText0Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText0Bct.Text);
                    text.Language = Convert.ToInt32(gossipText0BctLanguage.SelectedValue);
                    text.MaleText = gossipText0Male.Text;
                    text.FemaleText = gossipText0Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText0BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText0BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText0BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText0BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText0BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText0BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText0BctSoundID.Text);
                    break;
                case 1:
                    if (gossipText1Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText1Bct.Text);
                    text.Language = Convert.ToInt32(gossipText1BctLanguage.SelectedValue);
                    text.MaleText = gossipText1Male.Text;
                    text.FemaleText = gossipText1Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText1BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText1BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText1BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText1BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText1BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText1BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText1BctSoundID.Text);
                    break;
                case 2:
                    if (gossipText2Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText2Bct.Text);
                    text.Language = Convert.ToInt32(gossipText2BctLanguage.SelectedValue);
                    text.MaleText = gossipText2Male.Text;
                    text.FemaleText = gossipText2Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText2BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText2BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText2BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText2BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText2BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText2BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText2BctSoundID.Text);
                    break;
                case 3:
                    if (gossipText3Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText3Bct.Text);
                    text.Language = Convert.ToInt32(gossipText3BctLanguage.SelectedValue);
                    text.MaleText = gossipText3Male.Text;
                    text.FemaleText = gossipText3Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText3BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText3BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText3BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText3BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText3BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText3BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText3BctSoundID.Text);
                    break;
                case 4:
                    if (gossipText4Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText4Bct.Text);
                    text.Language = Convert.ToInt32(gossipText4BctLanguage.SelectedValue);
                    text.MaleText = gossipText4Male.Text;
                    text.FemaleText = gossipText4Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText4BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText4BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText4BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText4BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText4BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText4BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText4BctSoundID.Text);
                    break;
                case 5:
                    if (gossipText5Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText5Bct.Text);
                    text.Language = Convert.ToInt32(gossipText5BctLanguage.SelectedValue);
                    text.MaleText = gossipText5Male.Text;
                    text.FemaleText = gossipText5Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText5BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText5BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText5BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText5BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText5BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText5BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText5BctSoundID.Text);
                    break;
                case 6:
                    if (gossipText6Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText6Bct.Text);
                    text.Language = Convert.ToInt32(gossipText6BctLanguage.SelectedValue);
                    text.MaleText = gossipText6Male.Text;
                    text.FemaleText = gossipText6Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText6BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText6BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText6BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText6BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText6BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText6BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText6BctSoundID.Text);
                    break;
                case 7:
                    if (gossipText7Bct.Text == "")
                        return null;
                    text.ID = Convert.ToInt32(gossipText7Bct.Text);
                    text.Language = Convert.ToInt32(gossipText7BctLanguage.SelectedValue);
                    text.MaleText = gossipText7Male.Text;
                    text.FemaleText = gossipText7Female.Text;
                    text.Emote0 = Convert.ToInt32(gossipText7BctEmote0.SelectedValue);
                    text.Emote1 = Convert.ToInt32(gossipText7BctEmote1.SelectedValue);
                    text.Emote2 = Convert.ToInt32(gossipText7BctEmote2.SelectedValue);
                    text.EmoteDelay0 = Convert.ToInt32(gossipText7BctEmoteDelay0.Text);
                    text.EmoteDelay1 = Convert.ToInt32(gossipText7BctEmoteDelay1.Text);
                    text.EmoteDelay2 = Convert.ToInt32(gossipText7BctEmoteDelay2.Text);
                    text.SoundID = Convert.ToInt32(gossipText7BctSoundID.Text);
                    break;
                default:
                    return null;
            }
            if (text.ID == 0)
                return null;
            return text;
        }

        public void LoadGossipMenu(GossipMenu menu)
        {
            if (GossipMenuData == null)
                return;

            if (_SelectedGossipMenu != null)
            {
                LegacyWorld.SaveGossipMenu(_SelectedGossipMenu);
                LegacyWorld.SaveNpcText(_SelectedNpcText);
            }

            _SelectedGossipMenu = menu;
            if (menu == null)
                return;

            NpcText text = LegacyWorld.GetGossipNpcText(menu.NpcText);
            _SelectedNpcText = text;
            if (text == null)
                return;

            MenuLoaded = false;

            BroadCastText bct0 = text.Text[0] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[0]);
            if (bct0 != null)
            {
                gossipText0Male.Text = bct0.MaleText;
                gossipText0Female.Text = bct0.FemaleText;
                gossipText0Chance.Text = text.Chance[0].ToString();
                gossipText0BctEmote0.SelectedValue = bct0.Emote0;
                gossipText0BctEmote1.SelectedValue = bct0.Emote1;
                gossipText0BctEmote2.SelectedValue = bct0.Emote2;
                gossipText0BctEmoteDelay0.Text = bct0.EmoteDelay0.ToString();
                gossipText0BctEmoteDelay1.Text = bct0.EmoteDelay1.ToString();
                gossipText0BctEmoteDelay2.Text = bct0.EmoteDelay2.ToString();
                gossipText0BctLanguage.SelectedValue = bct0.Language.ToString();
                gossipText0BctSoundID.Text = bct0.SoundID.ToString();
                gossipText0Bct.Text = bct0.ID.ToString();
            }
            else
            {
                gossipText0Male.Text = "";
                gossipText0Female.Text = "";
                gossipText0Chance.Text = "0";
                gossipText0BctEmote0.SelectedValue = 0;
                gossipText0BctEmote1.SelectedValue = 0;
                gossipText0BctEmote2.SelectedValue = 0;
                gossipText0BctEmoteDelay0.Text = "0";
                gossipText0BctEmoteDelay1.Text = "0";
                gossipText0BctEmoteDelay2.Text = "0";
                gossipText0BctLanguage.SelectedValue = 0;
                gossipText0BctSoundID.Text = "0";
                gossipText0Bct.Text = "0";
            }

            BroadCastText bct1 = text.Text[1] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[1]);
            if (bct1 != null)
            {
                gossipText1Male.Text = bct1.MaleText;
                gossipText1Female.Text = bct1.FemaleText;
                gossipText1Chance.Text = text.Chance[1].ToString();
                gossipText1BctEmote0.SelectedValue = bct1.Emote0;
                gossipText1BctEmote1.SelectedValue = bct1.Emote1;
                gossipText1BctEmote2.SelectedValue = bct1.Emote2;
                gossipText1BctEmoteDelay0.Text = bct1.EmoteDelay0.ToString();
                gossipText1BctEmoteDelay1.Text = bct1.EmoteDelay1.ToString();
                gossipText1BctEmoteDelay2.Text = bct1.EmoteDelay2.ToString();
                gossipText1BctLanguage.SelectedValue = bct1.Language.ToString();
                gossipText1BctSoundID.Text = bct1.SoundID.ToString();
                gossipText1Bct.Text = bct1.ID.ToString();
            }
            else
            {
                gossipText1Male.Text = "";
                gossipText1Female.Text = "";
                gossipText1Chance.Text = "0";
                gossipText1BctEmote0.SelectedValue = 0;
                gossipText1BctEmote1.SelectedValue = 0;
                gossipText1BctEmote2.SelectedValue = 0;
                gossipText1BctEmoteDelay0.Text = "0";
                gossipText1BctEmoteDelay1.Text = "0";
                gossipText1BctEmoteDelay2.Text = "0";
                gossipText1BctLanguage.SelectedValue = 0;
                gossipText1BctSoundID.Text = "0";
                gossipText1Bct.Text = "0";
            }

            BroadCastText bct2 = text.Text[2] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[2]);
            if (bct2 != null)
            {
                gossipText2Male.Text = bct2.MaleText;
                gossipText2Female.Text = bct2.FemaleText;
                gossipText2Chance.Text = text.Chance[2].ToString();
                gossipText2BctEmote0.SelectedValue = bct2.Emote0;
                gossipText2BctEmote1.SelectedValue = bct2.Emote1;
                gossipText2BctEmote2.SelectedValue = bct2.Emote2;
                gossipText2BctEmoteDelay0.Text = bct2.EmoteDelay0.ToString();
                gossipText2BctEmoteDelay1.Text = bct2.EmoteDelay1.ToString();
                gossipText2BctEmoteDelay2.Text = bct2.EmoteDelay2.ToString();
                gossipText2BctLanguage.SelectedValue = bct2.Language.ToString();
                gossipText2BctSoundID.Text = bct2.SoundID.ToString();
                gossipText2Bct.Text = bct2.ID.ToString();
            }
            else
            {
                gossipText2Male.Text = "";
                gossipText2Female.Text = "";
                gossipText2Chance.Text = "0";
                gossipText2BctEmote0.SelectedValue = 0;
                gossipText2BctEmote1.SelectedValue = 0;
                gossipText2BctEmote2.SelectedValue = 0;
                gossipText2BctEmoteDelay0.Text = "0";
                gossipText2BctEmoteDelay1.Text = "0";
                gossipText2BctEmoteDelay2.Text = "0";
                gossipText2BctLanguage.SelectedValue = 0;
                gossipText2BctSoundID.Text = "0";
                gossipText2Bct.Text = "0";
            }

            BroadCastText bct3 = text.Text[3] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[3]);
            if (bct3 != null)
            {
                gossipText3Male.Text = bct3.MaleText;
                gossipText3Female.Text = bct3.FemaleText;
                gossipText3Chance.Text = text.Chance[2].ToString();
                gossipText3BctEmote0.SelectedValue = bct3.Emote0;
                gossipText3BctEmote1.SelectedValue = bct3.Emote1;
                gossipText3BctEmote2.SelectedValue = bct3.Emote2;
                gossipText3BctEmoteDelay0.Text = bct3.EmoteDelay0.ToString();
                gossipText3BctEmoteDelay1.Text = bct3.EmoteDelay1.ToString();
                gossipText3BctEmoteDelay2.Text = bct3.EmoteDelay2.ToString();
                gossipText3BctLanguage.SelectedValue = bct3.Language.ToString();
                gossipText3BctSoundID.Text = bct3.SoundID.ToString();
                gossipText3Bct.Text = bct3.ID.ToString();
            }
            else
            {
                gossipText3Male.Text = "";
                gossipText3Female.Text = "";
                gossipText3Chance.Text = "0";
                gossipText3BctEmote0.SelectedValue = 0;
                gossipText3BctEmote1.SelectedValue = 0;
                gossipText3BctEmote2.SelectedValue = 0;
                gossipText3BctEmoteDelay0.Text = "0";
                gossipText3BctEmoteDelay1.Text = "0";
                gossipText3BctEmoteDelay2.Text = "0";
                gossipText3BctLanguage.SelectedValue = 0;
                gossipText3BctSoundID.Text = "0";
                gossipText3Bct.Text = "0";
            }

            BroadCastText bct4 = text.Text[4] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[4]);
            if (bct4 != null)
            {
                gossipText4Male.Text = bct4.MaleText;
                gossipText4Female.Text = bct4.FemaleText;
                gossipText4Chance.Text = text.Chance[2].ToString();
                gossipText4BctEmote0.SelectedValue = bct4.Emote0;
                gossipText4BctEmote1.SelectedValue = bct4.Emote1;
                gossipText4BctEmote2.SelectedValue = bct4.Emote2;
                gossipText4BctEmoteDelay0.Text = bct4.EmoteDelay0.ToString();
                gossipText4BctEmoteDelay1.Text = bct4.EmoteDelay1.ToString();
                gossipText4BctEmoteDelay2.Text = bct4.EmoteDelay2.ToString();
                gossipText4BctLanguage.SelectedValue = bct4.Language.ToString();
                gossipText4BctSoundID.Text = bct4.SoundID.ToString();
                gossipText4Bct.Text = bct4.ID.ToString();
            }
            else
            {
                gossipText4Male.Text = "";
                gossipText4Female.Text = "";
                gossipText4Chance.Text = "0";
                gossipText4BctEmote0.SelectedValue = 0;
                gossipText4BctEmote1.SelectedValue = 0;
                gossipText4BctEmote2.SelectedValue = 0;
                gossipText4BctEmoteDelay0.Text = "0";
                gossipText4BctEmoteDelay1.Text = "0";
                gossipText4BctEmoteDelay2.Text = "0";
                gossipText4BctLanguage.SelectedValue = 0;
                gossipText4BctSoundID.Text = "0";
                gossipText4Bct.Text = "0";
            }

            BroadCastText bct5 = text.Text[5] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[5]);
            if (bct5 != null)
            {
                gossipText5Male.Text = bct5.MaleText;
                gossipText5Female.Text = bct5.FemaleText;
                gossipText5Chance.Text = text.Chance[2].ToString();
                gossipText5BctEmote0.SelectedValue = bct5.Emote0;
                gossipText5BctEmote1.SelectedValue = bct5.Emote1;
                gossipText5BctEmote2.SelectedValue = bct5.Emote2;
                gossipText5BctEmoteDelay0.Text = bct5.EmoteDelay0.ToString();
                gossipText5BctEmoteDelay1.Text = bct5.EmoteDelay1.ToString();
                gossipText5BctEmoteDelay2.Text = bct5.EmoteDelay2.ToString();
                gossipText5BctLanguage.SelectedValue = bct5.Language.ToString();
                gossipText5BctSoundID.Text = bct5.SoundID.ToString();
                gossipText5Bct.Text = bct5.ID.ToString();
            }
            else
            {
                gossipText5Male.Text = "";
                gossipText5Female.Text = "";
                gossipText5Chance.Text = "0";
                gossipText5BctEmote0.SelectedValue = 0;
                gossipText5BctEmote1.SelectedValue = 0;
                gossipText5BctEmote2.SelectedValue = 0;
                gossipText5BctEmoteDelay0.Text = "0";
                gossipText5BctEmoteDelay1.Text = "0";
                gossipText5BctEmoteDelay2.Text = "0";
                gossipText5BctLanguage.SelectedValue = 0;
                gossipText5BctSoundID.Text = "0";
                gossipText5Bct.Text = "0";
            }

            BroadCastText bct6 = text.Text[6] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[6]);
            if (bct6 != null)
            {
                gossipText6Male.Text = bct6.MaleText;
                gossipText6Female.Text = bct6.FemaleText;
                gossipText6Chance.Text = text.Chance[2].ToString();
                gossipText6BctEmote0.SelectedValue = bct6.Emote0;
                gossipText6BctEmote1.SelectedValue = bct6.Emote1;
                gossipText6BctEmote2.SelectedValue = bct6.Emote2;
                gossipText6BctEmoteDelay0.Text = bct6.EmoteDelay0.ToString();
                gossipText6BctEmoteDelay1.Text = bct6.EmoteDelay1.ToString();
                gossipText6BctEmoteDelay2.Text = bct6.EmoteDelay2.ToString();
                gossipText6BctLanguage.SelectedValue = bct6.Language.ToString();
                gossipText6BctSoundID.Text = bct6.SoundID.ToString();
                gossipText6Bct.Text = bct6.ID.ToString();
            }
            else
            {
                gossipText6Male.Text = "";
                gossipText6Female.Text = "";
                gossipText6Chance.Text = "0";
                gossipText6BctEmote0.SelectedValue = 0;
                gossipText6BctEmote1.SelectedValue = 0;
                gossipText6BctEmote2.SelectedValue = 0;
                gossipText6BctEmoteDelay0.Text = "0";
                gossipText6BctEmoteDelay1.Text = "0";
                gossipText6BctEmoteDelay2.Text = "0";
                gossipText6BctLanguage.SelectedValue = 0;
                gossipText6BctSoundID.Text = "0";
                gossipText6Bct.Text = "0";
            }

            BroadCastText bct7 = text.Text[7] == 0 ? null : LegacyWorld.GetBroadCastText(text.Text[7]);
            if (bct7 != null)
            {
                gossipText7Male.Text = bct7.MaleText;
                gossipText7Female.Text = bct7.FemaleText;
                gossipText7Chance.Text = text.Chance[2].ToString();
                gossipText7BctEmote0.SelectedValue = bct7.Emote0;
                gossipText7BctEmote1.SelectedValue = bct7.Emote1;
                gossipText7BctEmote2.SelectedValue = bct7.Emote2;
                gossipText7BctEmoteDelay0.Text = bct7.EmoteDelay0.ToString();
                gossipText7BctEmoteDelay1.Text = bct7.EmoteDelay1.ToString();
                gossipText7BctEmoteDelay2.Text = bct7.EmoteDelay2.ToString();
                gossipText7BctLanguage.SelectedValue = bct7.Language.ToString();
                gossipText7BctSoundID.Text = bct7.SoundID.ToString();
                gossipText7Bct.Text = bct7.ID.ToString();
            }
            else
            {
                gossipText7Male.Text = "";
                gossipText7Female.Text = "";
                gossipText7Chance.Text = "0";
                gossipText7BctEmote0.SelectedValue = 0;
                gossipText7BctEmote1.SelectedValue = 0;
                gossipText7BctEmote2.SelectedValue = 0;
                gossipText7BctEmoteDelay0.Text = "0";
                gossipText7BctEmoteDelay1.Text = "0";
                gossipText7BctEmoteDelay2.Text = "0";
                gossipText7BctLanguage.SelectedValue = 0;
                gossipText7BctSoundID.Text = "0";
                gossipText7Bct.Text = "0";
            }

            gossipMenu.Text = menu.Menu.ToString();
            gossipText.Text = menu.NpcText.ToString();
            gossipMenuComment.Text = menu.Comment;

            LoadGossipMenuItems(menu.Menu);

            MenuLoaded = true;
        }

        public void LoadGossipMenuItems(int menu)
        {
            _SelectedMenuItem = null;
            List<GossipMenuItem> menuItems = LegacyWorld.GetGossipMenuItems(menu);
            gossipMenuItems.ItemsSource = menuItems;
        }

        public void LoadGossipMenuItem(GossipMenuItem item)
        {
            if (item == null)
                return;

            if (_SelectedMenuItem != null)
                LegacyWorld.SaveGossipMenuItem(_SelectedMenuItem);

            MenuItemLoaded = false;

            _SelectedMenuItem = item;
            menuItemMenu.Text = item.Menu.ToString();
            menuItemID.Text = item.ID.ToString();
            menuItemIcon.SelectedValue = item.Icon;
            menuItemText.Text = item.GossipTextID.ToString();
            menuItemOptionType.SelectedValue = item.OptionID;
            menuItemNpcFlag.Text = item.NpcFlags.ToString();
            menuItemAction.Text = item.ToMenu.ToString();
            menuItemPOI.Text = item.POI.ToString();
            menuItemCoded.IsChecked = item.BoxCoded;
            menuItemMoney.Text = item.BoxMoney.ToString();
            menuItemBoxText.Text = item.BoxTextID.ToString();
            menuItemSingleTimeCheck.IsChecked = item.SingleTimeCheck;

            MenuItemLoaded = true;
        }

        public void ModGossipMenuItem()
        {
            if (_SelectedMenuItem == null)
                return;

            _SelectedMenuItem.Menu = Convert.ToInt32(menuItemMenu.Text);
            _SelectedMenuItem.ID = Convert.ToInt32(menuItemID.Text);
            _SelectedMenuItem.Icon = Convert.ToInt32(menuItemIcon.SelectedValue);
            _SelectedMenuItem.GossipTextID = Convert.ToInt32(menuItemText.Text);
            _SelectedMenuItem.OptionID = Convert.ToByte(menuItemOptionType.SelectedValue);
            _SelectedMenuItem.NpcFlags = Convert.ToInt64(menuItemNpcFlag.Text);
            _SelectedMenuItem.ToMenu = Convert.ToInt32(menuItemAction.Text);
            _SelectedMenuItem.POI = Convert.ToInt32(menuItemPOI.Text);
            _SelectedMenuItem.BoxCoded = menuItemCoded.IsChecked == true;
            _SelectedMenuItem.BoxMoney = Convert.ToInt32(menuItemMoney.Text);
            _SelectedMenuItem.BoxTextID = Convert.ToInt32(menuItemBoxText.Text);
            _SelectedMenuItem.SingleTimeCheck = menuItemSingleTimeCheck.IsChecked == true;
        }

        private void gossipMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GossipMenuData == null)
                return;

            GossipMenu menu = gossipMenuList.SelectedItem as GossipMenu;
            LoadGossipMenu(menu);
        }

        private void gossipMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gossipMenuItems == null || gossipMenuItems.SelectedItem == null)
                return;

            GossipMenuItem item = gossipMenuItems.SelectedItem as GossipMenuItem;
            LoadGossipMenuItem(item);
        }

        private void gossipText0Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(0);
        }

        private void gossipText0BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(0);
        }

        private void gossipText0BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(0);
        }

        private void gossipText1Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(1);
        }

        private void gossipText1BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(1);
        }

        private void gossipText1BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(1);
        }

        private void gossipText2Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(2);
        }

        private void gossipText2BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(2);
        }

        private void gossipText2BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(2);
        }

        private void gossipText3Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(3);
        }

        private void gossipText3BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(3);
        }

        private void gossipText3BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(3);
        }

        private void gossipText4Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(4);
        }

        private void gossipText4BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(4);
        }

        private void gossipText4BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(4);
        }

        private void gossipText5Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(5);
        }

        private void gossipText5BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(5);
        }

        private void gossipText5BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(5);
        }

        private void gossipText6Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(6);
        }

        private void gossipText6BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(6);
        }

        private void gossipText6BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(6);
        }

        private void gossipText7Male_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7Female_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7Chance_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(7);
        }

        private void gossipText7BctEmote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(7);
        }

        private void gossipText7BctLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuLoaded) return;
            SaveGossipTextBct(7);
        }

        private void menuItemMenu_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemID_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemIcon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuItemLoaded) return;
            ModGossipMenuItem();
        }

        private void menuItemText_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemOptionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!MenuItemLoaded) return;
            ModGossipMenuItem();
        }

        private void menuItemNpcFlag_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemAction_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemPOI_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemCoded_Click(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemMoney_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemBoxText_LostFocus(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void menuItemSingleTimeCheck_Click(object sender, RoutedEventArgs e)
        {
            ModGossipMenuItem();
        }

        private void gossipNew_Click(object sender, RoutedEventArgs e)
        {
            GossipMenu menu = LegacyWorld.CreateNewGossipMenu();
            LoadGossipMenus();
        }

        private void gossipMenu_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_SelectedGossipMenu == null)
                return;
            _SelectedGossipMenu.Menu = Convert.ToInt32(gossipMenu.Text);
        }

        private void gossipText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_SelectedGossipMenu == null)
                return;
            _SelectedGossipMenu.NpcText = Convert.ToInt32(gossipText.Text);
        }

        private void gossipMenuComment_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_SelectedGossipMenu == null)
                return;
            _SelectedGossipMenu.Comment = gossipMenuComment.Text;
        }

        private void gossipMenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            if (_SelectedGossipMenu == null)
                return;
            LegacyWorld.CreateNewGossipMenuItem(_SelectedGossipMenu.Menu);
            LoadGossipMenuItems(_SelectedGossipMenu.Menu);
        }

        private void menuItemTextBtn_Click(object sender, RoutedEventArgs e)
        {
            new BroadcastTextEditor(Convert.ToInt32(menuItemText.Text), menuItemText).Show();
        }

        private void menuItemBoxTextBtn_Click(object sender, RoutedEventArgs e)
        {
            new BroadcastTextEditor(Convert.ToInt32(menuItemBoxText.Text), menuItemBoxText).Show();
        }

        private void menuItemActionBtn_Click(object sender, RoutedEventArgs e)
        {
            int action = Convert.ToInt32(menuItemAction.Text);
            if (action == 0)
                return;
            List<GossipMenu> menu = LegacyWorld.GetGossipMenu(action);
            if (menu.Count == 0)
                return;
            // todo: deal with multiple menu case
            LoadGossipMenu(menu[0]);
        }

        private void menuItemNpcFlagBtn_Click(object sender, RoutedEventArgs e)
        {
            new NpcFlagSelector(menuItemNpcFlag).Show();
        }

        private void menuItemSave_Click(object sender, RoutedEventArgs e)
        {
            LegacyWorld.SaveGossipMenuItem(_SelectedMenuItem);
        }

        private void menuItemText_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SelectedMenuItem.GossipTextID = Convert.ToInt32(menuItemText.Text);
        }

        private void menuItemNpcFlag_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SelectedMenuItem.NpcFlags = Convert.ToInt64(menuItemNpcFlag.Text);
        }

        private void menuItemBoxText_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SelectedMenuItem.BoxTextID = Convert.ToInt32(menuItemBoxText.Text);
        }

        private void gossipText0New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[0] = text.ID;
            gossipText0Bct.Text = text.ID.ToString();
        }

        private void gossipText1New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[1] = text.ID;
            gossipText1Bct.Text = text.ID.ToString();
        }

        private void gossipText2New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[2] = text.ID;
            gossipText2Bct.Text = text.ID.ToString();
        }

        private void gossipText3New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[3] = text.ID;
            gossipText3Bct.Text = text.ID.ToString();
        }

        private void gossipText4New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[4] = text.ID;
            gossipText4Bct.Text = text.ID.ToString();
        }

        private void gossipText5New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[5] = text.ID;
            gossipText5Bct.Text = text.ID.ToString();
        }

        private void gossipText6New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[6] = text.ID;
            gossipText6Bct.Text = text.ID.ToString();
        }

        private void gossipText7New_Click(object sender, RoutedEventArgs e)
        {
            BroadCastText text = LegacyWorld.CreateNewBroadcastText();
            _SelectedNpcText.Text[7] = text.ID;
            gossipText7Bct.Text = text.ID.ToString();
        }

        private void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            LegacyWorld.DeleteGossipMenuItem(_SelectedMenuItem);
            LoadGossipMenuItems(_SelectedMenuItem.Menu);
            _SelectedMenuItem = null;
        }
    }
}
