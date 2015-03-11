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
        public static List<ItemInfo> ItemList;
        bool IsLoading;
        Random ran = new Random();

        const float FACTOR_HEAD = 0.75f;
        const float FACTOR_SHOULDER = 0.685f;
        const float FACTOR_CHEST = 0.921f;
        const float FACTOR_WRIST = 0.396f;
        const float FACTOR_GLOVE = 0.616f;
        const float FACTOR_WAIST = 0.567f;
        const float FACTOR_LEGGING = 0.803f;
        const float FACTOR_FEET = 0.632f;
        const float FACTOR_1H_WEAPON = 0.4f;
        const float FACTOR_2H_WEAPON = 0.8f;
        const float FACTOR_RING = 0.4f;
        const float FACTOR_TRINKET = 0.4f;
        const float FACTOR_NECKLACE = 0.4f;
        const float FACTOR_RANGED = 0.6f;
        const float FACTOR_OFFHAND = 0.4f;
        const float FACTOR_CLOAK = 0.4f;

        const float FACTOR_POOR = 0.455f;
        const float FACTOR_NORMAL = 0.592f;
        const float FACTOR_UNCOMMON = 0.77f;
        const float FACTOR_RARE = 1.0f;
        const float FACTOR_EPIC = 1.3f;
        const float FACTOR_LEGENDARY = 1.69f;

        const float FACTOR_1H_DPS = 0.65f;
        const float FACTOR_2H_DPS = 0.85f;
        const float FACTOR_STAFF_DPS = 0.7f;
        const float FACTOR_RANGED_DPS = 0.65f;
        const float FACTOR_WAND_DPS = 1.0f;

        const float FACTOR_POOR_DPS = 0.614f;
        const float FACTOR_NORMAL_DPS = 0.723f;
        const float FACTOR_UNCOMMON_DPS = 0.85f;
        const float FACTOR_RARE_DPS = 1.0f;
        const float FACTOR_EPIC_DPS = 1.176f;
        const float FACTOR_LEGENDARY_DPS = 1.384f;

        const float FACTOR_ARMOR_PLATE = 1.0f;
        const float FACTOR_ARMOR_MAIL = 0.558f;
        const float FACTOR_ARMOR_LEATHER = 0.267f;
        const float FACTOR_ARMOR_CLOTH = 0.14f;
        const float FACTOR_ARMOR_SHIELD = 3.66f;

        const float FACTOR_SELLPRICE_PLATE = 1.0f;
        const float FACTOR_SELLPRICE_MAIL = 0.857f;
        const float FACTOR_SELLPRICE_LEATHER = 0.683f;
        const float FACTOR_SELLPRICE_CLOTH = 0.542f;

        public ItemPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            LoadDefines();
            iconPanel.Load();
            enchantPanel.Load();
        }

        private void LoadDefines()
        {
            IsLoading = true;
            ItemList = LegacyWorld.GetItemList();
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
            IsLoading = false;
        }

        public void DataModified()
        {
            //Modified = true;
        }

        public void Load(ItemTemplate item)
        {
            if (item != null && ItemData != null)
            {
                LegacyWorld.SaveItemTemplate(ItemData, false);
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
            ItemTemplate item = LegacyWorld.GetItemTemplate(id);
            Load(item);
            iconPanel.Load(item);
        }

        public void Save(bool loadAfterSave = false)
        {
            if (ItemData == null)
                return;

            ItemTemplate item = LegacyWorld.SaveItemTemplate(ItemData, false);
            if (item != null)
            {
                //Modified = false;
                if (loadAfterSave)
                    Load(item);
            }
        }

        private void itemSave_Click(object sender, RoutedEventArgs e)
        {
            if (ItemData != null)
            {
                ItemTemplate item = LegacyWorld.SaveItemTemplate(ItemData, false);
                if (item != null)
                {
                    ItemData = item;
                    Load(ItemData);
                }
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
            //new Thread(CleanRecipes).Start();
            //new Thread(CleanItemSpells).Start();
            //new Thread(ModAllItem).Start();
            ItemTemplate item = LegacyWorld.CreateItemTemplate();
            ReloadItemList();
            Load(item);
        }

        private void itemCopy_Click(object sender, RoutedEventArgs e)
        {
            ItemTemplate item = LegacyWorld.CopyItemTemplate((int)itemList.SelectedValue);
            Load(item);
            ReloadItemList();
        }

        private void ReloadItemList()
        {
            ItemList = LegacyWorld.GetItemList();
            itemList.ItemsSource = ItemList;
            itemList.Items.SortDescriptions.Clear();
            itemList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Entry", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void itemDelete_Click(object sender, RoutedEventArgs e)
        {
            LegacyWorld.DeleteItemTemplate((int)itemList.SelectedValue);
            Load(null);
            ReloadItemList();
        }

        private void exportItemDBC_Click(object sender, RoutedEventArgs e)
        {
            new Thread(GenerateItemDBC).Start();
        }

        private void GenerateItemDBC()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                exportItemDBC.IsEnabled = false;
                itemTabProgressLabel.Content = "正在获取数据...";
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
            }));
            List<ItemDBC> dbc = LegacyWorld.GenerateItemDBC();
            this.Dispatcher.Invoke(new Action(() =>
            {
                itemTabProgressLabel.Content = "正在处理第0个（共" + dbc.Count + "个)";
                itemTabProgress.Maximum = dbc.Count;
            }));
            int index = 0;
            using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/Item.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, dbc.Count, 8, 32);
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
                            itemTabProgressLabel.Content = "正在处理第" + index + "个（共" + dbc.Count + "个)";
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
            ReloadItemList();
        }

        private void calculateAll_Click(object sender, RoutedEventArgs e)
        {
            CalculateValues();
            Save(true);
        }

        public void ModAllEquipments()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                exportItemDBC.IsEnabled = false;
                itemTabProgressLabel.Content = "0 of " + ItemList.Count;
                itemTabProgress.Maximum = ItemList.Count;
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
            }));

            int index = 0;
            foreach (var item in ItemList)
            {
                ++index;
                if (item.Class != 2)
                    if (item.Class != 4)
                    continue;

                ItemData = LegacyWorld.GetItemTemplate(item.Entry);
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
                LegacyWorld.SaveItemTemplate(ItemData, false);

                this.Dispatcher.Invoke(new Action(() =>
                {
                    itemTabProgressLabel.Content = index + " of " + ItemList.Count;
                    itemTabProgress.Value = index;
                }));
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

        public void ModResistance()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                exportItemDBC.IsEnabled = false;
                itemTabProgressLabel.Content = "0 of " + ItemList.Count;
                itemTabProgress.Maximum = ItemList.Count;
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
            }));

            Random rand = new Random();

            int index = 0;
            foreach (var item in ItemList)
            {
                ++index;
                if (item.Class != 4)
                    continue;

                ItemData = LegacyWorld.GetItemTemplate(item.Entry);

                int resistance = ItemData.FireResistance;
                double resistance1 = 0;
                double resistance2 = 0;
                double resistance3 = 0;
                double resistance4 = 0;
                double resistance5 = 0;

                for (int i = 0; i != 5; i++)
                {
                    switch (rand.Next(4))
                    {
                        case 0:
                            resistance1 = rand.Next(10000);
                            break;
                        case 1:
                            resistance2 = rand.Next(10000);
                            break;
                        case 2:
                            resistance3 = rand.Next(10000);
                            break;
                        case 3:
                            resistance4 = rand.Next(10000);
                            break;
                        case 4:
                            resistance5 = rand.Next(10000);
                            break;
                        default:
                            break;
                    }
                }

                double factor = resistance / (resistance1 + resistance2 + resistance3 + resistance4 + resistance5);
                int res1 = (int)(resistance1 * factor);
                int res2 = (int)(resistance2 * factor);
                int res3 = (int)(resistance3 * factor);
                int res4 = (int)(resistance4 * factor);
                int res5 = (int)(resistance5 * factor);

                // sum lefty
                int lefty = resistance - res1 - res2 - res3 - res4 - res5;
                if (lefty > 0)
                {
                    switch (rand.Next(4))
                    {
                        case 0:
                            res1 += lefty;
                            break;
                        case 1:
                            res2 += lefty;
                            break;
                        case 2:
                            res3 += lefty;
                            break;
                        case 3:
                            res4 += lefty;
                            break;
                        case 4:
                            res5 += lefty;
                            break;
                        default:
                            break;
                    }
                }
                ItemData.FireResistance = (byte)res1;
                ItemData.NatureResistance = (byte)res2;
                ItemData.FrostResistance = (byte)res3;
                ItemData.ShadowResistance = (byte)res4;
                ItemData.ArcaneResistance = (byte)res5;

                LegacyWorld.SaveItemTemplate(ItemData, false);

                this.Dispatcher.Invoke(new Action(() =>
                {
                    itemTabProgressLabel.Content = index + " of " + ItemList.Count;
                    itemTabProgress.Value = index;
                }));
            }
        }

        private void CalculateValues(ItemTemplate itemData = null)
        {
            if (itemData != null)
                ItemData = itemData;

            if (ItemData == null)
                return;

            float factor = ItemData.ItemLevel;
            if (factor == 0) return;

            if (ItemData.Class == 2 || ItemData.Class == 4)
                ItemData.RequiredLevel = 0;

            switch (ItemData.Quality)
            {
                case 0:
                    factor *= FACTOR_POOR;
                    break;
                case 1:
                    factor *= FACTOR_NORMAL;
                    break;
                case 2:
                    factor *= FACTOR_UNCOMMON;
                    break;
                case 3:
                    factor *= FACTOR_RARE;
                    break;
                case 4:
                    factor *= FACTOR_EPIC;
                    break;
                case 5:
                    factor *= FACTOR_LEGENDARY;
                    break;
                default:
                    return;
            }

            switch (ItemData.InventoryType)
            {
                case 1:
                    factor *= FACTOR_HEAD;
                    break;
                case 2:
                    factor *= FACTOR_NECKLACE;
                    break;
                case 3:
                    factor *= FACTOR_SHOULDER;
                    break;
                case 5:
                case 20:
                    factor *= FACTOR_CHEST;
                    break;
                case 6:
                    factor *= FACTOR_WAIST;
                    break;
                case 7:
                    factor *= FACTOR_LEGGING;
                    break;
                case 8:
                    factor *= FACTOR_FEET;
                    break;
                case 9:
                    factor *= FACTOR_WRIST;
                    break;
                case 10:
                    factor *= FACTOR_GLOVE;
                    break;
                case 11:
                    factor *= FACTOR_RING;
                    break;
                case 12:
                    factor *= FACTOR_TRINKET;
                    break;
                case 13:
                case 14:
                case 21:
                case 22:
                case 23:
                    factor *= FACTOR_1H_WEAPON;
                    break;
                case 15:
                case 25:
                case 26:
                case 28:
                    factor *= FACTOR_RANGED;
                    break;
                case 16:
                    factor *= FACTOR_CLOAK;
                    break;
                case 17:
                    factor *= FACTOR_2H_WEAPON;
                    break;
                default:
                    break;
            }

            if (ItemData.Class == 4 && ItemData.Subclass != 0)
            {
                switch (ItemData.Subclass)
                {
                    case 1:
                        ItemData.Armor = (int)(factor * FACTOR_ARMOR_CLOTH);
                        break;
                    case 2:
                        ItemData.Armor = (int)(factor * FACTOR_ARMOR_LEATHER);
                        break;
                    case 3:
                        ItemData.Armor = (int)(factor * FACTOR_ARMOR_MAIL);
                        break;
                    case 4:
                        ItemData.Armor = (int)(factor * FACTOR_ARMOR_PLATE);
                        break;
                    case 6:
                        ItemData.Armor = (int)(factor * FACTOR_ARMOR_SHIELD);
                        break;
                    default:
                        break;
                }
                if (ItemData.Armor < 1) ItemData.Armor = 1;
            }

            float sum = 0;
            float sta = 0;
            for (int i = 0; i != ItemData.StatsCount; ++i)
            {
                float fa = 1.0f;
                switch (ItemData.StatType[i])
                {
                    case 1:
                        fa = 0.1f;
                        sta += 0.1f * ItemData.StatValue[i];
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        fa = 1.0f;
                        sta += 1.0f * ItemData.StatValue[i];
                        break;
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        fa = 5.0f;
                        break;
                    case 31:
                    case 32:
                    case 36:
                    case 37:
                        fa = 10.0f;
                        break;
                    case 33:
                    case 34:
                    case 35:
                        fa = 5.0f;
                        break;
                    case 38:
                    case 39:
                    case 41:
                    case 42:
                        fa = 2.0f;
                        sta += 2.0f * ItemData.StatValue[i];
                        break;
                    case 43:
                    case 49:
                        fa = 5.0f;
                        sta += 5.0f * ItemData.StatValue[i];
                        break;
                    case 44:
                    case 47:
                    case 48:
                        fa = 1.0f;
                        sta += 1.0f * ItemData.StatValue[i];
                        break;
                    case 46:
                        fa = 1.5f;
                        sta += 1.5f * ItemData.StatValue[i];
                        break;
                    default:
                        break;
                }
                sum += fa * ItemData.StatValue[i];
            }

            if (sum != 0)
            {
                float mod = factor / sum;

                for (int i = 0; i != ItemData.StatsCount; ++i)
                {
                    switch (ItemData.StatType[i])
                    {
                        case 1:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 38:
                        case 39:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                            ItemData.StatValue[i] = (short)(ItemData.StatValue[i] * mod);
                            break;
                        default:
                            break;
                    }
                }
            }

            float dps = ItemData.ItemLevel;
            if (ItemData.Class == 2 || ItemData.Speed != 0)
            {
                switch (ItemData.Subclass)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                    case 7:
                    case 13:
                    case 15:
                    case 16:
                    case 18:
                        dps *= FACTOR_1H_DPS;
                        break;
                    case 1:
                    case 5:
                    case 6:
                    case 8:
                        dps *= FACTOR_2H_DPS;
                        break;
                    case 10:
                        dps *= FACTOR_STAFF_DPS;
                        break;
                    case 19:
                        dps *= FACTOR_WAND_DPS;
                        break;
                    default:
                        break;
                }

                switch (ItemData.Quality)
                {
                    case 0:
                        dps *= FACTOR_POOR_DPS;
                        break;
                    case 1:
                        dps *= FACTOR_NORMAL_DPS;
                        break;
                    case 2:
                        dps *= FACTOR_UNCOMMON_DPS;
                        break;
                    case 3:
                        dps *= FACTOR_RARE_DPS;
                        break;
                    case 4:
                        dps *= FACTOR_EPIC_DPS;
                        break;
                    case 5:
                        dps *= FACTOR_LEGENDARY_DPS;
                        break;
                    default:
                        break;
                }

                ItemData.DamageMin[0] = dps * ItemData.Speed / 1.2f / 1000;
                ItemData.DamageMax[0] = dps * ItemData.Speed * 1.2f / 1000;

                if (ItemData.DamageMin[0] < 1) ItemData.DamageMin[0] = 1;
                if (ItemData.DamageMax[0] < 2) ItemData.DamageMax[0] = 2;
            }
        }

        private void ModAllItem()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
            }));
            var itemlist = (from d in ItemList where d.Class == 2 || d.Class == 4 select d).ToList();
            int count = itemlist.Count;
            int index = 0;
            foreach (var itemInfo in itemlist)
            {
                index++;
                ItemTemplate item = LegacyWorld.GetItemTemplate(itemInfo.Entry);
                CalculateValues(item);
                LegacyWorld.SaveItemTemplate(item, false);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    itemTabProgressLabel.Content = "Proccessing " + index + " of " + count;
                }));
            }
        }

        private void addRecipeItem_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddItem(info.Name, info.Entry);
        }

        private void addReagent1_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 0);
        }

        private void addReagent2_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 1);
        }

        private void addReagent3_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 2);
        }

        private void addReagent4_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 3);
        }

        private void addReagent5_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 4);
        }

        private void addReagent6_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 5);
        }

        private void addReagent7_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 6);
        }

        private void addReagent8_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, 7);
        }

        private void addNextReagent_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = itemList.SelectedItem as ItemInfo;
            RecipePanel.self.AddReagent(info.Name, info.Entry, -1);
        }

        private void CleanItemSpells()
        {
            var items = (from d in ItemList where d.Class == 2 || d.Class == 4 select d).ToList();
            int count = items.Count;
            int index = 0;
            this.Dispatcher.Invoke(new Action(() =>
            {
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
                itemTabProgress.Maximum = count;
            }));
            foreach (var item in items)
            {
                index++;
                ItemTemplate itemTemplate = LegacyWorld.GetItemTemplate(item.Entry);
                for (int i = 0; i != 5; ++i)
                {
                    if (itemTemplate.Spell[i] == 0)
                        continue;

                    SpellTemplate spell = (from d in SpellPanel.spells where d.ID == itemTemplate.Spell[i] select d).SingleOrDefault();
                    if (spell == null || (spell.Attributes[0] & 0x40) == 0) continue;

                    switch (spell.EffectApplyAura[0])
                    {
                        case 189:
                        case 99:
                        case 124:
                        case 13:
                        case 135:
                            itemTemplate.Spell[i] = 0;
                            break;
                        default:
                            break;
                    }
                }
                LegacyWorld.SaveItemTemplate(itemTemplate);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    itemTabProgress.Value = index;
                    itemTabProgressLabel.Content = "Proccessing " + index + " of " + count;
                }));
            }
        }

        private void CleanRecipes()
        {
            var items = (from d in ItemList where d.Class == 9 select d).ToList();
            int count = items.Count;
            int index = 0;
            this.Dispatcher.Invoke(new Action(() =>
            {
                Storyboard anim = FindResource("ShowProgressBar") as Storyboard;
                anim.Begin();
                itemTabProgress.Maximum = count;
            }));
            foreach (var item in items)
            {
                index++;
                ItemTemplate itemTemplate = LegacyWorld.GetItemTemplate(item.Entry);
                if (itemTemplate == null || itemTemplate.Spell[1] == 0 || itemTemplate.RequiredSkillRank == 0) continue;
                var skill = (from d in SkillLinePanel.SkillLineAbilities where d.Spell == itemTemplate.Spell[1] select d).FirstOrDefault();
                if (skill == null) continue;
                itemTemplate.RequiredSkill = skill.Skill;
                LegacyWorld.SaveItemTemplate(itemTemplate);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    itemTabProgress.Value = index;
                    itemTabProgressLabel.Content = "Proccessing " + index + " of " + count;
                }));
            }
        }
    }
}
