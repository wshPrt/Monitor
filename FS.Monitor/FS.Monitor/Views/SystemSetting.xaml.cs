using FS.Monitor.Common.MessageDialog;
using FS.Monitor.Model;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
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

namespace FS.Monitor.Views
{
    /// <summary>
    /// SystemSetting.xaml 的交互逻辑
    /// </summary>
    public partial class SystemSetting : UserControl
    {
        public SystemSetting()
        {
            InitializeComponent();
        }

        public async void MessageTips(string message, object sender, RoutedEventArgs e)
        {
            if (sender.ToString().Contains("添加项目") || sender.ToString().Contains("Add Item"))
            {
                var sampleMessageDialog = new AddItem
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
            else if (sender.ToString().Contains("修改") || sender.ToString().Contains("Revise")) 
            {
                PublicModel.ModifyItemInfo  = new ModifyItem()
                {
                    Message = message
                };
                
                await DialogHost.Show(PublicModel.ModifyItemInfo, "RootDialog");
                
            }
            else if (sender.ToString().Contains("删除") || sender.ToString().Contains("Delete"))
            {
                var sampleMessageDialog = new DelItemTips
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
        }
        public async void DeviceMessageTips(string message, object sender, RoutedEventArgs e)
        {
            if (sender.ToString().Contains("添加设备")|| sender.ToString().Contains("AddDevice"))
            {
                 var sampleMessageDialog = new AddFacility
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
            if (sender.ToString().Contains("修改")|| sender.ToString().Contains("Modify"))
            {
                var sampleMessageDialog = new ModifyFacility
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
            else if(sender.ToString().Contains("删除")|| sender.ToString().Contains("Delete"))
            {
                var sampleMessageDialog = new DelTips
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
        }
        public async void UserMessageTips(string message, object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new ModifyUser
            {
                Message = message
            };
            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }
            private void Addmonitor_Click(object sender, RoutedEventArgs e)
             {
                MessageTips("请确认", sender, e);
             }

       // public MonitorModel _MonitorInfo;
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dgMonitor.SelectedItem == null)
            {
                MessageDialogManager.ShowDialogAsync("未选中呢!");
                return;
            }
            else 
            {
                PublicModel.MonitorInfo = dgMonitor.SelectedItem as MonitorModel;
                MessageTips("请确认", sender, e);
            }
            
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            MessageTips("请确认", sender, e);
        }

        private void DeviceAdd_Click(object sender, RoutedEventArgs e)
        {
            DeviceMessageTips("请确认", sender, e);
        }
        private void DeviceEdit_Click(object sender, RoutedEventArgs e)
        {
            DeviceMessageTips("请确认", sender, e);
        }

        private void DeviceDel_Click(object sender, RoutedEventArgs e)
        {
            DeviceMessageTips("请确认", sender, e);
        }

        private void UserEdit_Click(object sender, RoutedEventArgs e)
        {
            UserMessageTips("请确认", sender, e);
        }
    }
}
