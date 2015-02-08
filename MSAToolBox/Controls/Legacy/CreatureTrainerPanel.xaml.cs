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
    /// CreatureTrainerPanel.xaml 的交互逻辑
    /// </summary>
    public partial class CreatureTrainerPanel : UserControl
    {
        public CreatureTrainerPanel()
        {
            InitializeComponent();
        }

        public void Load(int entry)
        {
            if (entry == 0)
            {
                trainerInfoGrid.ItemsSource = null;
                return;
            }

            var data = LegacyMorpher.Data.GetCreatureTrainerInfo(entry);
            if (data != null)
                trainerInfoGrid.ItemsSource = data.ToList();
            else
                trainerInfoGrid.ItemsSource = null;
        }

        public void Save()
        {
            List<CreatureTrainerInfo> list = trainerInfoGrid.ItemsSource as List<CreatureTrainerInfo>;
            if (list != null && list.Count != 0)
                LegacyMorpher.Data.SaveCreatureTrainerInfo(list);
            statusLabel.Content = "Saved.";
        }

        private void saveTrainerInfo_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void trainerInfoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (trainerInfoGrid.SelectedItem != null)
                {
                    var item = trainerInfoGrid.SelectedItem as CreatureTrainerInfo;
                    var list = trainerInfoGrid.ItemsSource as List<CreatureTrainerInfo>;
                    list.Remove(item);
                }
            }
        }

        private void loadVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int entry = Convert.ToInt32(loadVendorEntry.Text);

                var data = LegacyMorpher.Data.GetCreatureTrainerInfo(entry);
                if (data != null)
                    trainerInfoGrid.ItemsSource = data.ToList();
                else
                    trainerInfoGrid.ItemsSource = null;
            }
            catch (Exception /*e*/) {  }
        }
    }
}
