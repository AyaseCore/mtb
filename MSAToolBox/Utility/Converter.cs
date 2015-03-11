using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MSAToolBox.Controls;
using MSAToolBox.Controls.Legacy;

namespace MSAToolBox.Utility
{
    public class QualityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int quality = (int)value;
            switch (quality)
            {
                case 0:
                    return new SolidColorBrush(Colors.Gray);
                case 1:
                    return new SolidColorBrush(Colors.White);
                case 2:
                    return new SolidColorBrush(Colors.Green);
                case 3:
                    return new SolidColorBrush(Colors.Blue);
                case 4:
                    return new SolidColorBrush(Colors.Purple);
                case 5:
                    return new SolidColorBrush(Colors.Orange);
                case 6:
                    return new SolidColorBrush(Colors.Gold);
                case 7:
                    return new SolidColorBrush(Colors.Aqua);
                default:
                    return new SolidColorBrush(Colors.BlanchedAlmond);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ItemNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int entry = (int)value;
            return (from d in ItemPanel.ItemList where d.Entry == entry select d.Name).SingleOrDefault();

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class CreatureNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int entry = 0;
            try
            {
                entry = System.Convert.ToInt32(value);
                return "NYI";
            }
            catch (System.Exception /*ex*/)
            {
                return "";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class CreatureRankColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int quality = (int)value;
            switch (quality)
            {
                case 0:
                    return new SolidColorBrush(Colors.White);
                case 1:
                    return new SolidColorBrush(Colors.Green);
                case 2:
                    return new SolidColorBrush(Colors.Purple);
                case 3:
                    return new SolidColorBrush(Colors.Orange);
                case 4:
                    return new SolidColorBrush(Colors.Blue);
                default:
                    return new SolidColorBrush(Colors.BlanchedAlmond);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ItemInUseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value == true ? "(In Use)" : "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class SpellNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int entry = (int)value;
            if (entry < 0)
                return "Reference";
            if (SpellPanel.spells == null)
                return "";
            var s = (from d in SpellPanel.spells where d.ID == entry select new { d.Name, d.Rank }).SingleOrDefault();
            if (s != null)
                return s.Name + (s.Rank == "" ? "" : "(" + s.Rank + ")");
            else
                return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class SpellDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (SpellPanel.spells == null)
                return "";
            return (from d in SpellPanel.spells where d.ID == (int)value select d.Description).SingleOrDefault();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class SkillNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (SkillLinePanel.SkillLines == null)
                return "";
            return (from d in SkillLinePanel.SkillLines where d.ID == (int)value select d.Name).SingleOrDefault();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class LootBgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int reference = (int)value;
            if (reference == 0)
                return new SolidColorBrush(Colors.Black);
            else
                return new SolidColorBrush(Colors.Gray);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class SpellEnchantNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (EnchantsPanel.ItemEnchantments == null || EnchantsPanel.ItemRandomProperties == null)
                return "";
            int prop = (int)value;
            if (prop == 0) return "";
            var p = (from d in EnchantsPanel.ItemRandomProperties where d.ID == prop select d).SingleOrDefault();
            if (p == null) return "";
            var s1 = (from d in EnchantsPanel.ItemEnchantments where d.ID == p.Enchant[0] select d.Name).SingleOrDefault();
            var s2 = (from d in EnchantsPanel.ItemEnchantments where d.ID == p.Enchant[1] select d.Name).SingleOrDefault();
            var s3 = (from d in EnchantsPanel.ItemEnchantments where d.ID == p.Enchant[2] select d.Name).SingleOrDefault();
            var s4 = (from d in EnchantsPanel.ItemEnchantments where d.ID == p.Enchant[3] select d.Name).SingleOrDefault();
            var s5 = (from d in EnchantsPanel.ItemEnchantments where d.ID == p.Enchant[4] select d.Name).SingleOrDefault();
            return String.Format("{0} | {1} | {2} | {3} | {4}", s1 == null ? "null" : s1, s2 == null ? "null" : s2, s3 == null ? "null" : s3, s4 == null ? "null" : s4, s5 == null ? "null" : s5);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class BroadCastTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int entry = (int)value;
            if (entry == 0)
                return "<no bct assigned>";
            else
            {
                BroadCastText text = LegacyWorld.GetBroadCastText(entry);
                if (text == null)
                    return "<bct entry not exist>";
                if (text.MaleText == "")
                    return text.FemaleText;
                return text.MaleText;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}

