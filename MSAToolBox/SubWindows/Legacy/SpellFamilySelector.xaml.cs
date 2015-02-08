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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MSAToolBox.Utility;
using MSAToolBox.Controls.Legacy;
using MSAToolBox.Controls;

namespace MSAToolBox.SubWindows.Legacy
{
    /// <summary>
    /// SpellFamilyFlagsSelector.xaml 的交互逻辑
    /// </summary>
    public partial class SpellFamilySelector : MetroWindow
    {
        SpellTemplate _spell;
        int _type;
        public SpellFamilySelector(SpellTemplate spell, int type)
        {
            // type:
            // 0 - spell family mask
            // 1 - spell effect mask 1
            // 2 - spell effect mask 2
            // 3 - spell effect mask 3
            InitializeComponent();
            _spell = spell;
            _type = type;
            long high, middle, low;
            switch (type)
            {
                case 0:
                    low = spell.FamilyMaskA;
                    middle = spell.FamilyMaskB;
                    high = spell.FamilyMaskC;
                    break;
                case 1:
                    low = spell.EffectSpellMaskA[0];
                    middle = spell.EffectSpellMaskB[0];
                    high = spell.EffectSpellMaskC[0];
                    break;
                case 2:
                    low = spell.EffectSpellMaskA[1];
                    middle = spell.EffectSpellMaskB[1];
                    high = spell.EffectSpellMaskC[1];
                    break;
                case 3:
                    low = spell.EffectSpellMaskA[2];
                    middle = spell.EffectSpellMaskB[2];
                    high = spell.EffectSpellMaskC[2];
                    break;
                default:    // should not happen
                    high = 0;
                    middle = 0;
                    low = 0;
                    break;
            }

            ffClass.ItemsSource = LegacyMorpher.DefineStore.SpellFamily;
            ffClass.SelectedValuePath = "Key";
            ffClass.DisplayMemberPath = "Value";
            ffClass.SelectedValue = spell.Family;

            l1.IsChecked = (low & 1 << 0) != 0;
            l2.IsChecked = (low & 1 << 1) != 0;
            l3.IsChecked = (low & 1 << 2) != 0;
            l4.IsChecked = (low & 1 << 3) != 0;
            l5.IsChecked = (low & 1 << 4) != 0;
            l6.IsChecked = (low & 1 << 5) != 0;
            l7.IsChecked = (low & 1 << 6) != 0;
            l8.IsChecked = (low & 1 << 7) != 0;
            l9.IsChecked = (low & 1 << 8) != 0;
            l10.IsChecked = (low & 1 << 9) != 0;
            l11.IsChecked = (low & 1 << 10) != 0;
            l12.IsChecked = (low & 1 << 11) != 0;
            l13.IsChecked = (low & 1 << 12) != 0;
            l14.IsChecked = (low & 1 << 13) != 0;
            l15.IsChecked = (low & 1 << 14) != 0;
            l16.IsChecked = (low & 1 << 15) != 0;
            l17.IsChecked = (low & 1 << 16) != 0;
            l18.IsChecked = (low & 1 << 17) != 0;
            l19.IsChecked = (low & 1 << 18) != 0;
            l20.IsChecked = (low & 1 << 19) != 0;
            l21.IsChecked = (low & 1 << 20) != 0;
            l22.IsChecked = (low & 1 << 21) != 0;
            l23.IsChecked = (low & 1 << 22) != 0;
            l24.IsChecked = (low & 1 << 23) != 0;
            l25.IsChecked = (low & 1 << 24) != 0;
            l26.IsChecked = (low & 1 << 25) != 0;
            l27.IsChecked = (low & 1 << 26) != 0;
            l28.IsChecked = (low & 1 << 27) != 0;
            l29.IsChecked = (low & 1 << 28) != 0;
            l30.IsChecked = (low & 1 << 29) != 0;
            l31.IsChecked = (low & 1 << 30) != 0;
            l32.IsChecked = (low & 1 << 31) != 0;
            m1.IsChecked = (middle & 1 << 0) != 0;
            m2.IsChecked = (middle & 1 << 1) != 0;
            m3.IsChecked = (middle & 1 << 2) != 0;
            m4.IsChecked = (middle & 1 << 3) != 0;
            m5.IsChecked = (middle & 1 << 4) != 0;
            m6.IsChecked = (middle & 1 << 5) != 0;
            m7.IsChecked = (middle & 1 << 6) != 0;
            m8.IsChecked = (middle & 1 << 7) != 0;
            m9.IsChecked = (middle & 1 << 8) != 0;
            m10.IsChecked = (middle & 1 << 9) != 0;
            m11.IsChecked = (middle & 1 << 10) != 0;
            m12.IsChecked = (middle & 1 << 11) != 0;
            m13.IsChecked = (middle & 1 << 12) != 0;
            m14.IsChecked = (middle & 1 << 13) != 0;
            m15.IsChecked = (middle & 1 << 14) != 0;
            m16.IsChecked = (middle & 1 << 15) != 0;
            m17.IsChecked = (middle & 1 << 16) != 0;
            m18.IsChecked = (middle & 1 << 17) != 0;
            m19.IsChecked = (middle & 1 << 18) != 0;
            m20.IsChecked = (middle & 1 << 19) != 0;
            m21.IsChecked = (middle & 1 << 20) != 0;
            m22.IsChecked = (middle & 1 << 21) != 0;
            m23.IsChecked = (middle & 1 << 22) != 0;
            m24.IsChecked = (middle & 1 << 23) != 0;
            m25.IsChecked = (middle & 1 << 24) != 0;
            m26.IsChecked = (middle & 1 << 25) != 0;
            m27.IsChecked = (middle & 1 << 26) != 0;
            m28.IsChecked = (middle & 1 << 27) != 0;
            m29.IsChecked = (middle & 1 << 28) != 0;
            m30.IsChecked = (middle & 1 << 29) != 0;
            m31.IsChecked = (middle & 1 << 30) != 0;
            m32.IsChecked = (middle & 1 << 31) != 0;
            h1.IsChecked = (high & 1 << 0) != 0;
            h2.IsChecked = (high & 1 << 1) != 0;
            h3.IsChecked = (high & 1 << 2) != 0;
            h4.IsChecked = (high & 1 << 3) != 0;
            h5.IsChecked = (high & 1 << 4) != 0;
            h6.IsChecked = (high & 1 << 5) != 0;
            h7.IsChecked = (high & 1 << 6) != 0;
            h8.IsChecked = (high & 1 << 7) != 0;
            h9.IsChecked = (high & 1 << 8) != 0;
            h10.IsChecked = (high & 1 << 9) != 0;
            h11.IsChecked = (high & 1 << 10) != 0;
            h12.IsChecked = (high & 1 << 11) != 0;
            h13.IsChecked = (high & 1 << 12) != 0;
            h14.IsChecked = (high & 1 << 13) != 0;
            h15.IsChecked = (high & 1 << 14) != 0;
            h16.IsChecked = (high & 1 << 15) != 0;
            h17.IsChecked = (high & 1 << 16) != 0;
            h18.IsChecked = (high & 1 << 17) != 0;
            h19.IsChecked = (high & 1 << 18) != 0;
            h20.IsChecked = (high & 1 << 19) != 0;
            h21.IsChecked = (high & 1 << 20) != 0;
            h22.IsChecked = (high & 1 << 21) != 0;
            h23.IsChecked = (high & 1 << 22) != 0;
            h24.IsChecked = (high & 1 << 23) != 0;
            h25.IsChecked = (high & 1 << 24) != 0;
            h26.IsChecked = (high & 1 << 25) != 0;
            h27.IsChecked = (high & 1 << 26) != 0;
            h28.IsChecked = (high & 1 << 27) != 0;
            h29.IsChecked = (high & 1 << 28) != 0;
            h30.IsChecked = (high & 1 << 29) != 0;
            h31.IsChecked = (high & 1 << 30) != 0;
            h32.IsChecked = (high & 1 << 31) != 0;

            flagH.Content = String.Format("H: {0:X8}", high);
            flagM.Content = String.Format("M: {0:X8}", middle);
            flagL.Content = String.Format("L: {0:X8}", low);

            foreach (var sp in SpellPanel.spells)
            {
                if (sp.Family != spell.Family)
                    continue;

                if ((sp.FamilyMaskA & 1 << 0) != 0)
                    sl1s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 1) != 0)
                    sl2s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 2) != 0)
                    sl3s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 3) != 0)
                    sl4s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 4) != 0)
                    sl5s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 5) != 0)
                    sl6s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 6) != 0)
                    sl7s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 7) != 0)
                    sl8s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 8) != 0)
                    sl9s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 9) != 0)
                    sl10s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 10) != 0)
                    sl11s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 11) != 0)
                    sl12s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 12) != 0)
                    sl13s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 13) != 0)
                    sl14s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 14) != 0)
                    sl15s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 15) != 0)
                    sl16s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 16) != 0)
                    sl17s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 17) != 0)
                    sl18s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 18) != 0)
                    sl19s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 19) != 0)
                    sl20s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 20) != 0)
                    sl21s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 21) != 0)
                    sl22s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 22) != 0)
                    sl23s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 23) != 0)
                    sl24s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 24) != 0)
                    sl25s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 25) != 0)
                    sl26s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 26) != 0)
                    sl27s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 27) != 0)
                    sl28s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 28) != 0)
                    sl29s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 29) != 0)
                    sl30s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 30) != 0)
                    sl31s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskA & 1 << 31) != 0)
                    sl32s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 0) != 0)
                    sm1s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 1) != 0)
                    sm2s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 2) != 0)
                    sm3s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 3) != 0)
                    sm4s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 4) != 0)
                    sm5s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 5) != 0)
                    sm6s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 6) != 0)
                    sm7s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 7) != 0)
                    sm8s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 8) != 0)
                    sm9s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 9) != 0)
                    sm10s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 10) != 0)
                    sm11s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 11) != 0)
                    sm12s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 12) != 0)
                    sm13s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 13) != 0)
                    sm14s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 14) != 0)
                    sm15s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 15) != 0)
                    sm16s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 16) != 0)
                    sm17s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 17) != 0)
                    sm18s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 18) != 0)
                    sm19s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 19) != 0)
                    sm20s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 20) != 0)
                    sm21s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 21) != 0)
                    sm22s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 22) != 0)
                    sm23s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 23) != 0)
                    sm24s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 24) != 0)
                    sm25s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 25) != 0)
                    sm26s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 26) != 0)
                    sm27s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 27) != 0)
                    sm28s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 28) != 0)
                    sm29s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 29) != 0)
                    sm30s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 30) != 0)
                    sm31s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskB & 1 << 31) != 0)
                    sm32s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 0) != 0)
                    sh1s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 1) != 0)
                    sh2s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 2) != 0)
                    sh3s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 3) != 0)
                    sh4s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 4) != 0)
                    sh5s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 5) != 0)
                    sh6s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 6) != 0)
                    sh7s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 7) != 0)
                    sh8s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 8) != 0)
                    sh9s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 9) != 0)
                    sh10s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 10) != 0)
                    sh11s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 11) != 0)
                    sh12s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 12) != 0)
                    sh13s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 13) != 0)
                    sh14s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 14) != 0)
                    sh15s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 15) != 0)
                    sh16s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 16) != 0)
                    sh17s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 17) != 0)
                    sh18s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 18) != 0)
                    sh19s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 19) != 0)
                    sh20s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 20) != 0)
                    sh21s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 21) != 0)
                    sh22s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 22) != 0)
                    sh23s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 23) != 0)
                    sh24s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 24) != 0)
                    sh25s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 25) != 0)
                    sh26s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 26) != 0)
                    sh27s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 27) != 0)
                    sh28s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 28) != 0)
                    sh29s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 29) != 0)
                    sh30s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 30) != 0)
                    sh31s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
                if ((sp.FamilyMaskC & 1 << 31) != 0)
                    sh32s.Items.Add(String.Format("{0} - {1}{2}", sp.ID, sp.Name, sp.Rank == "" ? "" : "(" + sp.Rank + ")"));
            }
        }

        public void UpdateFlags()
        {
            uint low = 0;
            if (l1.IsChecked == true)
                low += 1 << 0;
            if (l2.IsChecked == true)
                low += 1 << 1;
            if (l3.IsChecked == true)
                low += 1 << 2;
            if (l4.IsChecked == true)
                low += 1 << 3;
            if (l5.IsChecked == true)
                low += 1 << 4;
            if (l6.IsChecked == true)
                low += 1 << 5;
            if (l7.IsChecked == true)
                low += 1 << 6;
            if (l8.IsChecked == true)
                low += 1 << 7;
            if (l9.IsChecked == true)
                low += 1 << 8;
            if (l10.IsChecked == true)
                low += 1 << 9;
            if (l11.IsChecked == true)
                low += 1 << 10;
            if (l12.IsChecked == true)
                low += 1 << 11;
            if (l13.IsChecked == true)
                low += 1 << 12;
            if (l14.IsChecked == true)
                low += 1 << 13;
            if (l15.IsChecked == true)
                low += 1 << 14;
            if (l16.IsChecked == true)
                low += 1 << 15;
            if (l17.IsChecked == true)
                low += 1 << 16;
            if (l18.IsChecked == true)
                low += 1 << 17;
            if (l19.IsChecked == true)
                low += 1 << 18;
            if (l20.IsChecked == true)
                low += 1 << 19;
            if (l21.IsChecked == true)
                low += 1 << 20;
            if (l22.IsChecked == true)
                low += 1 << 21;
            if (l23.IsChecked == true)
                low += 1 << 22;
            if (l24.IsChecked == true)
                low += 1 << 23;
            if (l25.IsChecked == true)
                low += 1 << 24;
            if (l26.IsChecked == true)
                low += 1 << 25;
            if (l27.IsChecked == true)
                low += 1 << 26;
            if (l28.IsChecked == true)
                low += 1 << 27;
            if (l29.IsChecked == true)
                low += 1 << 28;
            if (l30.IsChecked == true)
                low += 1 << 29;
            if (l31.IsChecked == true)
                low += 1 << 30;
            if (l32.IsChecked == true)
                low += 0x80000000;

            uint middle = 0;
            if (m1.IsChecked == true)
                middle += 1 << 0;
            if (m2.IsChecked == true)
                middle += 1 << 1;
            if (m3.IsChecked == true)
                middle += 1 << 2;
            if (m4.IsChecked == true)
                middle += 1 << 3;
            if (m5.IsChecked == true)
                middle += 1 << 4;
            if (m6.IsChecked == true)
                middle += 1 << 5;
            if (m7.IsChecked == true)
                middle += 1 << 6;
            if (m8.IsChecked == true)
                middle += 1 << 7;
            if (m9.IsChecked == true)
                middle += 1 << 8;
            if (m10.IsChecked == true)
                middle += 1 << 9;
            if (m11.IsChecked == true)
                middle += 1 << 10;
            if (m12.IsChecked == true)
                middle += 1 << 11;
            if (m13.IsChecked == true)
                middle += 1 << 12;
            if (m14.IsChecked == true)
                middle += 1 << 13;
            if (m15.IsChecked == true)
                middle += 1 << 14;
            if (m16.IsChecked == true)
                middle += 1 << 15;
            if (m17.IsChecked == true)
                middle += 1 << 16;
            if (m18.IsChecked == true)
                middle += 1 << 17;
            if (m19.IsChecked == true)
                middle += 1 << 18;
            if (m20.IsChecked == true)
                middle += 1 << 19;
            if (m21.IsChecked == true)
                middle += 1 << 20;
            if (m22.IsChecked == true)
                middle += 1 << 21;
            if (m23.IsChecked == true)
                middle += 1 << 22;
            if (m24.IsChecked == true)
                middle += 1 << 23;
            if (m25.IsChecked == true)
                middle += 1 << 24;
            if (m26.IsChecked == true)
                middle += 1 << 25;
            if (m27.IsChecked == true)
                middle += 1 << 26;
            if (m28.IsChecked == true)
                middle += 1 << 27;
            if (m29.IsChecked == true)
                middle += 1 << 28;
            if (m30.IsChecked == true)
                middle += 1 << 29;
            if (m31.IsChecked == true)
                middle += 1 << 30;
            if (m32.IsChecked == true)
                middle += 0x80000000;

            uint high = 0;
            if (h1.IsChecked == true)
                high += 1 << 0;
            if (h2.IsChecked == true)
                high += 1 << 1;
            if (h3.IsChecked == true)
                high += 1 << 2;
            if (h4.IsChecked == true)
                high += 1 << 3;
            if (h5.IsChecked == true)
                high += 1 << 4;
            if (h6.IsChecked == true)
                high += 1 << 5;
            if (h7.IsChecked == true)
                high += 1 << 6;
            if (h8.IsChecked == true)
                high += 1 << 7;
            if (h9.IsChecked == true)
                high += 1 << 8;
            if (h10.IsChecked == true)
                high += 1 << 9;
            if (h11.IsChecked == true)
                high += 1 << 10;
            if (h12.IsChecked == true)
                high += 1 << 11;
            if (h13.IsChecked == true)
                high += 1 << 12;
            if (h14.IsChecked == true)
                high += 1 << 13;
            if (h15.IsChecked == true)
                high += 1 << 14;
            if (h16.IsChecked == true)
                high += 1 << 15;
            if (h17.IsChecked == true)
                high += 1 << 16;
            if (h18.IsChecked == true)
                high += 1 << 17;
            if (h19.IsChecked == true)
                high += 1 << 18;
            if (h20.IsChecked == true)
                high += 1 << 19;
            if (h21.IsChecked == true)
                high += 1 << 20;
            if (h22.IsChecked == true)
                high += 1 << 21;
            if (h23.IsChecked == true)
                high += 1 << 22;
            if (h24.IsChecked == true)
                high += 1 << 23;
            if (h25.IsChecked == true)
                high += 1 << 24;
            if (h26.IsChecked == true)
                high += 1 << 25;
            if (h27.IsChecked == true)
                high += 1 << 26;
            if (h28.IsChecked == true)
                high += 1 << 27;
            if (h29.IsChecked == true)
                high += 1 << 28;
            if (h30.IsChecked == true)
                high += 1 << 29;
            if (h31.IsChecked == true)
                high += 1 << 30;
            if (h32.IsChecked == true)
                high += 0x80000000;

            flagH.Content = String.Format("H: {0:X8}", high);
            flagM.Content = String.Format("M: {0:X8}", middle);
            flagL.Content = String.Format("L: {0:X8}", low);

            switch (_type)
            {
                case 0:
                    _spell.FamilyMaskA = low;
                    _spell.FamilyMaskB = middle;
                    _spell.FamilyMaskC = high;
                    break;
                case 1:
                    _spell.EffectSpellMaskA[0] = low;
                    _spell.EffectSpellMaskB[0] = middle;
                    _spell.EffectSpellMaskC[0] = high;
                    break;
                case 2:
                    _spell.EffectSpellMaskA[1] = low;
                    _spell.EffectSpellMaskB[1] = middle;
                    _spell.EffectSpellMaskC[1] = high;
                    break;
                case 3:
                    _spell.EffectSpellMaskA[2] = low;
                    _spell.EffectSpellMaskB[2] = middle;
                    _spell.EffectSpellMaskC[2] = high;
                    break;
                default:
                    break;
            }
        }

        private void flags_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlags();
        }
    }
}
