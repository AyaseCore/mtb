using MSAToolBox.LegacyServices;
using MSAToolBox.SubWindows.Legacy;
using MSAToolBox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSAToolBox.Controls.Legacy
{
    /// <summary>
    /// LegacyItemPage.xaml 的交互逻辑
    /// </summary>
    public partial class ItemPanel : UserControl
    {
        public static ItemTemplate ItemData;
        //private bool Modified;
        public static ItemInfo[] ItemList;
        bool IsLoading;
        Random ran = new Random();
        public ItemPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            LoadDefines();
        }

        private void LoadDefines()
        {
            IsLoading = true;
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    ItemList = client.GetItemList();
                    itemList.ItemsSource = ItemList;
                    itemList.Items.SortDescriptions.Clear();
                    itemList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Entry", System.ComponentModel.ListSortDirection.Ascending));
                    itemQuality.ItemsSource = LegacyMorpher.DefineStore.ItemQuality;
                    itemInventoryType.ItemsSource = LegacyMorpher.DefineStore.ItemInventoryType;
                    itemSheath.ItemsSource = LegacyMorpher.DefineStore.ItemSheath;
                    itemBonding.ItemsSource = LegacyMorpher.DefineStore.ItemBonding;
                    itemAmmoType.ItemsSource = LegacyMorpher.DefineStore.ItemAmmoType;
                    itemStatType1.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType2.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType3.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType4.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType5.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType6.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType7.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType8.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType9.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemStatType10.ItemsSource = LegacyMorpher.DefineStore.ItemStatType;
                    itemDmgType1.ItemsSource = LegacyMorpher.DefineStore.ItemDamageSchool;
                    itemDmgType2.ItemsSource = LegacyMorpher.DefineStore.ItemDamageSchool;
                    itemSocket1.ItemsSource = LegacyMorpher.DefineStore.ItemSocketColor;
                    itemSocket2.ItemsSource = LegacyMorpher.DefineStore.ItemSocketColor;
                    itemSocket3.ItemsSource = LegacyMorpher.DefineStore.ItemSocketColor;
                    itemSpellTrigger1.ItemsSource = LegacyMorpher.DefineStore.ItemSpellTrigger;
                    itemSpellTrigger2.ItemsSource = LegacyMorpher.DefineStore.ItemSpellTrigger;
                    itemSpellTrigger3.ItemsSource = LegacyMorpher.DefineStore.ItemSpellTrigger;
                    itemSpellTrigger4.ItemsSource = LegacyMorpher.DefineStore.ItemSpellTrigger;
                    itemSpellTrigger5.ItemsSource = LegacyMorpher.DefineStore.ItemSpellTrigger;
                    itemReqFactionRank.ItemsSource = LegacyMorpher.DefineStore.ReputationRank;
                    itemReqSkill.ItemsSource = LegacyMorpher.DefineStore.SkillLine;
                    itemTotemCategory.ItemsSource = LegacyMorpher.DefineStore.TotemCategory;
                    itemReqHoliday.ItemsSource = LegacyMorpher.DefineStore.HolidayNames;
                    itemPageMaterial.ItemsSource = LegacyMorpher.DefineStore.PageTextMaterial;
                    itemPageTextLanguage.ItemsSource = LegacyMorpher.DefineStore.Language;
                    itemClass.ItemsSource = LegacyMorpher.DefineStore.ItemClass;
                    itemSubClass.ItemsSource = LegacyMorpher.DefineStore.ItemSubclass[0];
                    itemFilterClass.ItemsSource = LegacyMorpher.DefineStore.ItemClass;
                    itemFilterSubclass.ItemsSource = LegacyMorpher.DefineStore.ItemSubclass[0];
                    itemFilterClass.SelectedIndex = 0;
                    itemFilterSubclass.SelectedIndex = 0;
                    itemMaterial.ItemsSource = LegacyMorpher.DefineStore.ItemMaterial;
                    itemFoodType.ItemsSource = LegacyMorpher.DefineStore.ItemPetFood;
                    itemSetCombo.ItemsSource = LegacyMorpher.DefineStore.ItemSet;
                }
            }
            catch (System.Exception /*ex*/) { }
            IsLoading = false;
        }

        public void DataModified()
        {
            //Modified = true;
        }

        public void Load(ItemTemplate item)
        {
            if (ItemData != null)
            {
                try
                {
                    using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                    {
                        client.SaveItemTemplate(ItemData);
                    }
                }
                catch (System.Exception /*ex*/) { }
            }

            if (item == null)
            {
                ItemData = null;
                itemTab.IsEnabled = false;
                return;
            }

            ItemData = item;
            itemSubClass.ItemsSource = LegacyMorpher.DefineStore.ItemSubclass[ItemData.Class];
            itemTab.DataContext = ItemData;
            itemTab.IsEnabled = true;
        }

        public void TryLoadSomething(int id)
        {
            using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
            {
                ItemTemplate item = client.GetItemTemplate(id);
                Load(item);
            }
        }

        public void Save(bool loadAfterSave = false)
        {
            if (ItemData == null)
                return;

            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    ItemTemplate item = client.SaveItemTemplate(ItemData);
                    if (item != null)
                    {
                        //Modified = false;
                        if (loadAfterSave)
                            Load(item);
                    }
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void itemSave_Click(object sender, RoutedEventArgs e)
        {
            if (ItemData != null)
            {
                try
                {
                    using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                    {
                        ItemTemplate item = client.SaveItemTemplate(ItemData);
                        if (item != null)
                        {
                            ItemData = item;
                            Load(ItemData);
                        }
                    }
                }
                catch (System.Exception /*ex*/) { }
            }
        }

        private void itemClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemClass.SelectedValue == null)
                return;
            KeyValuePair<int, string> keyPair = (KeyValuePair<int, string>)e.AddedItems[0];
            if (keyPair.Key != -1)
            {
                itemSubClass.ItemsSource = LegacyMorpher.DefineStore.ItemSubclass[keyPair.Key];
                itemSubClass.SelectedIndex = 0;
            }
        }

        private void itemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemList.SelectedValue == null)
                return;
            int selection = (int)itemList.SelectedValue;
            TryLoadSomething(selection);
        }

        private void itemFlagBtn_Click(object sender, RoutedEventArgs e)
        {
            new ItemFlagsSelector(ItemData).Show();
        }

        private void itemFilterClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemFilterClass.SelectedValue == null)
                return;
            KeyValuePair<int, string> keyPair = (KeyValuePair<int, string>)e.AddedItems[0];
            if (keyPair.Key != -1)
            {
                itemFilterSubclass.SelectedIndex = 0;
                itemFilterSubclass.ItemsSource = LegacyMorpher.DefineStore.ItemSubclass[keyPair.Key];
            }
            UpdateItemListFilter();
        }

        private void UpdateItemListFilter()
        {
            if (IsLoading)
                return;
            itemList.Items.Filter = delegate(object obj)
            {
                ItemInfo item = (ItemInfo)obj;
                if (item.Name.Contains("Updated at LegacyV3S2"))
                    return false;
                string name = itemSearch.Text;
                if (enableClassFilter.IsChecked == true)
                {
                    if (itemFilterSubclass.SelectedValue == null)
                        return item.Name.Contains(name) || item.Entry.ToString().Contains(name);
                    int _class = (int)itemFilterClass.SelectedValue;
                    int subclass = (int)itemFilterSubclass.SelectedValue;
                    return item.Class == _class && item.SubClass == subclass && (item.Name.Contains(name) || item.Entry.ToString().Contains(name));
                }
                else
                    return item.Name.Contains(name) || item.Entry.ToString().Contains(name);
            };
        }

        private void itemSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateItemListFilter();
        }

        private void enableClassFilter_Click(object sender, RoutedEventArgs e)
        {
            UpdateItemListFilter();
        }

        private void itemFilterSubclass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateItemListFilter();
        }

        private void itemCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    ItemTemplate item = client.CreateItemTemplate();
                    ReloadItemList(client);
                    Load(item);
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void itemCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    ItemTemplate item = client.CopyItemTemplate((int)itemList.SelectedValue);
                    Load(item);
                    ReloadItemList(client);
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void ReloadItemList(LegacyServiceClient client)
        {
            ItemList = client.GetItemList();
            itemList.ItemsSource = ItemList;
            itemList.Items.SortDescriptions.Clear();
            itemList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Entry", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void itemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    client.DeleteItemTemplate((int)itemList.SelectedValue);
                    Load(null);
                    ReloadItemList(client);
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void exportItemDBC_Click(object sender, RoutedEventArgs e)
        {
            new Thread(GenerateItemDBC).Start();
        }

        private void GenerateItemDBC()
        {
            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        exportItemDBC.IsEnabled = false;
                        itemTabProgressLabel.Content = "正在获取数据...";
                        Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                        anim.Begin();
                    }));
                    ItemDBC[] dbc = client.GenerateItemDBC();
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        itemTabProgressLabel.Content = "正在处理第0个（共" + dbc.Length + "个)";
                        itemTabProgress.Maximum = dbc.Length;
                    }));
                    int index = 0;
                    using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/Item.dbc"))
                    {
                        BinaryWriter w = new BinaryWriter(stream);
                        DBC.WriteDBCHeader(w, dbc.Length, 8, 32);
                        foreach (ItemDBC d in dbc)
                        {
                            index++;
                            w.Write(d.Entry);
                            w.Write(d.Class);
                            w.Write(d.SubClass);
                            w.Write(d.SoundOverrideSubClass);
                            w.Write(d.Material);
                            w.Write(d.DisplayID);
                            w.Write(d.InventoryType);
                            w.Write(d.Sheath);
                            if (index % 64 == 0)
                            {
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    itemTabProgressLabel.Content = "正在处理第" + index + "个（共" + dbc.Length + "个)";
                                    itemTabProgress.Value = index;
                                }));
                            }
                        }
                        w.Close();
                        File.Copy(MainWindow.CLIENT_PATH + "DBFilesClient/Item.dbc", MainWindow.SERVER_PATH + "DBC/Item.dbc", true);
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            exportItemDBC.IsEnabled = true;
                            itemTabProgressLabel.Content = "完成。";
                            Storyboard anim2 = FindResource("HideProgressBar") as Storyboard;
                            anim2.Begin();
                        }));
                    }
                }
            }
            catch (System.Exception /*ex*/) { }
        }

        private void calculateDmg_Click(object sender, RoutedEventArgs e)
        {
            CalculateWeaponDamage();
            Save(true);
        }

        private void CalculateWeaponDamage()
        {
            if (ItemData == null || ItemData.Class != 2)
                return;

            float dps = ItemData.ItemLevel;
            switch (ItemData.Quality)
            {
                case 0:
                    dps *= 0.35f;
                    break;
                case 1:
                    dps *= 0.5f;
                    break;
                case 2:
                    dps *= 0.7f;
                    break;
                case 3:
                    dps *= 1.0f;
                    break;
                case 4:
                    dps *= 1.4f;
                    break;
                case 5:
                    dps *= 2.0f;
                    break;
                case 6:
                    dps *= 2.8f;
                    break;
                default:
                    dps = 0;
                    break;
            }

            switch (ItemData.Subclass)
            {
                case 1:
                case 6:
                case 5:
                case 8: // 2hand weapons
                    dps *= 2.0f;
                    break;
                case 15: // dagger
                    dps *= 1.2f;
                    break;
                case 10: // staff
                    dps *= 1.2f;
                    break;
                default:
                    break;
            }

            float damage = dps * ItemData.Speed / 1000;
            float minDamage = damage;
            float maxDamage = damage;

            switch (ItemData.Subclass)
            {
                case 0:
                case 1:
                case 18: // axe & crossbow
                    minDamage /= 1.4f;
                    maxDamage *= 1.4f;
                    break;
                case 4:
                case 5:
                case 3: // mace & gun
                    minDamage /= 1.3f;
                    maxDamage *= 1.3f;
                    break;
                case 7:
                case 8:
                case 2:
                case 19:
                case 13:
                case 15:
                case 16: // sword & bow & wand & fistweapon & dagger & throw
                    minDamage /= 1.2f;
                    maxDamage *= 1.2f;
                    break;
                case 6:
                case 10:
                case 20: // polearm & staff & fishing pole
                    minDamage /= 1.1f;
                    maxDamage *= 1.1f;
                    break;
            }

            if (minDamage < 1)
                minDamage = 1;
            if (maxDamage < 2)
                maxDamage = 2;

            ItemData.DamageMin[0] = minDamage;
            ItemData.DamageMax[0] = maxDamage;
        }

        private void calculateStats_Click(object sender, RoutedEventArgs e)
        {
            CalculateStats();
            Save(true);
        }

        private void CalculateStats()
        {
            float stats = ItemData.ItemLevel;
            switch (ItemData.Quality)
            {
                case 0:
                case 1:
                    stats = 0;
                    break;
                case 2:
                    stats *= 1.0f;
                    break;
                case 3:
                    stats *= 1.4f;
                    break;
                case 4:
                    stats *= 2.0f;
                    break;
                case 5:
                    stats *= 2.8f;
                    break;
                case 6:
                    stats *= 4.0f;
                    break;
                case 7:
                    stats = 0;
                    break;
                default:
                    break;
            }

            float armor = stats / 2;
            float resistance = stats / 2;

            if (ItemData.Class == 4)
            {
                switch (ItemData.Subclass)
                {
                    case 1:
                        armor /= 1.4f;
                        resistance *= 2.0f;
                        break;
                    case 2:
                        resistance *= 1.4f;
                        break;
                    case 3:
                        armor *= 1.4f;
                        break;
                    case 4:
                        armor *= 2.0f;
                        resistance /= 1.4f;
                        break;
                    case 5: // shield
                    case 6:
                        armor *= 3.84f;
                        break;
                    default:
                        break;
                }
                if (armor < 0) armor = 0;
                if (resistance < 0) resistance = 0;
                ItemData.Armor = (int)armor;
                ItemData.FireResistance = (byte)resistance; // place holder
                ItemData.HolyResistance = 0;
                ItemData.NatureResistance = 0;
                ItemData.ShadowResistance = 0;
                ItemData.ArcaneResistance = 0;
                ItemData.FrostResistance = 0;
            }

            if (ItemData.Class == 2)
            {
                switch (ItemData.Subclass)
                {
                    case 1:
                    case 5:
                    case 6:
                    case 8:
                        stats *= 2;
                        break;
                    case 10: // staff
                        stats *= 3;
                        break;
                    default:
                        break;
                }
            }

            if (ItemData.Quality == 0 || ItemData.Quality == 1)
            {
                ItemData.StatsCount = 0;
                ItemData.StatType[0] = 0;
                ItemData.StatType[1] = 0;
                ItemData.StatType[2] = 0;
                ItemData.StatType[3] = 0;
                ItemData.StatType[4] = 0;
                ItemData.StatType[5] = 0;
                ItemData.StatType[6] = 0;
                ItemData.StatType[7] = 0;
                ItemData.StatType[8] = 0;
                ItemData.StatType[9] = 0;
                ItemData.StatValue[0] = 0;
                ItemData.StatValue[1] = 0;
                ItemData.StatValue[2] = 0;
                ItemData.StatValue[3] = 0;
                ItemData.StatValue[4] = 0;
                ItemData.StatValue[5] = 0;
                ItemData.StatValue[6] = 0;
                ItemData.StatValue[7] = 0;
                ItemData.StatValue[8] = 0;
                ItemData.StatValue[9] = 0;
                return;
            }

            // mod value to right value.
            int limit = 0;
            switch (ItemData.Quality)
            {
                case 2:
                    limit = 1;
                    break;
                case 3:
                    limit = 2;
                    break;
                case 4:
                    limit = 3;
                    break;
                case 5:
                    limit = 4;
                    break;
                case 6:
                    limit = 5;
                    break;
                default:
                    break;
            }

            for (int i = 0; i != ItemData.StatsCount; ++i)
            {
                if (ItemData.StatType[i] != 0)
                {
                    switch (ItemData.StatType[i])
                    {
                        case 13: // dodge
                        case 14: // parry
                        case 15: // block
                        case 16: // melee hit
                        case 17: // ranged hit
                        case 18: // spell hit
                        case 19: // melee crit
                        case 20: // ranged crit
                        case 21: // spell crit
                        case 28: // melee haste
                        case 29: // ranged haste
                        case 30: // spell haste
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27: // resist
                        case 31: // hit
                        case 32: // crit
                        case 36: // haste
                            ItemData.StatValue[i] = (short)Math.Min(ItemData.StatValue[i], limit);
                            break;
                        case 33: // melee crit dmg
                        case 34: // ranged crit dmg
                        case 35: // spell crit dmg
                            ItemData.StatValue[i] = (short)Math.Min(ItemData.StatValue[i], limit * 2);
                            break;
                    }
                }
            }

            for (int i = 0; i != ItemData.StatsCount; ++i)
            {
                if (ItemData.StatType[i] != 0)
                {
                    switch (ItemData.StatType[i])
                    {
                        case 13: // dodge
                        case 14: // parry
                        case 15: // block
                        case 16: // melee hit
                        case 17: // ranged hit
                        case 18: // spell hit
                        case 19: // melee crit
                        case 20: // ranged crit
                        case 21: // spell crit
                        case 28: // melee haste
                        case 29: // ranged haste
                        case 30: // spell haste
                            stats -= ItemData.StatValue[i] * 10.0f;
                            break;
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27: // resist
                            stats -= ItemData.StatValue[i] * 5.0f;
                            break;
                        case 31: // hit
                        case 32: // crit
                        case 36: // haste
                            stats -= ItemData.StatValue[i] * 20.0f;
                            break;
                        case 33: // melee crit dmg
                        case 34: // ranged crit dmg
                        case 35: // spell crit dmg
                            stats -= ItemData.StatValue[i] * 5.0f;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (stats < 0)
            {
                //ItemData.StatsCount = 0;
                //ItemData.StatType[0] = 0;
                //ItemData.StatType[1] = 0;
                //ItemData.StatType[2] = 0;
                //ItemData.StatType[3] = 0;
                //ItemData.StatType[4] = 0;
                //ItemData.StatType[5] = 0;
                //ItemData.StatType[6] = 0;
                //ItemData.StatType[7] = 0;
                //ItemData.StatType[8] = 0;
                //ItemData.StatType[9] = 0;
                //ItemData.StatValue[0] = 0;
                //ItemData.StatValue[1] = 0;
                //ItemData.StatValue[2] = 0;
                //ItemData.StatValue[3] = 0;
                //ItemData.StatValue[4] = 0;
                //ItemData.StatValue[5] = 0;
                //ItemData.StatValue[6] = 0;
                //ItemData.StatValue[7] = 0;
                //ItemData.StatValue[8] = 0;
                //ItemData.StatValue[9] = 0;
                //ItemData.Armor = 0;
                //ItemData.Block = 0;
                //ItemData.ArcaneResistance = 0;
                //ItemData.FireResistance = 0;
                //ItemData.FrostResistance = 0;
                //ItemData.HolyResistance = 0;
                //ItemData.NatureResistance = 0;
                //ItemData.ShadowResistance = 0;
                //return;
                stats = 0;
            }

            float sum = 0;

            for (int i = 0; i != ItemData.StatsCount; ++i)
            {
                if (ItemData.StatType[i] != 0)
                {
                    float v = ItemData.StatValue[i];
                    switch (ItemData.StatType[i])
                    {
                        case 1: //health
                            sum += v * 0.25f;
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7: // base stat
                            sum += v;
                            break;
                        case 12: // defense
                            sum += v * 10.0f;
                            break;
                        case 37: // expertise
                            sum += v * 10.0f;
                            break;
                        case 38: // melee ap
                        case 39: // ranged ap
                        case 41: // spell dmg
                        case 42: // spell heal
                            sum += v * 2.0f;
                            break;
                        case 43: // power regen
                            sum += v * 30.0f;
                            break;
                        case 44: // arp
                        case 47: // spp
                            sum += v * 1.0f;
                            break;
                        case 46:
                            sum += v * 2.0f;
                            break;
                        case 48: // block value
                            sum += v * 1.0f;
                            break;
                        case 49: // max power
                            sum += v * 10.0f;
                            break;
                        case 45: // sp
                            sum += v * 3.0f;
                            break;
                        default:
                            break;
                    }
                }
            }

            sum += ItemData.Armor;
            sum += ItemData.Block;
            sum += ItemData.ArcaneResistance;
            sum += ItemData.FireResistance;
            sum += ItemData.FrostResistance;
            sum += ItemData.HolyResistance;
            sum += ItemData.NatureResistance;
            sum += ItemData.ShadowResistance;

            if (sum == 0)
                sum = 1;

            float factor = stats / sum;

            for (int i = 0; i != ItemData.StatsCount; ++i)
            {
                switch (ItemData.StatType[i])
                {
                    case 1: //health
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7: // base stat
                    case 12: // defense
                    case 37: // expertise
                    case 38: // melee ap
                    case 39: // ranged ap
                    case 41: // spell dmg
                    case 42: // spell heal
                    case 43: // power regen
                    case 44: // arp
                    case 47: // spp
                    case 46:
                    case 48: // block value
                    case 49: // max power
                    case 45: // sp
                        ItemData.StatValue[i] = (short)(ItemData.StatValue[i] * factor);
                        break;
                    default:
                        break;
                }
            }

            ItemData.Armor = (int)(ItemData.Armor * factor);
            ItemData.Block = (int)(ItemData.Block * factor);
            ItemData.ArcaneResistance = (byte)(ItemData.ArcaneResistance * factor);
            ItemData.FireResistance = (byte)(ItemData.FireResistance * factor);
            ItemData.FrostResistance = (byte)(ItemData.FrostResistance * factor);
            ItemData.HolyResistance = (byte)(ItemData.HolyResistance * factor);
            ItemData.NatureResistance = (byte)(ItemData.NatureResistance * factor);
            ItemData.ShadowResistance = (byte)(ItemData.ShadowResistance * factor);
        }

        private void CalculateVendorPrice()
        {
            if (ItemData == null || (ItemData.Class != 2 && ItemData.Class != 4))
                return;

            int buyprice = ItemData.ItemLevel;
            switch (ItemData.Quality)
            {
                case 0:
                case 1:
                    buyprice *= 5;
                    break;
                case 2:
                    buyprice *= 30;
                    break;
                case 3:
                    buyprice *= 360;
                    break;
                case 4:
                    buyprice *= 8640;
                    break;
                case 5:
                    buyprice *= 414720;
                    break;
                default:
                    buyprice = 0;
                    break;
            }

            if (ItemData.Class == 2)
            {
                switch (ItemData.Subclass)
                {
                    case 1:
                    case 5:
                    case 8:
                    case 10:
                        buyprice *= 2;
                        break;
                    default:
                        break;
                }
            }

            int sellprice = buyprice / 5;

            ItemData.BuyPrice = buyprice;
            ItemData.SellPrice = sellprice;
            ItemData.BuyCount = 1;
        }

        private void calculatePrice_Click(object sender, RoutedEventArgs e)
        {
            CalculateVendorPrice();
            Save(true);
        }

        private void reloadItemList_Click(object sender, RoutedEventArgs e)
        {
            using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
            {
                ReloadItemList(client);
            }
        }

        private void calculateAll_Click(object sender, RoutedEventArgs e)
        {
            CalculateWeaponDamage();
            CalculateStats();
            CalculateVendorPrice();
            int reqlevel = ItemData.ItemLevel;
            switch (ItemData.Quality)
            {
                case 0:
                    reqlevel += 2;
                    break;
                case 2:
                    reqlevel -= 2;
                    break;
                case 3:
                    reqlevel -= 4;
                    break;
                case 4:
                    reqlevel -= 6;
                    break;
                case 5:
                    reqlevel -= 8;
                    break;
                case 6:
                    reqlevel -= 10;
                    break;
                default:
                    break;
            }
            if (reqlevel < 0)
                reqlevel = 0;
            ItemData.RequiredLevel = (byte)reqlevel;
            Save(true);
        }

        public void ModAllEquipments()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                exportItemDBC.IsEnabled = false;
                itemTabProgressLabel.Content = "0 of " + ItemList.Length;
                itemTabProgress.Maximum = ItemList.Length;
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
            }));

            using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
            {
                int index = 0;
                foreach (var item in ItemList)
                {
                    ++index;
                    if (item.Class != 2)
                        if (item.Class != 4)
                        continue;

                    ItemData = client.GetItemTemplate(item.Entry);
                    ItemData.ItemLevel = (int)(ItemData.ItemLevel * 0.7f);
                    if (ItemData.ItemLevel < 1)
                        ItemData.ItemLevel = 1;

                    CalculateWeaponDamage();
                    CalculateStats();
                    CalculateVendorPrice();

                    int reqlevel = ItemData.ItemLevel;
                    switch (ItemData.Quality)
                    {
                        case 0:
                            reqlevel += 2;
                            break;
                        case 2:
                            reqlevel -= 2;
                            break;
                        case 3:
                            reqlevel -= 4;
                            break;
                        case 4:
                            reqlevel -= 6;
                            break;
                        case 5:
                            reqlevel -= 8;
                            break;
                        case 6:
                            reqlevel -= 10;
                            break;
                        default:
                            break;
                    }

                    if (reqlevel < 0)
                        reqlevel = 0;

                    ItemData.RequiredLevel = (byte)reqlevel;
                    client.SaveItemTemplate(ItemData);

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        itemTabProgressLabel.Content = index + " of " + ItemList.Length;
                        itemTabProgress.Value = index;
                    }));
                }
            }
        }

        private bool IsRatingStat(int type)
        {
            switch (type)
            {
                case 13: // dodge
                case 14: // parry
                case 15: // block
                case 16: // melee hit
                case 17: // ranged hit
                case 18: // spell hit
                case 19: // melee crit
                case 20: // ranged crit
                case 21: // spell crit
                case 28: // melee haste
                case 29: // ranged haste
                case 30: // spell haste
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27: // resist
                case 31: // hit
                case 32: // crit
                case 36: // haste
                case 33: // melee crit dmg
                case 34: // ranged crit dmg
                case 35: // spell crit dmg
                    return true;
                default:
                    return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(ModAllEquipments).Start();
        }
    }
}
