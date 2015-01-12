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
using MSAToolBox.LegacyServices;

namespace MSAToolBox.Controls
{
    /// <summary>
    /// LegacyMorpher.xaml 的交互逻辑
    /// </summary>
    public partial class LegacyMorpher : UserControl
    {
        public static DataDefineStore DefineStore;
        public LegacyMorpher()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            LoadDefines();
            creaturePanel.Load();
            itemPanel.Load();
            spellPanel.Load();
            skillPanel.Load();
        }

        private void LoadDefines()
        {
            using (LegacyServiceClient client = new LegacyServiceClient("Legacy"))
            {
                DefineStore = client.GetDataDefines();
            }
        }
    }
}
