using FS.Monitor.Common.Scoket;
using FS.Monitor.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FS.Monitor.Common.Scoket.TcpSocket;

namespace FS.Monitor.ViewModel
{
   public class RunningViewModel: ViewModelBase
    {
        public RunningViewModel() 
        {
            ControlInfo = new ControlModel();
        }
       
        public ControlModel _controlInfo;
        public ControlModel ControlInfo
        {
            get { return _controlInfo; }
            set { _controlInfo = value; }
        }

        /// <summary>
        /// 扫描指令
        /// </summary>
        private RelayCommand _scanCommand;
        public RelayCommand ScanCommand
        {
            get
            {
                if (_scanCommand == null)
                {
                    _scanCommand = new RelayCommand(()=>Scan());
                }
                return _scanCommand; 
            }
            set { _scanCommand = value; }
        }

        /// <summary>
        /// 运行指令
        /// </summary>
        private RelayCommand _runningCommand;
        public RelayCommand RunningCommand
        {
            get
            {
                if (_runningCommand ==null)
                {
                    _runningCommand = new RelayCommand(() => RunStatus());
                }
                return _runningCommand; 
            }
            set { _runningCommand = value; }
        }
      
        /// <summary>
        /// 扫描
        /// </summary>
        private void Scan() 
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ControlInfo.Msg += "开始扫描:" + "\r";
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x0E }, Size = 1 });
            }));
        }
        /// <summary>
        /// 运行状态
        /// </summary>
        private void RunStatus() 
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ControlInfo.Msg += "开始运行:" + "\r";
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x12}, Size = 1 });
            }));
        }
    }
}
