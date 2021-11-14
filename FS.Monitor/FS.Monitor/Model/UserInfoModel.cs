using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public class UserInfoModel : ObservableObject
    {
        /// <summary>
        /// 序号
        /// </summary>
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value;RaisePropertyChanged(() => Id);}
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName);}
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        private string _userAuthority;
        public string UserAuthority
        {
            get { return _userAuthority; }
            set { _userAuthority = value;RaisePropertyChanged(() => UserAuthority);}
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _passWord;
        public string PassWord
        {
            get { return _passWord; }
            set { _passWord = value;RaisePropertyChanged(() => PassWord);}
        }



    }
}
