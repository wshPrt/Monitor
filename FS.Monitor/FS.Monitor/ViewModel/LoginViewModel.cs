using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FS.Monitor.Common.IniFile;
using FS.Monitor.Common.MD5Poxy;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json.Linq;
using FS.Monitor.ViewModel;
using static FS.Monitor.Common.IniFile.Configuration;
using FS.Monitor.Interface;
using FS.Monitor.Model;
using System.Collections.ObjectModel;
using FS.Monitor.Common.FTP;
using FS.Monitor.Views;
using System.Diagnostics;
using FS.Monitor.Common;

namespace FS.Monitor.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region 属性 
        private string userName = "admin";
        private string passWord = "123456";
        private string report;
        private string isCancel;
        private bool userChecked;
        public string _UserName;//文本账号
        public string _PassWord;//文本密码
        public static int _VersionValue;//版本值
        public static string _Version;//版本编号

        public LoginViewModel()
        {
            VersionInfo = new VersionInfoModel();
            VersionInfoList = new ObservableCollection<VersionInfoModel>();
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(() => UserName); }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(() => PassWord); }
        }

        public string Report
        {
            get { return report; }
            set { report = value; RaisePropertyChanged(() => Report); }
        }

        public string IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; }
        }

        public bool UserChecked
        {
            get { return userChecked; }
            set { userChecked = value; RaisePropertyChanged(() => userChecked); }
        }
        private bool toClose = false;
        /// <summary>
        /// 是否要关闭窗口
        /// </summary>
        public bool ToClose
        {
            get
            {
                return toClose;
            }
            set
            {
                if (toClose != value)
                {
                    toClose = value;
                    this.RaisePropertyChanged("ToClose");
                }
            }

        }
        private RelayCommand _execute;
        public RelayCommand Execute
        {
            get
            {
                if (_execute == null)
                {
                    _execute = new RelayCommand(() => Login());
                }
                return _execute;
            }
            set { _execute = value; }
        }

        /// <summary>
        /// 获取最新信息
        /// </summary>
        private ObservableCollection<VersionInfoModel> _versionInfoList;
        public ObservableCollection<VersionInfoModel> VersionInfoList
        {
            get { return _versionInfoList; }
            set { _versionInfoList = value; RaisePropertyChanged(() => VersionInfoList); }
        }

        private VersionInfoModel _versionInfo;
        public VersionInfoModel VersionInfo
        {
            get { return _versionInfo; }
            set { _versionInfo = value; RaisePropertyChanged(() => VersionInfo); }
        }

        #endregion

        /// <summary>
        /// 登录系统
        /// </summary>
        public async void Login()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
                {
                    Report = "请输入账号和密码!";
                    return;
                }

                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(PassWord))
                {
                    //读取本地文件
                    string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_CFG;
                    var LoginTask = Task.Run(() =>
                    {
                        if (File.Exists(cfgINI))
                        {
                            IniFiles ini = new IniFiles(cfgINI);
                            _UserName = ini.IniReadValue("Login", "User");
                            _PassWord = CEncoder.Decode(ini.IniReadValue("Login", "Password"));
                        }
                    });

                    var timeouttask = Task.Run(() =>
                    {
                        JObject a = null;
                        Thread.Sleep(3000);
                        return a;
                    });
                    var completedTask = await Task.WhenAny(LoginTask, timeouttask);
                    var data = completedTask;
                    if (data == null)
                    {
                        Report = "系统连接超时,请联系管理员!";
                    }
                    else
                    {
                        if (UserName == _UserName && PassWord == _PassWord)
                        {
                            //UserName = "";
                            //PassWord = "";
                            ToClose = true;
                            return;

                        }
                        else
                        {
                            UserName = "";
                            PassWord = "";
                            Report = "账号或密码错误!";
                        }
                    }
                }
                else
                {
                    Report = "密码或账号不能空！";
                    return;
                }
            }
            catch (Exception ex)
            {
                Report = ex.ToString();
            }
        }

        /// <summary>
        /// 版本对比
        /// </summary>
        public void Version()
        {
            GetNewestVersion();
            
            int version = 0;
            //版本编号
            string version_no = null;
            //读取本地版本号
            ReadVersion(ref version, ref version_no);
            if (version > 0)
            {
                if (_Version == null || _Version == version_no)
                {
                    return;
                }
                DownFileProcess down = new DownFileProcess(version_no);
                down.ShowDialog();
            }
        }

        #region 读取版本
        public void ReadVersion(ref int version, ref string version_no)
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_VERSION;
            if (File.Exists(cfgINI))
            {
                IniFiles ini = new IniFiles(cfgINI);
                int.TryParse(ini.IniReadValue("Version", "Version_NO"), out version);
                version_no = ini.IniReadValue("Version", "Version");
            }
        }
        #endregion

        #region 写入版本
        public static void WriteVersion() 
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_VERSION;
            IniFiles ini = new IniFiles(cfgINI);
            ini.IniWriteValue("Version", "version", "");
            ini.IniWriteValue("Version", "Version", _Version);
            ini.IniWriteValue("Version", "Version_NO", _VersionValue.ToString());
        }
        #endregion
        /// <summary>
        /// 获取最新版本
        /// </summary>
        public void GetNewestVersion()
        {
             Task.Factory.StartNew(() =>
              {
                  int os_type = 2;//系统类型，1:linux，2:win
                  IGetSoftwareVersion getVersion = new IGetSoftwareVersion();
                  var reuslt = getVersion.GetSoftwareVersion(os_type).Result;
                  string success = reuslt.msg;
                  if (success == "读取成功")
                  {
                       VersionInfo.Sign = reuslt.data.sign;
                      _VersionValue = reuslt.data.version_number;
                      _Version = reuslt.data.version;
                      VersionInfoList.Add(VersionInfo);
                }
              });
            Thread.Sleep(300);
        }
    }
}

