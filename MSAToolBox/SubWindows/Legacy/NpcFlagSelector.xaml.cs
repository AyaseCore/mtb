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
using MSAToolBox.Utility;

namespace MSAToolBox.SubWindows.Legacy
{
    /// <summary>
    /// CreatureNpcFlagSelector.xaml 的交互逻辑
    /// </summary>
    public partial class NpcFlagSelector : MetroWindow
    {
        private TextBox _Box;
        public NpcFlagSelector(TextBox box)
        {
            InitializeComponent();
            _Box = box;
            long flags = Convert.ToInt64(box.Text);
            CheckFlags(flags);
        }

        private void CheckFlags(long flags)
        {
            if ((flags & 1 << 0) != 0)
                npcFlag1.IsChecked = true;
            if ((flags & 1 << 1) != 0)
                npcFlag2.IsChecked = true;
            if ((flags & 1 << 2) != 0)
                npcFlag3.IsChecked = true;
            if ((flags & 1 << 3) != 0)
                npcFlag4.IsChecked = true;
            if ((flags & 1 << 4) != 0)
                npcFlag5.IsChecked = true;
            if ((flags & 1 << 5) != 0)
                npcFlag6.IsChecked = true;
            if ((flags & 1 << 6) != 0)
                npcFlag7.IsChecked = true;
            if ((flags & 1 << 7) != 0)
                npcFlag8.IsChecked = true;
            if ((flags & 1 << 8) != 0)
                npcFlag9.IsChecked = true;
            if ((flags & 1 << 9) != 0)
                npcFlag10.IsChecked = true;
            if ((flags & 1 << 10) != 0)
                npcFlag11.IsChecked = true;
            if ((flags & 1 << 11) != 0)
                npcFlag12.IsChecked = true;
            if ((flags & 1 << 12) != 0)
                npcFlag13.IsChecked = true;
            if ((flags & 1 << 13) != 0)
                npcFlag14.IsChecked = true;
            if ((flags & 1 << 14) != 0)
                npcFlag15.IsChecked = true;
            if ((flags & 1 << 15) != 0)
                npcFlag16.IsChecked = true;
            if ((flags & 1 << 16) != 0)
                npcFlag17.IsChecked = true;
            if ((flags & 1 << 17) != 0)
                npcFlag18.IsChecked = true;
            if ((flags & 1 << 18) != 0)
                npcFlag19.IsChecked = true;
            if ((flags & 1 << 19) != 0)
                npcFlag20.IsChecked = true;
            if ((flags & 1 << 20) != 0)
                npcFlag21.IsChecked = true;
            if ((flags & 1 << 21) != 0)
                npcFlag22.IsChecked = true;
            if ((flags & 1 << 22) != 0)
                npcFlag23.IsChecked = true;
            if ((flags & 1 << 23) != 0)
                npcFlag24.IsChecked = true;
            if ((flags & 1 << 24) != 0)
                npcFlag25.IsChecked = true;
            if ((flags & 1 << 25) != 0)
                npcFlag26.IsChecked = true;
            if ((flags & 1 << 26) != 0)
                npcFlag27.IsChecked = true;
        }

        private void UpdateFlags()
        {
            if (_Box == null)
                return;

            long flag = 0;
            if (npcFlag1.IsChecked == true)
                flag += 1 << 0;
            if (npcFlag2.IsChecked == true)
                flag += 1 << 1;
            if (npcFlag3.IsChecked == true)
                flag += 1 << 2;
            if (npcFlag4.IsChecked == true)
                flag += 1 << 3;
            if (npcFlag5.IsChecked == true)
                flag += 1 << 4;
            if (npcFlag6.IsChecked == true)
                flag += 1 << 5;
            if (npcFlag7.IsChecked == true)
                flag += 1 << 6;
            if (npcFlag8.IsChecked == true)
                flag += 1 << 7;
            if (npcFlag9.IsChecked == true)
                flag += 1 << 8;
            if (npcFlag10.IsChecked == true)
                flag += 1 << 9;
            if (npcFlag11.IsChecked == true)
                flag += 1 << 10;
            if (npcFlag12.IsChecked == true)
                flag += 1 << 11;
            if (npcFlag13.IsChecked == true)
                flag += 1 << 12;
            if (npcFlag14.IsChecked == true)
                flag += 1 << 13;
            if (npcFlag15.IsChecked == true)
                flag += 1 << 14;
            if (npcFlag16.IsChecked == true)
                flag += 1 << 15;
            if (npcFlag17.IsChecked == true)
                flag += 1 << 16;
            if (npcFlag18.IsChecked == true)
                flag += 1 << 17;
            if (npcFlag19.IsChecked == true)
                flag += 1 << 18;
            if (npcFlag20.IsChecked == true)
                flag += 1 << 19;
            if (npcFlag21.IsChecked == true)
                flag += 1 << 20;
            if (npcFlag22.IsChecked == true)
                flag += 1 << 21;
            if (npcFlag23.IsChecked == true)
                flag += 1 << 22;
            if (npcFlag24.IsChecked == true)
                flag += 1 << 23;
            if (npcFlag25.IsChecked == true)
                flag += 1 << 24;
            if (npcFlag26.IsChecked == true)
                flag += 1 << 25;
            if (npcFlag27.IsChecked == true)
                flag += 1 << 26;

            _Box.Text = flag.ToString();
        }

        private void npcFlag1_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag2_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag3_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag4_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag5_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag6_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag7_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag8_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag9_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag10_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag11_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag12_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag13_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag14_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag15_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag16_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag17_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag18_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag19_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag20_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag21_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag22_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag23_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag24_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag25_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag26_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }

        private void npcFlag27_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }
    }
}
