using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public  class FileCoordinatesModel: ObservableObject
    {
        public FileCoordinatesModel() 
        {
            ImageList = new ObservableCollection<string>();
        }

        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set 
            {
                _startTime = value;
                RaisePropertyChanged(() => StartTime);
            }
        }

        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set 
            {
                _endTime = value;
                RaisePropertyChanged(() => EndTime);
            }
        }

        /// <summary>
        /// 异常类型
        /// </summary>
        private string _errorType;
        public string ErrorType
        {
            get { return _errorType; }
            set 
            { 
                _errorType = value;
                RaisePropertyChanged(() => ErrorType);
            }
        }

        /// <summary>
        /// 勾选
        /// </summary>
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;RaisePropertyChanged(() => IsSelected);}
        }

        /// <summary>
        /// 序号
        /// </summary>
        private int _serialNumber;
        public int SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; RaisePropertyChanged(() => SerialNumber);}
        }

        /// <summary>
        /// 图片命名
        /// </summary>
        private string _imageName;
        public string ImageName 
        {
            get { return _imageName; }
            set { _imageName = value; RaisePropertyChanged(() => ImageName);}
        }

        /// <summary>
        /// 时间
        /// </summary>
        private string _time;
        public string Time
        {
            get { return _time; }
            set { _time = value;RaisePropertyChanged(() => Time); }
        }

        /// <summary>
        /// 坐标个数
        /// </summary>
        private int _coordinatesCount;
        public int CoordinatesCount
        {
            get { return _coordinatesCount; }
            set { _coordinatesCount = value; RaisePropertyChanged(() => CoordinatesCount);}
        }
        private string[] _strXy;
        public string[] StrXy
        {
            get { return _strXy; }
            set { _strXy = value; RaisePropertyChanged(() => StrXy); }
        }


        /// <summary>
        /// X坐标
        /// </summary>
        private int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; RaisePropertyChanged(() => X);}
        }

        /// <summary>
        /// Y坐标
        /// </summary>
        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; RaisePropertyChanged(() => Y);}
        }

        /// <summary>
        /// 宽度
        /// </summary>
        private int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value;RaisePropertyChanged(() => Width);}
        }

        /// <summary>
        /// 高度
        /// </summary>
        private int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; RaisePropertyChanged(() => Height);}
        }

        private string _location;
        public string Location 
        {
            get { return _location; }
            set { _location = value;RaisePropertyChanged(() => Location);}
        }

        private ObservableCollection<string> _imageList;
        public ObservableCollection<string> ImageList
        {
            get { return _imageList; }
            set { _imageList = value; RaisePropertyChanged(() => ImageList);}
        }


        /// <summary>
        /// 图片地址
        /// </summary>
        private string _rollerSourceLocal;
        public string RollerImageSource
        {
            get { return _rollerSourceLocal; }
            set { _rollerSourceLocal = value; RaisePropertyChanged(() => RollerImageSource); }
        }
       
        public void ImageChangeMethod(DirectoryInfo directoryInfo)
        {
            //切换图片
            var files = directoryInfo.GetFiles("*.bmp");
            //RollerImageSource = files[0].FullName;
            for (int i = 0; i < files.Count(); i++)
            {
                var a = files[i].FullName;
                RollerImageSource = files[i].FullName;
                //RollerImageSource = a;
                ImageList.Add(a);
               
                //var list = new List<String>();
                //list.Add(a);

                //RollerImageSource = list.ToString();
            }
        }
    }
}
