using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MSAToolBox.Utility
{
    public static class Util
    {
        public static void AssignDefine(ComboBox c, Dictionary<int, string> dict)
        {
            c.DisplayMemberPath = "Value";
            c.SelectedValuePath = "Key";
            c.ItemsSource = dict;
        }
    }
}
