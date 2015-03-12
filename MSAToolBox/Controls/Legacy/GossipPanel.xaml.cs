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

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// GossipPanel.xaml 的交互逻辑
    /// </summary>
    public partial class GossipPanel : UserControl
    {
        public static List<GossipMenu> GossipMenuData;
        public static List<GossipMenuItem> GossipMenuItemData;

        public GossipPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            GossipMenuData = LegacyWorld.GetAllGossipMenu();
            gossipMenuList.ItemsSource = GossipMenuData;
        }

        private void gossipMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GossipMenuData == null)
                return;

            GossipMenu menu = gossipMenuList.SelectedItem as GossipMenu;
            NpcText text = LegacyWorld.GetGossipNpcText(menu.NpcText);
            if (text == null)
                return;
            BroadCastText bct = LegacyWorld.GetBroadCastText(text.Text[0]);
            if (bct == null)
                return;
            gossipTextMale0.Text = bct.MaleText;
            gossipTextFemale0.Text = bct.FemaleText;
            gossipTextChance0.Text = text.Chance[0].ToString();

            List<GossipMenuItem> menuItems = LegacyWorld.GetGossipMenuItems(menu.Menu);
            gossipMenuItems.ItemsSource = menuItems;
        }
    }
}
