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
    /// SpellCastInterrupt.xaml 的交互逻辑
    /// </summary>
    public partial class SpellCastInterruptSelector : MetroWindow
    {
        SpellTemplate _spell;
        public SpellCastInterruptSelector(SpellTemplate spell)
        {
            InitializeComponent();
            this.Title = "CAST INTERRUPT of " + spell.ID;
            _spell = spell;
            uint flags = spell.InterruptFlags;
            if ((flags & 1 << 0) != 0)
                p.IsChecked = true;
            if ((flags & 1 << 1) != 0)
                p1.IsChecked = true;
            if ((flags & 1 << 2) != 0)
                p2.IsChecked = true;
            if ((flags & 1 << 3) != 0)
                p3.IsChecked = true;
            if ((flags & 1 << 4) != 0)
                p4.IsChecked = true;
            if ((flags & 1 << 5) != 0)
                p5.IsChecked = true;
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
            _spell.InterruptFlags = value;
        }
    }
}
