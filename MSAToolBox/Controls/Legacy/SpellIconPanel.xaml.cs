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
    using MSAToolBox.Utility;
using SpellIcon = System.Windows.Controls.Image;
    /// <summary>
    /// SpellIconPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SpellIconPanel : UserControl
    {
        public static Dictionary<int, SpellIcon> SpellIconStore;
        private SpellTemplate _spell;

        public SpellIconPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            SpellIconStore = new Dictionary<int, SpellIcon>();
            foreach (var icon in LegacyMorpher.DefineStore.SpellIcon)
            {
                string path = MainWindow.ASSET_PATH + icon.Value + ".png";
                if (File.Exists(path))
                {
                    BitmapImage image = new BitmapImage(new Uri(path, UriKind.Absolute));
                    Grid g = new Grid();
                    g.Width = 68;
                    g.Height = 68;
                    g.MouseEnter += HighlightIconBg;
                    g.MouseLeave += UnhighlightIconBg;
                    SpellIcon spellIcon = new SpellIcon();
                    spellIcon.Width = 64;
                    spellIcon.Height = 64;
                    spellIcon.Margin = new Thickness(2);
                    spellIcon.Source = image;
                    spellIcon.MouseDown += SpellIcon_Click;
                    spellIcon.Name = "spIcon" + icon.Key;
                    g.Children.Add(spellIcon);
                    SpellIconStore.Add(icon.Key, spellIcon);
                    Label label = new Label();
                    label.HorizontalAlignment = HorizontalAlignment.Stretch;
                    label.VerticalAlignment = VerticalAlignment.Top;
                    label.Padding = new System.Windows.Thickness(2);
                    label.Margin = new System.Windows.Thickness(0, 10, 36, 0);
                    label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    label.Background = new SolidColorBrush(Colors.Black);
                    label.Background.Opacity = 0.8;
                    label.Content = icon.Key.ToString();
                    g.Children.Add(label);
                    g.Name = "spIconBg" + icon.Key;
                    spellIcons.Children.Add(g);
                }
            }
        }

        public void Load(SpellTemplate spell)
        {
            _spell = spell;
            HighlightSelectedSpellIcon();
        }

        private void HighlightIconBg(object sender, EventArgs e)
        {
            if (_spell == null)
                return;

            Grid g = (Grid)sender;
            if (g.Name != ("spIconBg" + (spIconRadio.IsChecked == true ? _spell.Icon : _spell.ActiveIcon)))
                g.Background = new SolidColorBrush(Colors.Red);
        }

        private void UnhighlightIconBg(object sender, EventArgs e)
        {
            if (_spell == null)
                return;

            Grid g = (Grid)sender;
            if (g.Name != ("spIconBg" + (spIconRadio.IsChecked == true ? _spell.Icon : _spell.ActiveIcon)))
                g.Background = null;
        }

        private void SpellIcon_Click(object sender, RoutedEventArgs e)
        {
            SpellIcon icon = (SpellIcon)sender;
            try
            {
                // name format:
                // spIconXXXXX
                uint id = Convert.ToUInt32(icon.Name.Substring(6));
                if (spIconRadio.IsChecked == true)
                    _spell.Icon = id;
                else
                    _spell.ActiveIcon = id;
                HighlightSelectedSpellIcon();
            }
            catch (System.Exception /*ex*/)
            {

            }
        }

        public void HighlightSelectedSpellIcon()
        {
            if (_spell == null)
                return;
            if ((spIconRadio.IsChecked == true && _spell.Icon == 0) ||
                spActiveIconRadio.IsChecked == true && _spell.ActiveIcon == 0)
                spIconCurrent.Source = null;
            foreach (Grid g in spellIcons.Children)
            {
                if (g.Name == ("spIconBg" + (spIconRadio.IsChecked == true ? _spell.Icon : _spell.ActiveIcon)))
                {
                    g.Background = new SolidColorBrush(Colors.Green);
                    foreach (var c in g.Children)
                    {
                        if (c.GetType() == typeof(SpellIcon))
                        {
                            SpellIcon icon = (SpellIcon)c;
                            spIconCurrent.Source = icon.Source;
                        }
                    }
                }
                else
                    g.Background = null;
            }
        }
    }
}
