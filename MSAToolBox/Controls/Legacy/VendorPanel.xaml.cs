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
    /// LegacyCreatureVendorControl.xaml 的交互逻辑
    /// </summary>
    public partial class VendorPanel : UserControl
    {
        private List<VendorInfo> VendorData;
        private int VendorEntry;
        public VendorPanel()
        {
            InitializeComponent();
        }

        public void Load(int entry)
        {
            VendorData = LegacyMorpher.Data.GetVendorList(entry).ToList();
            vendorData.ItemsSource = VendorData;
            VendorEntry = entry;
        }

        private void Save()
        {
            VendorData = vendorData.ItemsSource as List<VendorInfo>;
            if (VendorData == null || VendorEntry == 0)
                return;

            LegacyMorpher.Data.SaveVendorList(VendorEntry, VendorData);
        }

        private void vendorSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void vendorGo_Click(object sender, RoutedEventArgs e)
        {
            int entry = Convert.ToInt32(vendorEntry.Text);
            Load(entry);
        }

        private void vendorEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int entry = Convert.ToInt32(vendorEntry.Text);
                vendorGo.IsEnabled = true;
                //vendorName.Text = (from d in LegacyCreatureGossipControl.CreatureNames where d.Key == entry select d.Value).SingleOrDefault();
            }
            catch (System.Exception /*ex*/)
            {
                vendorGo.IsEnabled = false;
                //vendorName.Text = "";
            }
        }

        private void vendorData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (vendorData.SelectedItem != null)
                {
                    var item = vendorData.SelectedItem as VendorInfo;
                    var list = vendorData.ItemsSource as List<VendorInfo>;
                    list.Remove(item);
                }
            }
        }

        private void appendLoot_Click(object sender, RoutedEventArgs e)
        {
            int relatedTo = Convert.ToInt32(appendRelation.Text);
            int item = Convert.ToInt32(appendItem.Text);
            int maxcount = Convert.ToInt32(appendMaxCount.Text);
            int incrTime = Convert.ToInt32(appendIncrTime.Text);
            int extendedCost = Convert.ToInt32(appendExtendedCost.Text);
            if (relatedTo == 0 || item == 0) return;
            VendorInfo info = new VendorInfo();
            info.ExtendedCost = extendedCost;
            info.IncrTime = incrTime;
            info.Item = item;
            info.MaxCount = (byte)maxcount;
            info.Slot = 0;
            info.VerifiedBuild = 10000;
            LegacyMorpher.Data.AppendVendorInfo(relatedTo, info);
        }
    }
}
