using FS.Monitor.Common.IniFile;
using FS.Monitor.Common.WindowClose;
using FS.Monitor.Model;
using FS.Monitor.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static FS.Monitor.Common.IniFile.Configuration;
using FS.Monitor.xmlFile;
using FS.Monitor.Common.Concover;
using FS.Monitor.Common;
using System.Windows.Forms;

namespace FS.Monitor.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        public SettingViewModel()
        {
            DispatcherHelper.Initialize();
            Monitor = new MonitorModel();
            InitData();
            InitDataFacility();
            InitDataUser();
        }

        #region 全局属性
        private MonitorModel _monitor;
        public MonitorModel Monitor
        {
            get { return _monitor; }
            set { _monitor = value; RaisePropertyChanged(() => Monitor); }
        }

        private ObservableCollection<MonitorModel> _monitorList;
        public ObservableCollection<MonitorModel> MonitorList
        {
            get { return _monitorList; }
            set { _monitorList = value; RaisePropertyChanged(() => MonitorList); }
        }

        /// <summary>
        /// 选中行
        /// </summary>
        private MonitorModel _selectedRow;
        public MonitorModel SelectedRow
        {
            get { return _selectedRow; }
            set { _selectedRow = value; RaisePropertyChanged(() => SelectedRow);}
        }

        private ObservableCollection<FacilityModel> _facilityList;
        public ObservableCollection<FacilityModel> FacilityList
        {
            get { return _facilityList; }
            set { _facilityList = value; RaisePropertyChanged(() => FacilityList); }
        }

        private ObservableCollection<UserInfoModel> _userList;
        public ObservableCollection<UserInfoModel> UserList
        {
            get { return _userList; }
            set { _userList = value; RaisePropertyChanged(() => UserList); }
        }

        //修改监测
        private RelayCommand _modifyMonitorCommand;
        public RelayCommand ModifyMonitorCommand
        {
            get
            {
                if (_modifyMonitorCommand == null)
                {
                    _modifyMonitorCommand = new RelayCommand(() => ModifyMonitor());
                }
                return _modifyMonitorCommand;
            }
            set { _modifyMonitorCommand = value; }
        }


        #endregion

        #region 新增监测管理
        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                {
                    //_addItemCommand = new RelayCommand(() => AddMonitorInfo());
                }
                return _addItemCommand;
            }
            set { _addItemCommand = value; }
        }

        private ObservableCollection<ObservableObject> _viewsClose = new ObservableCollection<ObservableObject>();
        public ObservableCollection<ObservableObject> ViewsClose
        {
            get { return _viewsClose; }
            set
            {
                _viewsClose = value;
                RaisePropertyChanged("ViewsClose");
            }
        }

        #endregion

        //public static AddItem addItemDialog =new AddItem();

        /// <summary>
        /// 加载监测管理
        /// </summary>
        private void InitData()
        {
            xmlHandleClass xmlHandle = new xmlHandleClass();
            xmlHandle.GetInitData();
            MonitorList = new ObservableCollection<MonitorModel>()
                 {
                    new MonitorModel(){ Id= Convert.ToInt32(xmlHandle.Id),
                                        ProjectName=xmlHandle.ProjectName,
                                        LineNumber=xmlHandle.LineNumber,
                                        NotEnable= xmlHandle.NotEnable,
                                        StartTime=xmlHandle.StartTime }
                    };


            //  XmlHelper xml = new XmlHelper(AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.XML_MONITOR + ".xml");

            //MonitorList = new ObservableCollection<MonitorModel>()
            //{
            //     new MonitorModel(){ Id=1, ProjectName="A煤矿",LineNumber="线路1", NotEnable="否",StartTime="-" },
            //     new MonitorModel(){ Id=2, ProjectName="B煤矿",LineNumber="线路2", NotEnable="是",StartTime= DateTime.Now.ToString("yyyyy/MMM/dddd") }
            //};
        }

        /// <summary>
        /// 加载设备管理
        /// </summary>
        private void InitDataFacility()
        {
            FacilityList = new ObservableCollection<FacilityModel>()
            {
                new FacilityModel(){Id=1,FacilityName="B煤矿尾部",Number="1",IpAddresss="192.168.1.1.16",Port=54323,FacilityState="1号点:正常", Route=""},
                new FacilityModel(){Id=2,FacilityName="A煤矿尾部",Number="2",IpAddresss="192.168.1.1.17",Port=54324,FacilityState="2号点:正常", Route="线路2"},
                new FacilityModel(){Id=3,FacilityName="C煤矿尾部",Number="3",IpAddresss="192.168.1.1.18",Port=54325,FacilityState="3号点:正常", Route="线路3"}
            };
        }

        /// <summary>
        /// 加载用户管理
        /// </summary>
        private void InitDataUser()
        {
            UserList = new ObservableCollection<UserInfoModel>()
            {
                new UserInfoModel(){Id =1,UserName="Admin",UserAuthority="用户权限",PassWord="*******"}
            };
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        private  void ModifyMonitor() 
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
