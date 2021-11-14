using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public class FacilityModel: ObservableObject
    {
        /// <summary>
        /// 序号
        /// </summary>
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(() => Id);}
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        private string _facilityName;
        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; RaisePropertyChanged(() => FacilityName);}
        }

        /// <summary>
        /// 编号
        /// </summary>
        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = value; RaisePropertyChanged(() => Number);}
        }

        /// <summary>
        /// IP地址
        /// </summary>
        private string _ipAddress;
        public string IpAddresss
        {
            get { return _ipAddress; }
            set { _ipAddress = value; RaisePropertyChanged(() => IpAddresss);}
        }

        /// <summary>
        /// 端口
        /// </summary>
        private int _port;
        public int Port
        {
            get { return _port; }
            set { _port = value; RaisePropertyChanged(() => Port);}
        }

        /// <summary>
        /// 设备状态
        /// </summary>
        private string _facilityState;
        public string FacilityState
        {
            get { return _facilityState; }
            set { _facilityState = value; RaisePropertyChanged(() => FacilityState);}
        }

        /// <summary>
        /// 所属线路
        /// </summary>
        private string _route;
        public string Route 
        {
            get { return _route; }
            set { _route = value; RaisePropertyChanged(() => Route);}
        }

    }
}
