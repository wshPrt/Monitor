using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public  class VersionInfoModel : ObservableObject
    {
        /// <summary>
        /// 签名
        /// </summary>
        private string _sign;
        public string Sign
        {
            get { return _sign; }
            set { _sign = value;RaisePropertyChanged(() => Sign);}
        }

        /// <summary>
        /// 版本值
        /// </summary>
        private int _versionNumber;
        public int VersionNumber
        {
            get { return _versionNumber; }
            set { _versionNumber = value; RaisePropertyChanged(() => VersionNumber);}
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set { _version = value;RaisePropertyChanged(() => Version);}
        }

    }
}
