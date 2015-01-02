using MSAToolBox.LegacyServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// LegacyCreatureTemplateControl.xaml 的交互逻辑
    /// </summary>
    public partial class CreaturePanel : UserControl
    {
        private List<CreatureInfo> CreatureList;
        private List<Creature> CreatureSpawnList;
        private CreatureTemplate CreatureData;
        public CreaturePanel()
        {
            InitializeComponent();
            GetCreatureList();
        }

        private void GetCreatureList()
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    CreatureList = client.GetCreatureList().ToList();
                    creatureList.ItemsSource = CreatureList;
                    creatureList.Items.SortDescriptions.Clear();
                    creatureList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Entry", System.ComponentModel.ListSortDirection.Descending));
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void creatureList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (creatureList.SelectedValue == null)
                return;

            int entry = (int)creatureList.SelectedValue;
            Load(entry);
        }

        private void Load(int entry)
        {
            if (entry == 0)
                return;

            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    if (CreatureData != null)
                        client.SaveCreatureTemplate(CreatureData);
                    Load(client.GetCreatureTemplate(entry));
                    CreatureSpawnList = client.GetSpawnInfo(entry).ToList();
                    creatureSpawn.Load(CreatureSpawnList);
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void Load(CreatureTemplate creature)
        {
            CreatureData = creature;
            creatureTab.DataContext = CreatureData;
        }

        private void creatureCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    if (CreatureData != null)
                    {
                        CreatureData.Entry[0] = 0;
                        CreatureTemplate creature = client.SaveCreatureTemplate(CreatureData);
                        Load(creature);
                        GetCreatureList();
                    }
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void creatureDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CreatureData != null)
            {
                try
                {
                    using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                    {
                        client.DeleteCreatureTemplate(CreatureData.Entry[0]);
                        Load(null);
                        GetCreatureList();
                    }
                }
                catch (System.Exception /*ex*/) { }
            }
        }
    }
}
