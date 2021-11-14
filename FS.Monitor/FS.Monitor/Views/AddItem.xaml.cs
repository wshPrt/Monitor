using FS.Monitor.Common;
using FS.Monitor.Common.IniFile;
using FS.Monitor.Common.WindowClose;
using FS.Monitor.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using static FS.Monitor.Common.IniFile.Configuration;
using FS.Monitor.xmlFile;

namespace FS.Monitor.Views
{
    /// <summary>
    /// AddItem.xaml 的交互逻辑
    /// </summary>
    public partial class AddItem: UserControl
    {
        public AddItem()
        {
            InitializeComponent();
            Monitor = new MonitorModel();
        }

        public string Message { get; internal set; }

        private MonitorModel _monitor;
        public MonitorModel Monitor
        {
            get { return _monitor; }
            set { _monitor = value; }
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            xmlHandleClass xmlHandleClass = new xmlHandleClass();
            xmlHandleClass.newXml(Monitor.Id.ToString(), txtUserName.Text.Trim(), "1号线路", chkYes.IsChecked.ToString(), Monitor.StartTime);

            //Hashtable ht = new Hashtable();
            //ht.Add("Id", Monitor.Id.ToString());
            //ht.Add("ProjectName", txtUserName.Text.Trim());
            //ht.Add("LineNumber", "1号线路");
            //ht.Add("NotEnable", chkYes.IsChecked.ToString());
            //ht.Add("StartTime", Monitor.StartTime);
            //PublicModel._xmlHelper = new XmlHelper(AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.XML_MONITOR + ".xml", "utf-8");
            //var messgae = PublicModel._xmlHelper.InsertNode("MonitorManage", true, "MonitorManage", ht, ht);
            //XmlHelpers xml = new XmlHelpers(AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.XML_MONITOR + ".xml");
            //xml.InsertNode("MonitorManage", "Monitor", "Id", Monitor.Id.ToString());

        }
    }
}
