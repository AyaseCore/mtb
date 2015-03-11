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
using System.Threading;
using MSAToolBox.Utility;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// CreatureLootPanel.xaml 的交互逻辑
    /// </summary>
    public partial class CreatureLootPanel : UserControl
    {
        public CreatureLootPanel()
        {
            InitializeComponent();
        }

        public void Load(int entry)
        {
            lootGrid.ItemsSource = LegacyWorld.GetCreatureLoot(entry, false).ToList();
        }

        public void Load(int entry, bool isRef)
        {
            lootGrid.ItemsSource = LegacyWorld.GetCreatureLoot(entry, isRef).ToList();
        }

        public void Save()
        {
            List<Loot> list = lootGrid.ItemsSource as List<Loot>;
            LegacyWorld.SaveCreatureLoot(list);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void deleteLoot_Click(object sender, RoutedEventArgs e)
        {
            if (lootGrid.SelectedItem != null)
            {
                var item = lootGrid.SelectedItem as Loot;
                var list = lootGrid.ItemsSource as List<Loot>;
                list.Remove(item);
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            int entry = Convert.ToInt32(searchEntry.Text);
            bool isref = searchIsRef.IsChecked == true;
            Load(entry, isref);
        }

        private void assignLootGo_Click(object sender, RoutedEventArgs e)
        {
            int item = Convert.ToInt32(assignLootEntry.Text);
            bool isRef = assignLootIsRef.IsChecked == true;
            int levelMin = Convert.ToInt32(assignLootLevelMin.Text);
            int levelMax = Convert.ToInt32(assignLootLevelMax.Text);
            float chance = Convert.ToSingle(assignLootChance.Text);
            new Thread(() => AssignLoots(item, isRef, levelMin, levelMax, chance)).Start();
        }

        private void AssignLoots(int item, bool isRef, int levelMin, int levelMax, float chance)
        {
            var creatureList = from d in CreaturePanel.CreatureList where d.MinLevel >= levelMin && d.MaxLevel <= levelMax select d;
            int count = creatureList.Count();
            int index = 0;
            this.Dispatcher.Invoke(new Action(() =>
            {
                assignLootProgress.Maximum = count;
            }));
            foreach (var creature in creatureList)
            {
                index++;
                CreatureTemplate cp = LegacyWorld.GetCreatureTemplate(creature.Entry);
                if ((cp.ExtraFlags & 2) != 0 || (cp.ExtraFlags & 128) != 0 || (cp.ExtraFlags & 32768) != 0 || cp.Type == 11 || cp.Type == 12 || cp.Type == 13) // skip civillian & trigger & guard
                    continue;
                Loot loot = new Loot();
                loot.Entry = creature.Entry;
                loot.Chance = chance;
                loot.GroupID = 0;
                loot.IsRef = false; // no reference defines here.
                loot.Item = item;
                loot.Reference = isRef ? item : 0;
                loot.QuestRequired = false;
                loot.MinCount = 1;
                loot.MaxCount = 1;
                loot.LootMode = 1;
                List<Loot> list = new List<Loot>();
                list.Add(loot);
                LegacyWorld.SaveCreatureLoot(list);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    assignLootProgress.Value = index;
                    assignLootProgressLabel.Content = "Proccessing " + index + " of " + count;
                }));
            }
        }
    }
}
