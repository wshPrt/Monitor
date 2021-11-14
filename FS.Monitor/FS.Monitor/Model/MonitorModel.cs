using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FS.Monitor.Model
{
   public class MonitorModel: ObservableObject
    {
       public static Random rd = new Random();
        /// <summary>
        /// 序号
        /// </summary>
        private int _id = rd.Next();
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(() => Id);}
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; RaisePropertyChanged(() => ProjectName);}
        }

        /// <summary>
        /// 线路编号
        /// </summary>
        private string _lineNumber;
        public string LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; RaisePropertyChanged(() => LineNumber);}
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        private string _notEnable;
        public string NotEnable
        {
            get 
            { return _notEnable; }
            set { _notEnable = value; RaisePropertyChanged(() => NotEnable); }
        }

        /// <summary>
        /// 启动时间
        /// </summary>
        private string _startTime = DateTime.Now.ToString("yyyy/MMMM/dddd");
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; RaisePropertyChanged(() => StartTime);}
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        private Visibility _visibil;
        public Visibility Visibil
        {
            get { return _visibil; }
            set { _visibil = value; RaisePropertyChanged(() => Visibil);}
        }

    }
}
