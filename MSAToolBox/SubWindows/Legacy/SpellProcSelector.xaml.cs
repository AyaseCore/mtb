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

namespace MSAToolBox.SubWindows
{
    /// <summary>
    /// SpellProc.xaml 的交互逻辑
    /// </summary>
    public partial class SpellProcSelector : MetroWindow
    {
        SpellTemplate _spell;
        public SpellProcSelector(SpellTemplate spell)
        {
            InitializeComponent();
            _spell = spell;
            uint proc = spell.Proc;
            this.Title = "PROC of SPELL " + spell.ID;
            if ((proc & (1 << 0)) != 0)
                p.IsChecked = true;
            if ((proc & (1 << 1)) != 0)
                p1.IsChecked = true;
            if ((proc & (1 << 2)) != 0)
                p2.IsChecked = true;
            if ((proc & (1 << 3)) != 0)
                p3.IsChecked = true;
            if ((proc & (1 << 4)) != 0)
                p4.IsChecked = true;
            if ((proc & (1 << 5)) != 0)
                p5.IsChecked = true;
            if ((proc & (1 << 6)) != 0)
                p6.IsChecked = true;
            if ((proc & (1 << 7)) != 0)
                p7.IsChecked = true;
            if ((proc & (1 << 8)) != 0)
                p8.IsChecked = true;
            if ((proc & (1 << 9)) != 0)
                p9.IsChecked = true;
            if ((proc & (1 << 10)) != 0)
                p10.IsChecked = true;
            if ((proc & (1 << 11)) != 0)
                p11.IsChecked = true;
            if ((proc & (1 << 12)) != 0)
                p12.IsChecked = true;
            if ((proc & (1 << 13)) != 0)
                p13.IsChecked = true;
            if ((proc & (1 << 14)) != 0)
                p14.IsChecked = true;
            if ((proc & (1 << 15)) != 0)
                p15.IsChecked = true;
            if ((proc & (1 << 16)) != 0)
                p16.IsChecked = true;
            if ((proc & (1 << 17)) != 0)
                p17.IsChecked = true;
            if ((proc & (1 << 18)) != 0)
                p18.IsChecked = true;
            if ((proc & (1 << 19)) != 0)
                p19.IsChecked = true;
            if ((proc & (1 << 20)) != 0)
                p20.IsChecked = true;
            if ((proc & (1 << 21)) != 0)
                p21.IsChecked = true;
            if ((proc & (1 << 22)) != 0)
                p22.IsChecked = true;
            if ((proc & (1 << 23)) != 0)
                p23.IsChecked = true;
            if ((proc & (1 << 24)) != 0)
                p24.IsChecked = true;
        }
        private void p_Click(object sender, RoutedEventArgs e)
        {
            uint value = 0;
            if (p.IsChecked == true)
                value += 1 << 0;
            if (p1.IsChecked == true)
                value += 1 << 1;
            if (p2.IsChecked == true)
                value += 1 << 2;
            if (p3.IsChecked == true)
                value += 1 << 3;
            if (p4.IsChecked == true)
                value += 1 << 4;
            if (p5.IsChecked == true)
                value += 1 << 5;
            if (p6.IsChecked == true)
                value += 1 << 6;
            if (p7.IsChecked == true)
                value += 1 << 7;
            if (p8.IsChecked == true)
                value += 1 << 8;
            if (p9.IsChecked == true)
                value += 1 << 9;
            if (p10.IsChecked == true)
                value += 1 << 10;
            if (p11.IsChecked == true)
                value += 1 << 11;
            if (p12.IsChecked == true)
                value += 1 << 12;
            if (p13.IsChecked == true)
                value += 1 << 13;
            if (p14.IsChecked == true)
                value += 1 << 14;
            if (p15.IsChecked == true)
                value += 1 << 15;
            if (p16.IsChecked == true)
                value += 1 << 16;
            if (p17.IsChecked == true)
                value += 1 << 17;
            if (p18.IsChecked == true)
                value += 1 << 18;
            if (p19.IsChecked == true)
                value += 1 << 19;
            if (p20.IsChecked == true)
                value += 1 << 20;
            if (p21.IsChecked == true)
                value += 1 << 21;
            if (p22.IsChecked == true)
                value += 1 << 22;
            if (p23.IsChecked == true)
                value += 1 << 23;
            if (p24.IsChecked == true)
                value += 1 << 24;
            _spell.Proc = value;
        }
    }
}
