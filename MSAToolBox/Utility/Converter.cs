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
                return (from d in CreatureGossipPanel.CreatureNames where d.Key == entry select d.Value).SingleOrDefault();
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
            return (from d in SkillLinePanel.SkillLines where d.ID == (int)value select d.Description).SingleOrDefault();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    } 
}

