using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public class ControlModel:ObservableObject
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(() => Message); }
        }

        /// <summary>
        /// 控制箱1
        /// </summary>
        private int _controlState1;
        public int ControlState1
        {
            get { return _controlState1; }
            set { _controlState1 = value; RaisePropertyChanged(() => ControlState1);}
        }

        /// <summary>
        /// 控制箱2
        /// </summary>
        private int _controlState2;
        public int ControlState2
        {
            get { return _controlState2; }
            set { _controlState2 = value; RaisePropertyChanged(() => ControlState2); }
        }

        /// <summary>
        /// 控制箱3
        /// </summary>
        private int _controlState3;
        public int ControlState3
        {
            get { return _controlState3; }
            set { _controlState3 = value; 
                RaisePropertyChanged(() => ControlState3); }
        }

        /// <summary>
        /// 采集箱状态
        /// </summary>
        private int _collectingBox;
        public int CollectingBox
        {
            get { return _collectingBox; }
            set 
            {
                _collectingBox = value;
                RaisePropertyChanged(() => CollectingBox);
            }
        }

        /// <summary>
        /// 报警箱状态
        /// </summary>
        private int _alarmBox;
        public int AlarmBox
        {
            get { return _alarmBox; }
            set 
            {
                _alarmBox = value;
                RaisePropertyChanged(() => AlarmBox);
            }
        }

        /// <summary>
        /// 速度
        /// </summary>
        private int speed;
        public int Speed 
        {
            get { return speed; }
            set
            {
                speed = value;
                RaisePropertyChanged(() => Speed);
            }
        }


        #region 控制箱1
        private Brush _controlState1Background;
        public Brush ControlState1Background
        {
            get { return _controlState1Background; }
            set
            {
                _controlState1Background = value;
                RaisePropertyChanged(() => ControlState1Background);
            }
        }

        private Brush _controlState1Foreground;
        public Brush ControlState1Foreground
        {
            get { return _controlState1Foreground; }
            set
            {
                _controlState1Foreground = value;
                RaisePropertyChanged(() => ControlState1Foreground);
            }
        }
        #endregion

        #region 控制箱2
        private Brush _controlState2Background;
        public Brush ControlState2Background
        {
            get { return _controlState2Background; }
            set
            {
                _controlState2Background = value;
                RaisePropertyChanged(() => ControlState2Background);
            }
        }

        private Brush _controlState2Foreground;
        public Brush ControlState2Foreground
        {
            get { return _controlState2Foreground; }
            set
            {
                _controlState2Foreground = value;
                RaisePropertyChanged(() => ControlState2Foreground);
            }
        }
        #endregion

        #region 控制箱3
        private Brush _controlState3Background;
        public Brush ControlState3Background
        {
            get { return _controlState3Background; }
            set
            {
                _controlState3Background = value;
                RaisePropertyChanged(() => ControlState3Background);
            }
        }

        private Brush _controlState3Foreground;
        public Brush ControlState3Foreground
        {
            get { return _controlState3Foreground; }
            set
            {
                _controlState3Foreground = value;
                RaisePropertyChanged(() => ControlState3Foreground);
            }
        }
        #endregion

        #region 采集箱状态
        private Brush _collectingBoxBackground;
        public Brush CollectingBoxBackground 
        {
            get { return _collectingBoxBackground; }
            set
            {
                _collectingBoxBackground = value;
                RaisePropertyChanged(() => CollectingBoxBackground);
            }
        }

        private Brush _collectingBoxForeground;
        public Brush CollectingBoxForeground
        {
            get { return _collectingBoxForeground; }
            set
            {
                _collectingBoxForeground = value;
                RaisePropertyChanged(() => CollectingBoxForeground);
            }
        }
        #endregion

        #region 报警箱状态 
        private Brush _alarmBoxBackground;
        public Brush AlarmBoxBackground
        {
            get { return _alarmBoxBackground; }
            set
            {
                _alarmBoxBackground = value;
                RaisePropertyChanged(() => AlarmBoxBackground);
            }
        }
        private Brush _alarmBoxForeground;
        public Brush AlarmBoxForeground
        {
            get { return _alarmBoxForeground; }
            set
            {
                _alarmBoxForeground = value;
                RaisePropertyChanged(() => AlarmBoxForeground);
            }
        }
        #endregion

        #region 电池阀 打开/关闭
        private bool _batteryChecked;
        public bool BatteryChecked 
        {
            get { return _batteryChecked;; }
            set
            {
                _batteryChecked = value;
                RaisePropertyChanged(() => BatteryChecked);
            }
        }
        #endregion

        /// <summary>
        /// 舵机角度值
        /// </summary>
        private int _angleValue;
        public int AngleValue
        {
            get { return _angleValue; }
            set 
            {
                _angleValue = value;
                RaisePropertyChanged(() => AngleValue);
            }
        }

        /// <summary>
        /// 速度值
        /// </summary>
        private int _speedValue;
        public int SpeedValue
        {
            get { return _speedValue; }
            set 
            {
                _speedValue = value;
                RaisePropertyChanged(() => SpeedValue);
            }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                RaisePropertyChanged(() => Msg);
            }
        }


    }
}
