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

namespace MSAToolBox.Controls.Legacy
{
    using System.Text.RegularExpressions;
    /// <summary>
    /// IconPanel.xaml 的交互逻辑
    /// </summary>
    using SpellIcon = System.Windows.Controls.Image;
    using MSAToolBox.Utility;
    public partial class IconPanel : UserControl
    {
        private Dictionary<int, string> iconFileNameStore;
        private ItemTemplate Item;
        private int SelectedIcon;
        private List<ItemDisplayInfo> ItemDisplayInfoList;
        private string SelectedIconName;
        public IconPanel()
        {
            InitializeComponent();
            LoadAllIcons();
            LoadItemDisplayInfoDBC();
        }

        public void Load(ItemTemplate item)
        {
            Item = item;
        }

        public void Load()
        {
            itemGroupSound.ItemsSource = DataDefine.ItemGroupSound;
        }

        public void LoadAllIcons()
        {
            itemGroupSound.SelectedValuePath = "Key";
            itemGroupSound.DisplayMemberPath = "Value";
            iconFileNameStore = new Dictionary<int, string>();
            DirectoryInfo dir = new DirectoryInfo(MainWindow.ASSET_PATH + "Interface/Icons/");
            int index = 0;
            FileInfo[] fileInfo = dir.GetFiles("*.png");
            int count = fileInfo.Length;
            itemIcons.Children.Clear();
            itemIconProgress.Maximum = count;
            foreach (FileInfo f in fileInfo)
            {
                ++index;
                try
                {
                    itemIconProgress.Value = index;
                    itemIconProgressLabel.Content = "Processing " + index + " of " + count;
                    BitmapImage image = new BitmapImage(new Uri(f.FullName, UriKind.Absolute));
                    SpellIcon icon = new SpellIcon();
                    icon.Source = image;
                    icon.Width = 40;
                    icon.Height = 40;
                    icon.MouseEnter += icon_MouseEnter;
                    icon.MouseLeave += icon_MouseLeave;
                    icon.MouseDown += icon_MouseDown;
                    icon.Margin = new Thickness(2);
                    icon.Name = "itemIcon" + index;
                    itemIcons.Children.Add(icon);
                }
                catch (System.Exception /*ex*/)
                {

                }
                iconFileNameStore.Add(index, f.Name);
            }
        }

        void icon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SpellIcon icon = sender as SpellIcon;
            string[] c = Regex.Split(icon.Name, "itemIcon(\\d+)");
            SelectedIcon = Convert.ToInt32(c[1]);
            string s = "";
            iconFileNameStore.TryGetValue(SelectedIcon, out s);
            SelectedIconName = Regex.Split(s, "([\\w|\\-]*)\\.png")[1];
            itemCreateDisplayIDResult.Text = SelectedIconName;
        }

        void icon_MouseLeave(object sender, MouseEventArgs e)
        {
            SpellIcon icon = sender as SpellIcon;
            string[] c = Regex.Split(icon.Name, "itemIcon(\\d+)");
            if (Convert.ToInt32(c[1]) != SelectedIcon)
                icon.Opacity = 1;
        }

        void icon_MouseEnter(object sender, MouseEventArgs e)
        {
            SpellIcon icon = sender as SpellIcon;
            icon.Opacity = 0.6;
        }

        void BuildItemDisplayInfoDBC()
        {
            using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/ItemDisplayInfo.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, ItemDisplayInfoList.Count, 25, 100);
                List<string> stringBlock = new List<string>();
                int ofs = 1;
                foreach (var info in ItemDisplayInfoList)
                {
                    w.Write(info.ID);
                    DBC.WriteString(w, info.LeftModel, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.RightModel, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.LeftModelTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.RightModelTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.Icon1, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.Icon2, ref ofs, ref stringBlock);
                    w.Write(info.GeosetGroup1);
                    w.Write(info.GeosetGroup2);
                    w.Write(info.GeosetGroup3);
                    w.Write(info.Flags);
                    w.Write(info.SpellVisualID);
                    w.Write(info.GroupSoundIndex);
                    w.Write(info.HelmetGeosetMale);
                    w.Write(info.HelmetGeosetFemale);
                    DBC.WriteString(w, info.UpperArmTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.LowerArmTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.HandsTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.UpperTorsoTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.LowerTorsoTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.UpperLegTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.LowerLegTexture, ref ofs, ref stringBlock);
                    DBC.WriteString(w, info.FootTexture, ref ofs, ref stringBlock);
                    w.Write(info.ItemVisual);
                    w.Write(info.ParticleColorID);
                }
                w.Write((byte)0);
                foreach (var s in stringBlock)
                    w.Write(Encoding.UTF8.GetBytes(s + "\0"));
                stream.Position = 16;
                w.Write(ofs);
                w.Close();
            }
        }

        void LoadItemDisplayInfoDBC()
        {
            ItemDisplayInfoList = new List<ItemDisplayInfo>();
            using (FileStream stream = File.OpenRead(MainWindow.CLIENT_PATH + "DBFilesClient/ItemDisplayInfo.dbc"))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int fields = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringBlockSize = r.ReadInt32();
                int dataSize = rowSize * records + 20;
                for (int i = 0; i != records; ++i)
                {
                    ItemDisplayInfo info = new ItemDisplayInfo();
                    info.ID = r.ReadInt32();
                    info.LeftModel = DBC.ReadString(r, dataSize);
                    info.RightModel = DBC.ReadString(r, dataSize);
                    info.LeftModelTexture = DBC.ReadString(r, dataSize);
                    info.RightModelTexture = DBC.ReadString(r, dataSize);
                    info.Icon1 = DBC.ReadString(r, dataSize);
                    info.Icon2 = DBC.ReadString(r, dataSize);
                    info.GeosetGroup1 = r.ReadInt32();
                    info.GeosetGroup2 = r.ReadInt32();
                    info.GeosetGroup3 = r.ReadInt32();
                    info.Flags = r.ReadInt32();
                    info.SpellVisualID = r.ReadInt32();
                    info.GroupSoundIndex = r.ReadInt32();
                    info.HelmetGeosetMale = r.ReadInt32();
                    info.HelmetGeosetFemale = r.ReadInt32();
                    info.UpperArmTexture = DBC.ReadString(r, dataSize);
                    info.LowerArmTexture = DBC.ReadString(r, dataSize);
                    info.HandsTexture = DBC.ReadString(r, dataSize);
                    info.UpperTorsoTexture = DBC.ReadString(r, dataSize);
                    info.LowerTorsoTexture = DBC.ReadString(r, dataSize);
                    info.UpperLegTexture = DBC.ReadString(r, dataSize);
                    info.LowerLegTexture = DBC.ReadString(r, dataSize);
                    info.FootTexture = DBC.ReadString(r, dataSize);
                    info.ItemVisual = r.ReadInt32();
                    info.ParticleColorID = r.ReadInt32();
                    ItemDisplayInfoList.Add(info);
                }
                r.Close();
            }
        }

        private void itemIconCreateSaveDisplayId_Click(object sender, RoutedEventArgs e)
        {
            if (Item == null)
                return;
            // no need finding old ones cuz this is FAST ENOUGH!
            int id = (from d in ItemDisplayInfoList select d.ID).Max() + 1;
            int groupSound = (int)itemGroupSound.SelectedValue;
            ItemDisplayInfoList.Add(new ItemDisplayInfo()
            {
                ID = id,
                Icon1 = SelectedIconName,
                GroupSoundIndex = groupSound,
                GeosetGroup1 = 0,
                GeosetGroup2 = 0,
                GeosetGroup3 = 0,
                SpellVisualID = 0,
                HelmetGeosetFemale = 0,
                HelmetGeosetMale = 0,
                ItemVisual = 0,
                ParticleColorID = 0
            });
            Item.DisplayID = id;
            itemIconCreateID.Text = id.ToString();
            BuildItemDisplayInfoDBC();
        }

        private void itemIconFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itemIconFilter.Text == "")
            {
                foreach (SpellIcon icon in itemIcons.Children)
                {
                    icon.Visibility = Visibility.Visible;
                }
            }
            else
            {
                foreach (SpellIcon icon in itemIcons.Children)
                {
                    int id = Convert.ToInt32(Regex.Split(icon.Name, "itemIcon(\\d+)")[1]);
                    string s = "";
                    iconFileNameStore.TryGetValue(id, out s);
                    if (s.ToUpper().Contains(itemIconFilter.Text.ToUpper()))
                        icon.Visibility = Visibility.Visible;
                    else
                        icon.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
