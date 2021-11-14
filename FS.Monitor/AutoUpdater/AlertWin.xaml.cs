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

namespace AutoUpdater
{
    /// <summary>
    /// AlertWin.xaml 的交互逻辑
    /// </summary>
    public partial class AlertWin : Window
    {
        public delegate void YesBtnEvent();
        public YesBtnEvent YesBtnEventCallBack;
        public AlertWin(string msg)
        {
            InitializeComponent();
            this.txtMsg.Text = msg;
        }

       

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            YesBtnEventCallBack?.Invoke();
            this.Close();
        }
    }
}
