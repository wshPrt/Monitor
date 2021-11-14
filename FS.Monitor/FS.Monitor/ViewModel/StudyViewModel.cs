using FS.Monitor.Common.Concover;
using FS.Monitor.Common.FTP;
using FS.Monitor.Common.MessageDialog;
using FS.Monitor.Interface;
using FS.Monitor.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static FS.Monitor.Common.IniFile.Configuration;

namespace FS.Monitor.ViewModel
{
    public class StudyViewModel :ViewModelBase
    {
        private string _serverIP = ConfigurationManager.AppSettings["ServerIP"];
        private int _serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
        private string _ftpIP = ConfigurationManager.AppSettings["FtpIP"];
        public static string _strPath = Directory.GetCurrentDirectory() + @"\Ftp";
        public StudyViewModel() 
        {
               SelectedRow = new FileCoordinatesModel();
               FlileXyList = new ObservableCollection<FileCoordinatesModel>();
            //GetNewestVersion();
            //loginFTP();
            ReadTxt(_strPath + @"\bmp_info.txt");
        }
        #region 属性
        private ObservableCollection<FileCoordinatesModel> _fileXyList;
        public ObservableCollection<FileCoordinatesModel> FlileXyList
        {
            get { return _fileXyList; }
            set { _fileXyList = value; RaisePropertyChanged(() => FlileXyList); }
        }
        public List<FileCoordinatesModel> ListAll = new List<FileCoordinatesModel>();

        private FileCoordinatesModel _fileXyModel;
        public FileCoordinatesModel FileXyModel
        {
            get { return _fileXyModel; }
            set { _fileXyModel = value; }
        }

        private FileCoordinatesModel _selectedRow;
        public FileCoordinatesModel SelectedRow
        {
            get { return _selectedRow; }
            set { _selectedRow = value; RaisePropertyChanged(() => SelectedRow); }
        }

        // 获取最新信息
        private ObservableCollection<VersionInfoModel> _versionInfoList;
        public ObservableCollection<VersionInfoModel> VersionInfoList
        {
            get { return _versionInfoList; }
            set { _versionInfoList = value; RaisePropertyChanged(() => VersionInfoList); }
        }

        private string _errorType= "－";
        public string ErrorType
        {
            get { return _errorType; }
            set 
            {
                _errorType = value;
                RaisePropertyChanged(() => ErrorType);
            }
        }

        private bool isSelectAll = false;
        public bool IsSelectAll
        {
            get { return isSelectAll; }
            set
            {
                isSelectAll = value;
                RaisePropertyChanged(() =>IsSelectAll);
            }
        }

        private RelayCommand _screenCommand;
        public RelayCommand ScreenCommand
        {
            get 
            {
                if (_screenCommand == null)
                {
                    _screenCommand = new RelayCommand(() => Screen());
                }
                return _screenCommand; 
            }
            set { _screenCommand = value; }
        }

        private RelayCommand _tabCommand;
        public RelayCommand TabCommand
        {
            get
            {
                if (_tabCommand ==null)
                {
                    _tabCommand = new RelayCommand(() => Tab());
                }
                return _tabCommand; 
            }
            set 
            {
                _tabCommand = value;
            }
        }

        private RelayCommand _delCommand;
        public RelayCommand DelCommand
        {
            get
            {
                if (_delCommand == null)
                {
                    _delCommand = new RelayCommand(() => Del());
                }
                return _delCommand; 
            }
            set { _delCommand = value;}
        }

        /// <summary>
        /// 选中
        /// </summary>
        private RelayCommand selectCommand;
        public RelayCommand SelectCommand
        {
            get
            {
                return selectCommand ?? (selectCommand = new RelayCommand(() =>
                    {
                        int selectCount = FlileXyList.ToList().Count(p => p.IsSelected == false);
                        if (selectCount.Equals(0))
                        {
                            IsSelectAll = true;
                        }
                    }));
            }
        }
        /// <summary>
        /// 取消选中
        /// </summary>
        private RelayCommand unSelectCommand;
        public RelayCommand UnSelectCommand
        {
            get
            {
                return unSelectCommand ?? (unSelectCommand = new RelayCommand(() =>
                    {
                        IsSelectAll = false;
                    }));
            }
        }

        /// <summary>
        /// 选中全部
        /// </summary>
        private RelayCommand selectAllCommand;
        public RelayCommand SelectAllCommand
        {
            get
            {
                return selectAllCommand ?? (selectAllCommand = new RelayCommand(ExecuteSelectAllCommand, CanExecuteSelectAllCommand));
            }
        }
        private void ExecuteSelectAllCommand()
        {
            if (FlileXyList.Count < 1) return;
            FlileXyList.ToList().FindAll(p => p.IsSelected = true);
        }
        private bool CanExecuteSelectAllCommand()
        {
            if (FlileXyList != null)
            {
                return FlileXyList.Count > 0;
            }
            else
                return false;
        }

        /// <summary>
        /// 取消全部选中
        /// </summary>
        private RelayCommand unSelectAllCommand;

        public RelayCommand UnSelectAllCommand
        {
            get { return unSelectAllCommand ?? (unSelectAllCommand = new RelayCommand(ExecuteUnSelectAllCommand, CanExecuteUnSelectAllCommand)); }
        }
        private void ExecuteUnSelectAllCommand()
        {
            if (FlileXyList.Count < 1)
                return;
            if (FlileXyList.ToList().FindAll(p => p.IsSelected == false).Count != 0)
                IsSelectAll = false;
            else
                FlileXyList.ToList().FindAll(p => p.IsSelected = false);
        }
        private bool CanExecuteUnSelectAllCommand()
        {
            if (FlileXyList != null)
            {
                return FlileXyList.Count > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void Tab()
        {
            if (SelectedRow != null)
            {
                if (IsSelectAll != true)
                {
                    if (SelectedRow.ErrorType != "旧伤")
                    {
                        SelectedRow.ErrorType = "旧伤";
                    }
                    else
                    {
                        if (FlileXyList.ToList().FindAll(p => p.ErrorType == "-").Count != 0)
                            ErrorType = "旧伤";
                        else
                            FlileXyList.ToList().FindAll(p => p.ErrorType == "旧伤");
                           ErrorType = "-";
                    }
                }
                else 
                {
                   
                    FlileXyList.Where(p => p.ErrorType != null && p.ErrorType.Contains(SelectedRow.ErrorType)).ToArray();
                    SelectedRow.ErrorType = "-";
                }
                //if (SelectedRow.ErrorType == "-")
                //{
                //    var selectCount = FlileXyList.Where(p => p.ErrorType != null && p.ErrorType.Contains(SelectedRow.ErrorType)).ToArray();
                //    ErrorType = "旧伤";
                //}
                //else 
                //{
                //     FlileXyList.ToList().FindAll(p => p.ErrorType == "-");
                //    var selectCount = FlileXyList.Where(p => p.ErrorType != null && p.ErrorType.Contains(SelectedRow.ErrorType)).ToArray();
                //    ErrorType = "-";
                //}
            }
            else 
            {
                MessageDialogManager.ShowDialogAsync("未选中!");
            }
        }

        /// <summary>
        /// 筛选
        /// </summary>
        private void Screen()
        {
            DispatcherHelper.CheckBeginInvokeOnUI( async () =>
            {
               // FlileXyList.Clear();
                ListAll.Where(p => p.StartTime.Contains(FileXyModel.Time)).ToList().ForEach(p => 
                {
                    FlileXyList.Add(p);
                });
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        private async void Del() 
        {
           await Task.Run(() =>
           {
               string t = "";
               string[] a = File.ReadAllLines(_strPath + @"\bmp_info.txt", System.Text.Encoding.Default);
               var rowCount = TotalRows(_strPath + @"\bmp_info.txt") - 1 ;
               for (int i = 0; i < rowCount; i++)
               {
                   t = a[i];
                   a[i] = a[i + 1];
                   a[i + 1] = t;
               }
               StreamWriter sw = new StreamWriter(_strPath + @"\bmp_info.txt", false, System.Text.Encoding.Default);
               for (int j = 0; j < rowCount; j++)
               {
                   sw.Write(a[j]);
                   sw.WriteLine();
               }
               sw.Flush();
               sw.Close();

               //ReadTxt(_strPath + @"\bmp_info.txt");
           });
        }

        private int TotalRows(String _fileName) 
        {
            Stopwatch sw = new Stopwatch();
            var path = _fileName;
            int lines = 0;
            //按行读取
            sw.Restart();
            using (var sr = new StreamReader(path))
            {
                var ls = "";
                while ((ls = sr.ReadLine()) != null)
                {
                    lines++;
                }
            }
            sw.Stop();
            return lines;
        }

/// <summary>
/// 获取最新版本
/// </summary>
public async void GetNewestVersion()
        {
            await Task.Run(() =>
            {
                int os_type = 2;//系统类型，1:linux，2:win
                IGetSoftwareVersion getVersion = new IGetSoftwareVersion();
                var reuslt = getVersion.GetSoftwareVersion(os_type).Result;
                string success = reuslt.msg;
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (success == "读取成功")
                    {
                        VersionInfoList.Add(new VersionInfoModel()
                        {
                            Sign = reuslt.data.sign,
                            Version = reuslt.data.version,
                            VersionNumber = reuslt.data.version_number
                        });
                    }
                }));
            });
        }

        #region ftp
        private async void loginFTP()
        {
            await Task.Run(() =>
            {
                try
                {
                    FTPHelper.Address = _ftpIP;
                    FTPHelper.ftpURI = "ftp://" + FTPHelper.Address + "/";
                    //获取ftp上文件名
                    String[] files = FTPHelper.GetFilesDetailList();
                    //删除本地文件
                    string path = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.Path_URL;
                    #region 创建文件名
                    //获取当前文件夹路径
                    string currPath = AppDomain.CurrentDomain.BaseDirectory;
                    //检查是否存在文件夹
                    string subPath = currPath + "/Ftp/";
                    if (false == System.IO.Directory.Exists(subPath))
                    {
                        //创建Ftp文件夹
                        System.IO.Directory.CreateDirectory(subPath);
                    }
                    #endregion
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    int reuslt = GetFilesCount(dirInfo);
                    if (reuslt > 0)
                    {
                        FTPHelper.DelectDir(path);
                        //下载文件到本地
                        for (int i = 0; i < files.Length; i++)
                        {
                            FTPHelper.FtpDownload(files[i], path + files[i], false);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            FTPHelper.FtpDownload(files[i], path + files[i], false);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            });
        }

        /// <summary>
        /// 获取本地文件数量
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        public static int GetFilesCount(DirectoryInfo dirInfo)
        {
            int totalFile = 0;
            totalFile += dirInfo.GetFiles("*.txt").Length;//获取某种格式
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        #endregion

        /// <summary>
        /// 读取bmp_info文本的值
        /// </summary>
        /// <param name="path"></param>
        public void ReadTxt(string path)
        {
            DirectoryInfo v1 = new DirectoryInfo(_strPath);


            StreamReader sr = new StreamReader(path, Encoding.Default);
            string[] strText = File.ReadAllLines(path);
            var RowCount = strText.Length - 1;
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] sArray = line.Split(new char[1] { ';' });
                var strCount = Convert.ToInt32(sArray[2]) - 1;
                for (int i = 0; i <= strCount; i++)
                {
                    FileXyModel = new FileCoordinatesModel();

                    FileXyModel.ImageName = sArray[0];
                    FileXyModel.Time = DateTime.ParseExact(sArray[1], "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.None).ToString("yyyy-MM-dd HH:mm:ss");
                    FileXyModel.CoordinatesCount = Convert.ToInt32(sArray[2]);
                    FileXyModel.StrXy = sArray[i + 3].Split(new char[1] { ',' });
                    FileXyModel.X = Convert.ToInt32(FileXyModel.StrXy[0]);
                    FileXyModel.Y = Convert.ToInt32(FileXyModel.StrXy[1]);
                    FileXyModel.Width = Convert.ToInt32(FileXyModel.StrXy[2]);
                    FileXyModel.Height = Convert.ToInt32(FileXyModel.StrXy[3]);
                    FileXyModel.Location = "X:" + FileXyModel.X.ToString() + "Y" + FileXyModel.Y.ToString() + "宽:" + FileXyModel.Width.ToString() + "高:" + FileXyModel.Height.ToString();
                }
                FlileXyList.Add(FileXyModel);
            }

            FileXyModel.ImageChangeMethod(v1);
        }
    }
}
