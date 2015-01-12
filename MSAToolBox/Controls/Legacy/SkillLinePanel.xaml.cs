﻿using MSAToolBox.Utility;
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
    /// SkillLinePanel.xaml 的交互逻辑
    /// </summary>
    public partial class SkillLinePanel : UserControl
    {
        public static List<SkillLineAbility> SkillLineAbilities;
        public static List<SkillLine> SkillLines;
        public SkillLinePanel()
        {
            InitializeComponent();
        }

        public void Load()
        {
            LoadSkillLines();
            LoadSkillLineAbilities();
        }

        public void LoadSkillLineAbilities()
        {
            SkillLineAbilities = new List<SkillLineAbility>();
            using (FileStream stream = File.OpenRead(MainWindow.CLIENT_PATH + "DBFilesClient/SkillLineAbility.dbc"))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int fields = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringBlockSize = r.ReadInt32();
                for (int i = 0; i != records; ++i)
                {
                    SkillLineAbility ability = new SkillLineAbility();
                    ability.ID = r.ReadInt32();
                    ability.Skill = r.ReadInt32();
                    ability.Spell = r.ReadInt32();
                    ability.Race = r.ReadInt32();
                    ability.Class = r.ReadInt32();
                    stream.Position += 8;
                    ability.RequiredSkillValue = r.ReadInt32();
                    ability.SupercededBySpell = r.ReadInt32();
                    ability.AccquiredMethod = r.ReadInt32();
                    ability.SkillLineRankHigh = r.ReadInt32();
                    ability.SkillLineRankLow = r.ReadInt32();
                    stream.Position += 8;
                    SkillLineAbilities.Add(ability);
                }

                r.Close();

                skillLineGrid.ItemsSource = SkillLineAbilities;

                skillLabel.Content = "Loaded.";
            }
        }

        public void SaveSkillLineAbilities()
        {
            List<SkillLineAbility> skills = skillLineGrid.ItemsSource as List<SkillLineAbility>;

            using (FileStream stream = File.Create(MainWindow.CLIENT_PATH + "DBFilesClient/SkillLineAbility.dbc"))
            {
                BinaryWriter w = new BinaryWriter(stream);
                w.Write(0x43424457);
                w.Write(skills.Count);
                w.Write(14);
                w.Write(56);
                w.Write(0);
                foreach (var skill in skills)
                {
                    w.Write(skill.ID);
                    w.Write(skill.Skill);
                    w.Write(skill.Spell);
                    w.Write(skill.Race);
                    w.Write(skill.Class);
                    w.Write(0);
                    w.Write(0);
                    w.Write(skill.RequiredSkillValue);
                    w.Write(skill.SupercededBySpell);
                    w.Write(skill.AccquiredMethod);
                    w.Write(skill.SkillLineRankHigh);
                    w.Write(skill.SkillLineRankLow);
                    w.Write(0);
                    w.Write(0);
                }

                w.Close();

                File.Copy(MainWindow.CLIENT_PATH + "DBFilesClient/SkillLineAbility.dbc", MainWindow.SERVER_PATH + "dbc/SkillLineAbility.dbc", true);

                skillLabel.Content = "Saved.";
            }
        }

        public void LoadSkillLines()
        {
            SkillLines = new List<SkillLine>();

            using (FileStream stream = File.OpenRead(MainWindow.CLIENT_PATH + "DBFilesClient/SkillLine.dbc"))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                int rowCount = r.ReadInt32();
                int rowSize = r.ReadInt32();
                int stringBlockSize = r.ReadInt32();
                int dataSize = 20 + records * rowSize;
                for (int i = 0; i != records; ++i)
                {
                    SkillLine skill = new SkillLine();
                    skill.ID = r.ReadInt32();
                    skill.Category = r.ReadInt32();
                    skill.Cost = r.ReadInt32();
                    stream.Position += 16;
                    skill.Name = DBC.ReadString(r, dataSize);
                    stream.Position += 64;
                    skill.Description = DBC.ReadString(r, dataSize);
                    stream.Position += 48;
                    skill.Icon = r.ReadInt32();
                    stream.Position += 16;
                    skill.Verb = DBC.ReadString(r, dataSize);
                    stream.Position += 48;
                    skill.CanLink = r.ReadInt32();
                    SkillLines.Add(skill);
                }

                r.Close();
                skilllinesGrid.ItemsSource = SkillLines;
                abilitySkill.ItemsSource = SkillLines;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveSkillLineAbilities();
        }
    }
}
