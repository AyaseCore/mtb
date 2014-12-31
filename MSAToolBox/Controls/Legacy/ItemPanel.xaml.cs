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
        private ItemTemplate ItemData;
        private bool Modified;
        private DataDefineStore DefineStore;
        public static ItemInfo[] ItemList;
        bool IsLoading;
        public ItemPanel()
        {
            InitializeComponent();
            LoadDefines();
            TryLoadSomething(19019);
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
                    DefineStore = client.GetDataDefines();
                    itemQuality.ItemsSource = DefineStore.ItemQuality;
                    itemInventoryType.ItemsSource = DefineStore.ItemInventoryType;
                    itemSheath.ItemsSource = DefineStore.ItemSheath;
                    itemBonding.ItemsSource = DefineStore.ItemBonding;
                    itemAmmoType.ItemsSource = DefineStore.ItemAmmoType;
                    itemStatType1.ItemsSource = DefineStore.ItemStatType;
                    itemStatType2.ItemsSource = DefineStore.ItemStatType;
                    itemStatType3.ItemsSource = DefineStore.ItemStatType;
                    itemStatType4.ItemsSource = DefineStore.ItemStatType;
                    itemStatType5.ItemsSource = DefineStore.ItemStatType;
                    itemStatType6.ItemsSource = DefineStore.ItemStatType;
                    itemStatType7.ItemsSource = DefineStore.ItemStatType;
                    itemStatType8.ItemsSource = DefineStore.ItemStatType;
                    itemStatType9.ItemsSource = DefineStore.ItemStatType;
                    itemStatType10.ItemsSource = DefineStore.ItemStatType;
                    itemDmgType1.ItemsSource = DefineStore.ItemDamageSchool;
                    itemDmgType2.ItemsSource = DefineStore.ItemDamageSchool;
                    itemSocket1.ItemsSource = DefineStore.ItemSocketColor;
                    itemSocket2.ItemsSource = DefineStore.ItemSocketColor;
                    itemSocket3.ItemsSource = DefineStore.ItemSocketColor;
                    itemSpellTrigger1.ItemsSource = DefineStore.ItemSpellTrigger;
                    itemSpellTrigger2.ItemsSource = DefineStore.ItemSpellTrigger;
                    itemSpellTrigger3.ItemsSource = DefineStore.ItemSpellTrigger;
                    itemSpellTrigger4.ItemsSource = DefineStore.ItemSpellTrigger;
                    itemSpellTrigger5.ItemsSource = DefineStore.ItemSpellTrigger;
                    itemReqFactionRank.ItemsSource = DefineStore.ReputationRank;
                    itemReqSkill.ItemsSource = DefineStore.SkillLine;
                    itemTotemCategory.ItemsSource = DefineStore.TotemCategory;
                    itemReqHoliday.ItemsSource = DefineStore.HolidayNames;
                    itemPageMaterial.ItemsSource = DefineStore.PageTextMaterial;
                    itemPageTextLanguage.ItemsSource = DefineStore.Language;
                    itemClass.ItemsSource = DefineStore.ItemClass;
                    itemSubClass.ItemsSource = DefineStore.ItemSubclass[0];
                    itemFilterClass.ItemsSource = DefineStore.ItemClass;
                    itemFilterSubclass.ItemsSource = DefineStore.ItemSubclass[0];
                    itemFilterClass.SelectedIndex = 0;
                    itemFilterSubclass.SelectedIndex = 0;
                    itemMaterial.ItemsSource = DefineStore.ItemMaterial;
                    itemFoodType.ItemsSource = DefineStore.ItemPetFood;
                    itemSetCombo.ItemsSource = DefineStore.ItemSet;
                }
            }
            catch (System.Exception /*ex*/) { }
            IsLoading = false;
        }

        public void DataModified()
        {
            Modified = true;
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
            itemSubClass.ItemsSource = DefineStore.ItemSubclass[ItemData.Class];
            itemTab.DataContext = ItemData;
            itemTab.IsEnabled = true;
        }

        public void TryLoadSomething(int id)
        {
            LegacyServiceClient client = new LegacyServiceClient("Legacy");
            ItemTemplate item = client.GetItemTemplate(id);
            Load(item);
        }

        public void Save(bool loadAfterSave = false)
        {
            if (ItemData == null || !Modified)
                return;

            try
            {
                using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
                {
                    ItemTemplate item = client.SaveItemTemplate(ItemData);
                    if (item != null)
                    {
                        Modified = false;
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
                itemSubClass.ItemsSource = DefineStore.ItemSubclass[keyPair.Key];
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
                itemFilterSubclass.ItemsSource = DefineStore.ItemSubclass[keyPair.Key];
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
    }
}
