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
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace MSAToolBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static string CLIENT_PATH = "E:/CLIENT/V4/";
        public static string SERVER_PATH = "E:/SERVER/V4/";
        public static string ASSET_PATH = "F:/Projects/ass/";

        public MainWindow()
        {
            InitializeComponent();
            legacyMorpher.Load();
        }

        private void restartGame_Click(object sender, RoutedEventArgs e)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.ProcessName == "Wow" || p.ProcessName == "worldserver")
                    p.Kill();
            }
            ProcessStartInfo psi1 = new ProcessStartInfo("worldserver.exe");
            psi1.WorkingDirectory = "E:\\SERVER\\V4\\";
            ProcessStartInfo psi2 = new ProcessStartInfo("Local.bat");
            psi2.WorkingDirectory = "E:\\CLIENT\\V4\\";
            Process.Start(psi1);
            Process.Start(psi2);
        }
    }
}
