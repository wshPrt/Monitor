using FS.Monitor.Model;
using FS.Monitor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static FS.Monitor.Common.Scoket.TcpSocket;

namespace FS.Monitor.Common.Scoket
{
    public class Data
    {
        public RunningViewModel _run = null;
        public Data()
        {
            //App._tcp._Receipt += _tcp_Receipt;
            Control = new ControlModel();
            _run = new RunningViewModel();
        }

        public void _tcp_Receipt(object sender, CmdDataPacket e)
        {
            TcpSocket socket = (TcpSocket)sender;
            var sb = new StringBuilder();
            for (int i = 0; i < e.Size; i++)
            {
                if (i > 0)
                {
                    sb.Append(" ");
                }
                sb.Append(e.Data[i].ToString("x"));
            }

            //  e.Data  55 aa 04 01            
            var cmd = e.Data[3];
            switch (cmd)
            {
                case 0:
                    var Beat = e.Data[4];
                    if (!string.IsNullOrEmpty(Beat.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(Beat.ToString());
                        }));
                    }
                    break;
                case 3:
                        var conen = e.Data[4];
                        if (conen != App._control.ControlState1)
                        {
                            App.Current.Dispatcher.BeginInvoke((Action)(() =>
                            {
                                App._control.ControlState1 = conen;
                                if (App._control.ControlState1 == 0)
                                {
                                    App._control.ControlState1Background = System.Windows.Media.Brushes.Gray;
                                    App._control.ControlState1Foreground = System.Windows.Media.Brushes.LightGray;
                                }
                                else
                                {
                                    BrushConverter conv = new BrushConverter();
                                    Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                                    App._control.ControlState1Background = (System.Windows.Media.Brush)bru;
                                    App._control.ControlState1Foreground = System.Windows.Media.Brushes.White;
                                }
                            }));
                        }
                    break;
                case 04:
                    var motorResult = e.Data[4];
                    if (!string.IsNullOrEmpty(motorResult.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(motorResult.ToString());
                        }));

                    }
                    break;
                case 06:
                    var BatteryValve = e.Data[4];
                    if (!string.IsNullOrEmpty(BatteryValve.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(BatteryValve.ToString());
                        }));
                    }
                    break;
                case 08:
                    var Slip = e.Data[4];
                    if (!string.IsNullOrEmpty(Slip.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(Slip.ToString());
                        }));
                    }
                    break;
                case 0x0A:
                    var Steering = e.Data[4];
                    if (!string.IsNullOrEmpty(Steering.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(Steering.ToString());
                        }));
                    }
                    break;
                case 0x0C:
                    var Alert = e.Data[4];
                    if (!string.IsNullOrEmpty(Alert.ToString()))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Console.WriteLine(Alert.ToString());
                        }));
                    }
                    break;
                case 0x10:
                    var ScanCardInfo = e.Data[4];
                    int distance  = e.Data[5];
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            DataResult.Property_dataMsg += "\r\n" + ScanCardInfo.ToString() + distance.ToString();
                            //Control.Msg += "\r\n" + ScanCardInfo.ToString() + distance.ToString();
                            Console.WriteLine(ScanCardInfo.ToString());

                           // _run.ControlInfo.Msg = Control.Msg;
                        }));
                    break;
                case 0x11:
                    var ScanAccomplishInfo = e.Data[4];
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            Control.Msg += ScanAccomplishInfo.ToString() + "\r\n" + "扫描完成!";
                            Console.WriteLine(ScanAccomplishInfo.ToString());

                            _run.ControlInfo.Msg = Control.Msg;
                        }));
                    break;
            }
        }

        private ControlModel _control;
        public ControlModel Control
        {
            get { return _control; }
            set { _control = value; }
        }

    }
}
