using MSAToolBox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// EnchantsPanel.xaml 的交互逻辑
    /// </summary>
    public partial class EnchantsPanel : UserControl
    {
        public static List<SpellItemEnchantment> ItemEnchantments;
        public static List<ItemRandomProperty> ItemRandomProperties;
        public static List<ItemEnchantmentTemplate> DBEnchants;

        public EnchantsPanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            ItemEnchantments = new List<SpellItemEnchantment>();
            using (FileStream stream = File.OpenRead(MainWindow.CLIENT_PATH + "DBFilesClient/SpellItemEnchantment.dbc"))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int columns = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringSize = r.ReadInt32();
                int dataSize = 20 + rowSize * records;
                for (int i = 0; i != records; ++i)
                {
                    SpellItemEnchantment enchant = new SpellItemEnchantment();
                    enchant.ID = r.ReadInt32();
                    enchant.Charges = r.ReadInt32();
                    enchant.EnchantType[0] = r.ReadInt32();
                    enchant.EnchantType[1] = r.ReadInt32();
                    enchant.EnchantType[2] = r.ReadInt32();
                    enchant.Min[0] = r.ReadInt32();
                    enchant.Min[1] = r.ReadInt32();
                    enchant.Min[2] = r.ReadInt32();
                    enchant.Max[0] = r.ReadInt32();
                    enchant.Max[1] = r.ReadInt32();
                    enchant.Max[2] = r.ReadInt32();
                    enchant.Object[0] = r.ReadInt32();
                    enchant.Object[1] = r.ReadInt32();
                    enchant.Object[2] = r.ReadInt32();
                    enchant.Name = DBC.ReadString(r, dataSize, 4*4, 4*11);
                    enchant.NameFlags = r.ReadInt32();
                    enchant.ItemVisual = r.ReadInt32();
                    enchant.Slot = r.ReadInt32();
                    enchant.Item = r.ReadInt32();
                    enchant.Condition = r.ReadInt32();
                    enchant.SkillLine = r.ReadInt32();
                    enchant.SkillLevel = r.ReadInt32();
                    enchant.RequiredLevel = r.ReadInt32();
                    ItemEnchantments.Add(enchant);
                }
                r.Close();
            }
            enchantsGrid.ItemsSource = ItemEnchantments;

            ItemRandomProperties = new List<ItemRandomProperty>();
            using (FileStream stream = File.OpenRead(MainWindow.CLIENT_PATH + "DBFilesClient/ItemRandomProperties.dbc"))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int columns = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringSize = r.ReadInt32();
                int dataSize = 20 + rowSize * records;
                for (int i = 0; i != records; ++i)
                {
                    ItemRandomProperty prop = new ItemRandomProperty();
                    prop.ID = r.ReadInt32();
                    prop.InnerName = DBC.ReadString(r, dataSize);
                    prop.Enchant[0] = r.ReadInt32();
                    prop.Enchant[1] = r.ReadInt32();
                    prop.Enchant[2] = r.ReadInt32();
                    prop.Enchant[3] = r.ReadInt32();
                    prop.Enchant[4] = r.ReadInt32();
                    prop.Name = DBC.ReadString(r, dataSize, 4*4, 4*11);
                    prop.NameFlag = r.ReadInt32();
                    ItemRandomProperties.Add(prop);
                }
                r.Close();
            }
            randomPropertiesGrid.ItemsSource = ItemRandomProperties;

            DBEnchants = new List<ItemEnchantmentTemplate>();
            DBEnchants = LegacyWorld.GetItemEnchants().ToList();
            dbEnchantGrid.ItemsSource = DBEnchants;
        }

        public void Save()
        {
            using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/ItemRandomProperties.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, ItemRandomProperties.Count, 24, 96);
                List<string> stringBlock = new List<string>();
                int ofs = 1;
                foreach (var prop in ItemRandomProperties)
                {
                    w.Write(prop.ID);
                    DBC.WriteString(w, prop.InnerName, ref ofs, ref stringBlock);
                    for (int i = 0; i != 5; i++)
                        w.Write(prop.Enchant[i]);
                    DBC.WriteString(w, prop.Name, ref ofs, ref stringBlock, 4, 11);
                    w.Write(prop.NameFlag);
                }
                w.Write((byte)0);
                foreach (var s in stringBlock)
                    w.Write(Encoding.UTF8.GetBytes(s + "\0"));
                stream.Position = 16;
                w.Write(ofs);
                w.Close();
            }

            File.Copy(MainWindow.CLIENT_PATH + "DBFilesClient/ItemRandomProperties.dbc", MainWindow.SERVER_PATH + "dbc/ItemRandomProperties.dbc", true);

            using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/SpellItemEnchantment.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                DBC.WriteDBCHeader(w, ItemEnchantments.Count, 38, 152);
                List<string> stringBlock = new List<string>();
                int ofs = 1;
                foreach (var enchant in ItemEnchantments)
                {
                    w.Write(enchant.ID);
                    w.Write(enchant.Charges);
                    for (int i = 0; i != 3; i++)
                        w.Write(enchant.EnchantType[i]);
                    for (int i = 0; i != 3; i++)
                        w.Write(enchant.Min[i]);
                    for (int i = 0; i != 3; i++)
                        w.Write(enchant.Max[i]);
                    for (int i = 0; i != 3; i++)
                        w.Write(enchant.Object[i]);
                    DBC.WriteString(w, enchant.Name, ref ofs, ref stringBlock, 4, 11);
                    w.Write(enchant.NameFlags);
                    w.Write(enchant.ItemVisual);
                    w.Write(enchant.Slot);
                    w.Write(enchant.Item);
                    w.Write(enchant.Condition);
                    w.Write(enchant.SkillLine);
                    w.Write(enchant.SkillLevel);
                    w.Write(enchant.RequiredLevel);
                }
                w.Write((byte)0);
                foreach (var s in stringBlock)
                    w.Write(Encoding.UTF8.GetBytes(s + "\0"));
                stream.Position = 16;
                w.Write(ofs);
                w.Close();
            }

            File.Copy(MainWindow.CLIENT_PATH + "DBFilesClient/SpellItemEnchantment.dbc", MainWindow.SERVER_PATH + "dbc/SpellItemEnchantment.dbc", true);

            LegacyWorld.SaveItemEnchants(DBEnchants);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
