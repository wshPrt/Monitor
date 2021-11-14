using FS.Monitor.ViewModel;
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
    /// DownFileProcess.xaml 的交互逻辑
    /// </summary>
    public partial class DownFileProcess : Window
    {
        public DownFileProcess(string version)
        {
            InitializeComponent();
            this.ProgressBar.Visibility = Visibility.Collapsed;
            this.tb_ver.Text = version;
            this.DataContext = new MaintainViewModel();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void W_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
