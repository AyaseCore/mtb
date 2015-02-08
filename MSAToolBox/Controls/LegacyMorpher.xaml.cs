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
using MSAToolBox.Utility;

namespace MSAToolBox.Controls
{
    /// <summary>
    /// LegacyMorpher.xaml 的交互逻辑
    /// </summary>
    public partial class LegacyMorpher : UserControl
    {
        public static DataDefineStore DefineStore;
        public static LegacyWorld Data;
        public LegacyMorpher()
        {
            InitializeComponent();
        }

        public void Load()
        {
            Data = new LegacyWorld();
            LoadDefines();
            creaturePanel.Load();
            itemPanel.Load();
            spellPanel.Load();
            skillPanel.Load();
            recipePanel.Load();
        }

        private void LoadDefines()
        {
            DefineStore = Data.GetDataDefines();
        }
    }
}
