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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MSAToolBox.LegacyServices;

namespace MSAToolBox.SubWindows.Legacy
{
    /// <summary>
    /// ItemFlags.xaml 的交互逻辑
    /// </summary>
    public partial class ItemFlagsSelector : MetroWindow
    {
        private ItemTemplate _Item;
        public ItemFlagsSelector(ItemTemplate item)
        {
            _Item = item;
            long flags = _Item.Flags;
            InitializeComponent();
            itemFlag.IsChecked = (flags & (1 << 0)) != 0;
            itemFlag1.IsChecked = (flags & (1 << 1)) != 0;
            itemFlag2.IsChecked = (flags & (1 << 2)) != 0;
            itemFlag3.IsChecked = (flags & (1 << 3)) != 0;
            itemFlag4.IsChecked = (flags & (1 << 4)) != 0;
            itemFlag5.IsChecked = (flags & (1 << 5)) != 0;
            itemFlag6.IsChecked = (flags & (1 << 6)) != 0;
            itemFlag7.IsChecked = (flags & (1 << 7)) != 0;
            itemFlag8.IsChecked = (flags & (1 << 8)) != 0;
            itemFlag9.IsChecked = (flags & (1 << 9)) != 0;
            itemFlag10.IsChecked = (flags & (1 << 10)) != 0;
            itemFlag11.IsChecked = (flags & (1 << 11)) != 0;
            itemFlag12.IsChecked = (flags & (1 << 12)) != 0;
            itemFlag13.IsChecked = (flags & (1 << 13)) != 0;
            itemFlag14.IsChecked = (flags & (1 << 14)) != 0;
            itemFlag15.IsChecked = (flags & (1 << 15)) != 0;
            itemFlag16.IsChecked = (flags & (1 << 16)) != 0;
            itemFlag17.IsChecked = (flags & (1 << 17)) != 0;
            itemFlag18.IsChecked = (flags & (1 << 18)) != 0;
            itemFlag19.IsChecked = (flags & (1 << 19)) != 0;
            itemFlag20.IsChecked = (flags & (1 << 20)) != 0;
            itemFlag21.IsChecked = (flags & (1 << 21)) != 0;
            itemFlag22.IsChecked = (flags & (1 << 22)) != 0;
            itemFlag23.IsChecked = (flags & (1 << 23)) != 0;
            itemFlag24.IsChecked = (flags & (1 << 24)) != 0;
            itemFlag25.IsChecked = (flags & (1 << 25)) != 0;
            itemFlag26.IsChecked = (flags & (1 << 26)) != 0;
            itemFlag27.IsChecked = (flags & (1 << 27)) != 0;
            itemFlag28.IsChecked = (flags & (1 << 28)) != 0;
            itemFlag29.IsChecked = (flags & (1 << 29)) != 0;
            itemFlag30.IsChecked = (flags & (1 << 30)) != 0;
            itemFlag31.IsChecked = (flags & 0x80000000) != 0;
            itemFlag.Click += UpdateFlags;
            itemFlag1.Click += UpdateFlags;
            itemFlag2.Click += UpdateFlags;
            itemFlag3.Click += UpdateFlags;
            itemFlag4.Click += UpdateFlags;
            itemFlag5.Click += UpdateFlags;
            itemFlag6.Click += UpdateFlags;
            itemFlag7.Click += UpdateFlags;
            itemFlag8.Click += UpdateFlags;
            itemFlag9.Click += UpdateFlags;
            itemFlag10.Click += UpdateFlags;
            itemFlag11.Click += UpdateFlags;
            itemFlag12.Click += UpdateFlags;
            itemFlag13.Click += UpdateFlags;
            itemFlag14.Click += UpdateFlags;
            itemFlag15.Click += UpdateFlags;
            itemFlag16.Click += UpdateFlags;
            itemFlag17.Click += UpdateFlags;
            itemFlag18.Click += UpdateFlags;
            itemFlag19.Click += UpdateFlags;
            itemFlag20.Click += UpdateFlags;
            itemFlag21.Click += UpdateFlags;
            itemFlag22.Click += UpdateFlags;
            itemFlag23.Click += UpdateFlags;
            itemFlag24.Click += UpdateFlags;
            itemFlag25.Click += UpdateFlags;
            itemFlag26.Click += UpdateFlags;
            itemFlag27.Click += UpdateFlags;
            itemFlag28.Click += UpdateFlags;
            itemFlag29.Click += UpdateFlags;
            itemFlag30.Click += UpdateFlags;
            itemFlag31.Click += UpdateFlags;
        }

        private void UpdateFlags(object sender, RoutedEventArgs e)
        {
            long flag = 0;
            flag += itemFlag.IsChecked == true ? 1 << 0 : 0;
            flag += itemFlag1.IsChecked == true ? 1 << 1 : 0;
            flag += itemFlag2.IsChecked == true ? 1 << 2 : 0;
            flag += itemFlag3.IsChecked == true ? 1 << 3 : 0;
            flag += itemFlag4.IsChecked == true ? 1 << 4 : 0;
            flag += itemFlag5.IsChecked == true ? 1 << 5 : 0;
            flag += itemFlag6.IsChecked == true ? 1 << 6 : 0;
            flag += itemFlag7.IsChecked == true ? 1 << 7 : 0;
            flag += itemFlag8.IsChecked == true ? 1 << 8 : 0;
            flag += itemFlag9.IsChecked == true ? 1 << 9 : 0;
            flag += itemFlag10.IsChecked == true ? 1 << 10 : 0;
            flag += itemFlag11.IsChecked == true ? 1 << 11 : 0;
            flag += itemFlag12.IsChecked == true ? 1 << 12 : 0;
            flag += itemFlag13.IsChecked == true ? 1 << 13 : 0;
            flag += itemFlag14.IsChecked == true ? 1 << 14 : 0;
            flag += itemFlag15.IsChecked == true ? 1 << 15 : 0;
            flag += itemFlag16.IsChecked == true ? 1 << 16 : 0;
            flag += itemFlag17.IsChecked == true ? 1 << 17 : 0;
            flag += itemFlag18.IsChecked == true ? 1 << 18 : 0;
            flag += itemFlag19.IsChecked == true ? 1 << 19 : 0;
            flag += itemFlag20.IsChecked == true ? 1 << 20 : 0;
            flag += itemFlag21.IsChecked == true ? 1 << 21 : 0;
            flag += itemFlag22.IsChecked == true ? 1 << 22 : 0;
            flag += itemFlag23.IsChecked == true ? 1 << 23 : 0;
            flag += itemFlag24.IsChecked == true ? 1 << 24 : 0;
            flag += itemFlag25.IsChecked == true ? 1 << 25 : 0;
            flag += itemFlag26.IsChecked == true ? 1 << 26 : 0;
            flag += itemFlag27.IsChecked == true ? 1 << 27 : 0;
            flag += itemFlag28.IsChecked == true ? 1 << 28 : 0;
            flag += itemFlag29.IsChecked == true ? 1 << 29 : 0;
            flag += itemFlag30.IsChecked == true ? 1 << 30 : 0;
            flag += itemFlag31.IsChecked == true ? 0x80000000 : 0;
            _Item.Flags = flag;
        }
    }
}
