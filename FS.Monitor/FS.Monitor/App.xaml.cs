using FS.Monitor.Common;
using FS.Monitor.Common.Language;
using FS.Monitor.Common.Scoket;
using FS.Monitor.Model;
using FS.Monitor.ViewModel;
using FS.Monitor.Views;
using Lierda.WPFHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FS.Monitor
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        LierdaCracker cracker = new LierdaCracker();
        public static TcpSocket _tcp;
        public static ControlModel _control;
        public static Mutex AppMutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                cracker.Cracker();
                base.OnStartup(e);

                MainWindow mw = new MainWindow();
                LoginView login = new LoginView();

                LoginViewModel loginVM = new LoginViewModel();
                loginVM.Version();

                #region 中英文
                GlobalData.Init();
                ConfigHelper.Instance.SetLang(GlobalData.Config.Lang);
                LangProvider.Culture = new CultureInfo(GlobalData.Config.Lang);
                ConfigHelper.Instance.SetWindowDefaultStyle();
                ConfigHelper.Instance.SetNavigationWindowDefaultStyle();
//#if NET40
//                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
//#else
//                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//#endif
                #endregion

                _control = new ControlModel();

                #region 开启 Socket
                _tcp = new TcpSocket();
                Data obj = new Data();
                _tcp._Receipt += obj._tcp_Receipt;
                #endregion
              
                var a = login.ShowDialog();
                if (a.HasValue && a.Value)
                {
                    mw.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
