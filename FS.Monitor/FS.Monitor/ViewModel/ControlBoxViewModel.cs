using FS.Monitor.Common.Scoket;
using FS.Monitor.Common.Scoket.Utils;
using FS.Monitor.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static FS.Monitor.Common.Scoket.TcpSocket;

namespace FS.Monitor.ViewModel
{
    public class ControlBoxViewModel : ViewModelBase
    {
        //public IOSocket _socket = null;
        public ControlBoxViewModel()
        {
            Control = new ControlModel();
        }

        #region 窗体加载
        private RelayCommand _loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(() => Loading());
                }
                return _loadCommand;
            }
            set { _loadCommand = value; }
        }
        private ControlModel _control;
        public ControlModel Control
        {
            get { return _control; }
            set { _control = value; RaisePropertyChanged(() => Control); }
        }
        #endregion

        #region 控制马达
        /// <summary>
        /// 控制马达-停止
        /// </summary>
        private RelayCommand _stopCommand;
        public RelayCommand StopCommand
        {
            get
            {
                if (_stopCommand == null)
                {
                    _stopCommand = new RelayCommand(() => MotorStop());
                }
                return _stopCommand;
            }
            set { _stopCommand = value; }
        }

        /// <summary>
        /// 前进
        /// </summary>
        private RelayCommand _advanceCommand;
        public RelayCommand AdvanceCommand
        {
            get
            {
                if (_advanceCommand == null)
                {
                    _advanceCommand = new RelayCommand(() => MotorAdvance());
                }
                return _advanceCommand;
            }
            set { _advanceCommand = value; }
        }

        /// <summary>
        /// 后退
        /// </summary>
        private RelayCommand _recedeCommand;
        public RelayCommand RecedeCommand
        {
            get
            {
                if (_recedeCommand == null)
                {
                    _recedeCommand = new RelayCommand(() => MotorRecede());
                }
                return _recedeCommand;
            }
            set { _recedeCommand = value; }
        }

        /// <summary>
        /// 速度
        /// </summary>
        private RelayCommand _speedCommand;
        public RelayCommand SpeedCommand
        {
            get
            {
                if (_speedCommand == null)
                {
                    _speedCommand = new RelayCommand(() => MotorSpeed());
                }
                return _speedCommand;
            }
            set { _speedCommand = value; }
        }

        #endregion

        #region 电池阀控制 
        private RelayCommand _batteryOpenCLoseCommand;

        public RelayCommand BatteryOpenCLoseCommand
        {
            get
            {
                if (_batteryOpenCLoseCommand == null)
                {
                    _batteryOpenCLoseCommand = new RelayCommand(() => BatteryOpenCLose());
                }
                return _batteryOpenCLoseCommand;
            }
            set { _batteryOpenCLoseCommand = value; }
        }

        #endregion

        #region 滑台控制
        private RelayCommand _slipShutoffCommand;
        public RelayCommand SlipShutoffCommand
        {
            get
            {
                if (_slipShutoffCommand == null)
                {
                    _slipShutoffCommand = new RelayCommand(() => SlipShutoff());
                }
                return _slipShutoffCommand;
            }
            set { _slipShutoffCommand = value; }
        }

        private RelayCommand _slipAdvanceCommand;
        public RelayCommand SlipadvanceCommand
        {
            get
            {
                if (_slipAdvanceCommand == null)
                {
                    _slipAdvanceCommand = new RelayCommand(() => SlipAdvance());
                }
                return _slipAdvanceCommand;
            }
            set { _slipAdvanceCommand = value; }
        }

        private RelayCommand _slipRetreatCommand;
        public RelayCommand SlipRetreatCommand
        {
            get
            {
                if (_slipRetreatCommand == null)
                {
                    _slipRetreatCommand = new RelayCommand(() => SlipRetreat());
                }
                return _slipRetreatCommand;
            }
            set { _slipRetreatCommand = value; }
        }

        #endregion
        #region 舵机
        private RelayCommand _angleCommand;

        public RelayCommand AngleCommamd
        {
            get
            {
                if (_angleCommand == null)
                {
                    _angleCommand = new RelayCommand(() => Angle());
                }
                return _angleCommand;
            }
            set { _angleCommand = value; }
        }

        #endregion
        #region 获取设备当前状态
        private async void Loading()
        {
            await Task.Factory.StartNew(() =>
             {
                 try
                 {
                     var IpAddress = ConfigurationManager.AppSettings["ServerIP"];
                     var Port = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
                    //_socket = new IOSocket(IpAddress, Port);
                    //_socket.Receipt += Socket_Receipt;
                    //_socket.Start();
                    //_socket.SendAsync(new CmdDataPacket { Command = 0x02, Data = new byte[] { 1, 88 }, Size = 2 });
                }
                 catch (Exception ex)
                 {
                     LogUtil.Error(ex.Message);
                 }
             });
        }
        //private void Socket_Receipt(object sender, CmdDataPacket e)
        //{
        //    IOSocket socket = (IOSocket)sender;

        //    var sb = new StringBuilder();
        //    for (int i = 0; i < e.Size; i++)
        //    {
        //        if (i > 0)
        //        {
        //            sb.Append(" ");
        //        }
        //        sb.Append(e.Data[i].ToString("x"));
        //    }
        //    Control.Message += "\t" + e.Command.ToString("x") + ":" + sb.ToString();
        //    ConnectState();
        //}

        /// <summary>
        ///  控制箱连接状态
        /// </summary>
        private void ConnectState()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                //控制箱1
                Control.ControlState1 = Convert.ToInt32(Control.Message.Split()[2].ToString());
                if (Control.ControlState1 == 0)
                {
                    Control.ControlState1Background = System.Windows.Media.Brushes.Gray;
                    Control.ControlState1Foreground = System.Windows.Media.Brushes.LightGray;
                }
                else
                {
                    BrushConverter conv = new BrushConverter();
                    Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                    Control.ControlState1Background = (System.Windows.Media.Brush)bru;
                    Control.ControlState1Foreground = System.Windows.Media.Brushes.White;
                }
                //控制箱2
                Control.ControlState2 = Convert.ToInt32(Control.Message.Split()[3].ToString());
                if (Control.ControlState2 == 0)
                {
                    Control.ControlState2Background = System.Windows.Media.Brushes.Gray;
                    Control.ControlState2Foreground = System.Windows.Media.Brushes.LightGray;
                }
                else
                {
                    BrushConverter conv = new BrushConverter();
                    Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                    Control.ControlState2Background = (System.Windows.Media.Brush)bru;
                    Control.ControlState2Foreground = System.Windows.Media.Brushes.White;
                }
                //控制箱3
                Control.ControlState3 = Convert.ToInt32(Control.Message.Split()[4].ToString());
                if (Control.ControlState3 == 0)
                {
                    Control.ControlState3Background = System.Windows.Media.Brushes.Gray;
                    Control.ControlState3Foreground = System.Windows.Media.Brushes.LightGray;
                }
                else
                {
                    BrushConverter conv = new BrushConverter();
                    Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                    Control.ControlState3Background = (System.Windows.Media.Brush)bru;
                    Control.ControlState3Foreground = System.Windows.Media.Brushes.White;

                }
                //采集箱状态
                Control.CollectingBox = Convert.ToInt32(Control.Message.Split()[5].ToString());
                if (Control.CollectingBox == 0)
                {
                    Control.CollectingBoxBackground = System.Windows.Media.Brushes.Gray;
                    Control.CollectingBoxForeground = System.Windows.Media.Brushes.LightGray;
                }
                else
                {
                    BrushConverter conv = new BrushConverter();
                    Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                    Control.CollectingBoxBackground = (System.Windows.Media.Brush)bru;
                    Control.CollectingBoxForeground = System.Windows.Media.Brushes.White;
                }
                //报警箱状态
                Control.AlarmBox = Convert.ToInt32(Control.Message.Split()[6].ToString());
                if (Control.AlarmBox == 0)
                {
                    Control.AlarmBoxBackground = System.Windows.Media.Brushes.Gray;
                    Control.AlarmBoxForeground = System.Windows.Media.Brushes.LightGray;
                }
                else
                {
                    //BrushConverter conv = new BrushConverter();
                    //System.Drawing.Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as System.Drawing.Brush;
                    //Control.AlarmBoxBackground = (System.Drawing.Brush)bru;
                    //Control.AlarmBoxForeground = System.Windows.Media.Brushes.White;
                }
            }));
        }
        #endregion

        #region 马达控制
        /// <summary>
        /// 马达停止;0表示停止
        /// </summary>
        private void MotorStop()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x4, 0, 0 }, Size = 3 });

            }));
        }
        /// <summary>
        /// 马达前进;1表示前进
        /// </summary>
        private void MotorAdvance()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x4, 1, 0 }, Size = 3 });
            }));
        }
        /// <summary>
        /// 马达后退;2表示后退
        /// </summary>
        private void MotorRecede()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x4, 2, 0 }, Size = 3 });
            }));
        }
        /// <summary>
        /// 马达速度;3表示速度
        /// </summary>
        private void MotorSpeed()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                byte SpeedValue = Convert.ToByte(Control.SpeedValue);
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x4,3, SpeedValue }, Size = 3 });
            }));
        }
        #endregion

        /// <summary>
        /// 电池阀控制 打开/关闭
        /// </summary>
        private void BatteryOpenCLose()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                if (!Control.BatteryChecked)
                    App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x06, 0 }, Size = 2 });
                else
                    App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x06, 1 }, Size = 2 });
            }));
        }

        /// <summary>
        /// 滑台停止
        /// </summary>
        private void SlipShutoff()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x08, 0, 1 }, Size = 3 });
            }));
        }
        /// <summary>
        /// 滑台前进
        /// </summary>
        private void SlipAdvance()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x08, 1, 2 }, Size = 3 });
            }));
        }
        /// <summary>
        /// 滑台后退
        /// </summary>
        private void SlipRetreat()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x08, 2, 3 }, Size = 3 });
            }));
        }

        /// <summary>
        /// 舵机角度
        /// </summary>
        private void Angle()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                byte Angle = Convert.ToByte(Control.AngleValue);
                App._tcp.TcpSendCmd(new CmdDataPacket { Data = new byte[] { 0x0A, Angle, 1 }, Size = 3 });
            }));
        }
    }
}
