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

namespace FS.Monitor.Views
{
    /// <summary>
    /// ExitWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExitWindow : Window
    {
        private Window parentWindow;
        public ExitWindow(Window mainWindow)
        {
            InitializeComponent();
            this.Topmost = true;
            this.Left = 5;
            this.Top = 5;
            parentWindow = mainWindow;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            parentWindow.Hide();
        }
    }
}
