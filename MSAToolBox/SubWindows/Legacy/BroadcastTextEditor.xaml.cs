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
    /// BroadcastTextEditor.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class BroadcastTextEditor : MetroWindow
    {
        private BroadCastText _Text;
        private TextBox _Box;
        private bool BctLoaded = false;

        public BroadcastTextEditor(int entry, TextBox box)
        {
            InitializeComponent();
            Util.AssignDefine(language, LegacyWorld.GetLanguages());
            Util.AssignDefine(emote0, LegacyWorld.GetEmotes());
            Util.AssignDefine(emote1, LegacyWorld.GetEmotes());
            Util.AssignDefine(emote2, LegacyWorld.GetEmotes());
            _Box = box;
            _Text = LegacyWorld.GetBroadCastText(entry);
            if (_Text == null)
            {
                _Text = LegacyWorld.CreateNewBroadcastText();
                box.Text = _Text.ID.ToString();
            }
            LoadBroadcastText(_Text);
        }

        public void LoadBroadcastText(BroadCastText t)
        {
            BctLoaded = false;
            id.Text = t.ID.ToString();
            language.SelectedValue = t.Language;
            textMale.Text = t.MaleText;
            textFemale.Text = t.FemaleText;
            emote0.SelectedValue = t.Emote0;
            emote1.SelectedValue = t.Emote1;
            emote2.SelectedValue = t.Emote2;
            emoteDelay0.Text = t.EmoteDelay0.ToString();
            emoteDelay1.Text = t.EmoteDelay1.ToString();
            emoteDelay2.Text = t.EmoteDelay2.ToString();
            soundID.Text = t.SoundID.ToString();
            BctLoaded = true;
        }

        private void textMale_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.MaleText = textMale.Text;
        }

        private void textFemale_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.FemaleText = textFemale.Text;
        }

        private void emoteDelay0_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.EmoteDelay0 = Convert.ToInt32(emoteDelay0.Text);
        }

        private void emoteDelay1_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.EmoteDelay1 = Convert.ToInt32(emoteDelay1.Text);
        }

        private void emoteDelay2_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.EmoteDelay2 = Convert.ToInt32(emoteDelay2.Text);
        }

        private void soundID_LostFocus(object sender, RoutedEventArgs e)
        {
            _Text.SoundID = Convert.ToInt32(soundID.Text);
        }

        private void emote0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BctLoaded) return;
            _Text.Emote0 = Convert.ToInt32(emote0.SelectedValue);
        }

        private void emote1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BctLoaded) return;
            _Text.Emote1 = Convert.ToInt32(emote1.SelectedValue);
        }

        private void emote2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BctLoaded) return;
            _Text.Emote2 = Convert.ToInt32(emote2.SelectedValue);
        }

        private void language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BctLoaded) return;
            _Text.Language = Convert.ToInt32(language.SelectedValue);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            LegacyWorld.SaveBroadCastText(_Text);
        }
    }
}
