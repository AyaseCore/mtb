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
using MSAToolBox.SubWindows.Legacy;
using MSAToolBox.Utility;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// LegacyCreatureTemplateControl.xaml 的交互逻辑
    /// </summary>
    public partial class CreaturePanel : UserControl
    {
        public static List<CreatureInfo> CreatureList;
        private List<Creature> CreatureSpawnList;
        private CreatureTemplate CreatureData;
        public CreaturePanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            GetCreatureList();
            creatureGossipPanel.Load();
        }

        private void GetCreatureList()
        {
            CreatureList = LegacyMorpher.Data.GetCreatureList().ToList();
            creatureList.ItemsSource = CreatureList;
            creatureList.Items.SortDescriptions.Clear();
            creatureList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Entry", System.ComponentModel.ListSortDirection.Descending));
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

            if (CreatureData != null)
                LegacyMorpher.Data.SaveCreatureTemplate(CreatureData);
            Load(LegacyMorpher.Data.GetCreatureTemplate(entry));
            CreatureSpawnList = LegacyMorpher.Data.GetSpawnInfo(entry);
            creatureSpawn.Load(CreatureSpawnList);

            creatureTrainerPanel.Load(entry);
            creatureLootPanel.Load(entry);
            vendorPanel.Load(entry);
        }

        private void Load(CreatureTemplate creature)
        {
            CreatureData = creature;
            creatureTab.DataContext = CreatureData;
        }

        private void creatureCopy_Click(object sender, RoutedEventArgs e)
        {
            if (CreatureData != null)
            {
                CreatureData.Entry[0] = 0;
                CreatureTemplate creature = LegacyMorpher.Data.SaveCreatureTemplate(CreatureData);
                Load(creature);
                GetCreatureList();
            }
        }

        private void creatureDelete_Click(object sender, RoutedEventArgs e)
        {
            LegacyMorpher.Data.DeleteCreatureTemplate(CreatureData.Entry[0]);
            Load(null);
            GetCreatureList();
        }

        private void ApplySearchFilter()
        {
            creatureList.Items.Filter = delegate(object obj)
            {
                string name = searchFilter.Text;
                if (name == "")
                    return true;
                CreatureInfo creature = (CreatureInfo)obj;
                return creature.Name.Contains(name) || creature.Entry.ToString().Contains(name);
            };
        }

        private void searchFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplySearchFilter();
        }

        public void ModCreatureLevels()
        {
            foreach (var c in CreatureList)
            {
                CreatureTemplate creature = LegacyMorpher.Data.GetCreatureTemplate(c.Entry);
                float level = (creature.MinLevel+creature.MaxLevel)/2;
                creature.HealthModifier *= level / 20;
            }
        }

        private void npcFlagsBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreatureNpcFlagSelector(CreatureData).Show();
        }
    }
}
