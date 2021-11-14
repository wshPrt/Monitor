using FS.Monitor.Model;
using FS.Monitor.ViewModel;
using FS.Monitor.xmlFile;
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
using System.Windows.Shapes;

namespace FS.Monitor.Views
{
    /// <summary>
    /// ModifyItem.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyItem : UserControl
    {
        public ModifyItem()
        {
            InitializeComponent();
            txtProjectName.Text = PublicModel.MonitorInfo.ProjectName;
            chbYse.IsChecked = Convert.ToBoolean(PublicModel.MonitorInfo.NotEnable);           
        }

        public object Message { get; internal set; }

        private void btnModifyMonitor_Click(object sender, RoutedEventArgs e)
        {
            if (PublicModel.MonitorInfo != null)
            {
                xmlHandleClass Modify = new xmlHandleClass();
                string[] ArrayData = new string[5];
                ArrayData[0] = PublicModel.MonitorInfo.Id.ToString();
                ArrayData[1] = PublicModel.MonitorInfo.ProjectName;
                ArrayData[2] = PublicModel.MonitorInfo.LineNumber;
                ArrayData[3] = PublicModel.MonitorInfo.NotEnable;
                ArrayData[4] = PublicModel.MonitorInfo.StartTime;
                Modify.Modify(ArrayData);
            }
        }
    }
}
