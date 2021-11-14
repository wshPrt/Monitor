using FS.Monitor.Common;
using FS.Monitor.Common.Language;
using FS.Monitor.Views;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace FS.Monitor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 放大缩小
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            }));
        }
        
        private void Min_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Minimized)
            {
                WindowState = WindowState.Minimized;
            }

        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
                btnMAx.ToolTip = "向下还原";
                btnIcon.Kind = (PackIconKind)6016;
            }
            else 
            {
                WindowState = WindowState.Normal;
                btnIcon.Kind = (PackIconKind)6012;
                btnMAx.ToolTip = "最大化";
                
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill();
        }
        #endregion

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

        private void ButtonLangs_OnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.Tag is string langName)
            {
                PopupConfig.IsOpen = false;
                if (langName.Equals(GlobalData.Config.Lang)) return;
                ConfigHelper.Instance.SetLang(langName);
                LangProvider.Culture = new CultureInfo(langName);
                Messenger.Default.Send<object>(null, "LangUpdated");

                GlobalData.Config.Lang = langName;
                GlobalData.Save();
             }
        }
    }
}
