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
    /// AchievementPanel.xaml 的交互逻辑
    /// </summary>
    public partial class AchievementPanel : UserControl
    {
        public AchievementPanel()
        {
            InitializeComponent();
        }
    }

    public class AchievementCategory
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int UIOrder { get; set; }
    }

    public class AchievementCriteria
    {
        public int ID { get; set; }
        public int Achievement { get; set; }
        public int Type { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }
        public int StartEvent { get; set; }
        public int StartAsset { get; set; }
        public int FailEvent { get; set; }
        public int FailAsset { get; set; }
        public string Description { get; set; }
        public int Flags { get; set; }
        public int TimerStartEvent { get; set; }
        public int TimerAssetID { get; set; }
        public int TimerTime { get; set; }
        public int UIOrder { get; set; }
    }

    public class Achievement
    {
        public int ID { get; set; }
        public int Faction { get; set; }
        public int Map { get; set; }
        public int Previous { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Points { get; set; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public int SpellIcon { get; set; }
        public string Reward { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
    }
}
