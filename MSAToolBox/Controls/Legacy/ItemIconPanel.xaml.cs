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
using System.IO;
using System.Text.RegularExpressions;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// ItemIconPanel.xaml 的交互逻辑
    /// </summary>
    using LegacyIcon = System.Windows.Controls.Image;
    public partial class ItemIconPanel : UserControl
    {
        public static Dictionary<int, string> IconFileNameStore;
        public static Dictionary<int, LegacyIcon> SpellIconsStore;

        public ItemIconPanel()
        {
            InitializeComponent();
        }

        public void LoadAllIcons()
        {
            IconFileNameStore = new Dictionary<int, string>();
            DirectoryInfo dir = new DirectoryInfo(MainWindow.ASSET_PATH + "Interface/Icons/");
            int index = 0;
            FileInfo[] fileInfo = dir.GetFiles("*.png");
            int count = fileInfo.Length;
            itemIcons.Children.Clear();
            foreach (FileInfo f in fileInfo)
            {
                ++index;
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(f.FullName, UriKind.Absolute));
                    LegacyIcon icon = new LegacyIcon();
                    icon.Source = image;
                    icon.Width = 40;
                    icon.Height = 40;
                    icon.MouseEnter += icon_MouseEnter;
                    icon.MouseLeave += icon_MouseLeave;
                    icon.MouseDown += icon_MouseDown;
                    icon.Margin = new Thickness(2);
                    icon.Name = "itemIcon" + index;
                    itemIcons.Children.Add(icon);
                    IconFileNameStore.Add(index, f.Name);
                }
                catch (System.Exception /*ex*/)
                {

                }
            }
        }

        void icon_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        void icon_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        void icon_MouseEnter(object sender, MouseEventArgs e)
        {
        }

    }
}
