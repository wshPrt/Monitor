using FS.Monitor.Common;
using FS.Monitor.Common.FTP;
using FS.Monitor.Common.MessageDialog;
using FS.Monitor.Common.Scoket;
using FS.Monitor.Common.Scoket.Enums;
using FS.Monitor.Common.Scoket.EventArgs;
using FS.Monitor.Common.Scoket.Models;
using FS.Monitor.Common.Scoket.Utils;
using FS.Monitor.Interface;
using FS.Monitor.Model;
using FS.Monitor.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static FS.Monitor.Common.IniFile.Configuration;

namespace FS.Monitor.ViewModel
{
    public class MaintainViewModel : ViewModelBase
    {
        private string _serverIP = ConfigurationManager.AppSettings["ServerIP"];
        private int _serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
        private string _ftpIP = ConfigurationManager.AppSettings["FtpIP"];
        public static string _strPath = Directory.GetCurrentDirectory() + @"\Ftp";
        public MaintainViewModel()
        {
            DispatcherHelper.Initialize();
            Record = new ErrorRecordModel();
       
            ErrorRecordList = new ObservableCollection<ErrorRecordModel>();
            FlileXyList = new ObservableCollection<FileCoordinatesModel>();
            VersionInfoList = new ObservableCollection<VersionInfoModel>();

            // GetNewestVersion();
            //InitData();
            //StartSocketClient();
            // loginFTP();
            ReadTxt(_strPath + @"\bmp_info.txt");
        }

        #region 全局属性
        //进度条值

        private ObservableCollection<ErrorRecordModel> _errorRecordList;
        public ObservableCollection<ErrorRecordModel> ErrorRecordList
        {
            get { return _errorRecordList; }
            set { _errorRecordList = value; RaisePropertyChanged(() => ErrorRecordList); }
        }

        private ErrorRecordModel _Record;
        public ErrorRecordModel Record
        {
            get { return _Record; }
            set { _Record = value; }
        }

        private FileCoordinatesModel _selectedRow;
        public FileCoordinatesModel SelectedRow
        {
            get { return _selectedRow; }
            set { _selectedRow = value; }
        }

        private FileCoordinatesModel _fileXyModel;
        public FileCoordinatesModel FileXyModel
        {
            get { return _fileXyModel; }
            set { _fileXyModel = value; }
        }

        private ObservableCollection<FileCoordinatesModel> _fileXyList;
        public ObservableCollection<FileCoordinatesModel> FlileXyList
        {
            get { return _fileXyList; }
            set { _fileXyList = value; RaisePropertyChanged(() => FlileXyList); }
        }


        private ObservableCollection<FileCoordinatesModel> _Obs_FileCoordinatesModel;
        public ObservableCollection<FileCoordinatesModel> Obs_FileCoordinatesModel
        {
            get { return _Obs_FileCoordinatesModel; }
            set { _Obs_FileCoordinatesModel = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 选择中
        /// </summary>
        private RelayCommand selectedCommand;
        public RelayCommand SelectedCommand
        {
            get
            {
                if (selectedCommand == null)
                {
                    selectedCommand = new RelayCommand(() => SelectedDown());
                }
                return selectedCommand;
            }
            set { selectedCommand = value; }
        }

        /// <summary>
        /// 获取最新信息
        /// </summary>
        private ObservableCollection<VersionInfoModel> _versionInfoList;
        public ObservableCollection<VersionInfoModel> VersionInfoList
        {
            get { return _versionInfoList; }
            set { _versionInfoList = value; RaisePropertyChanged(() => VersionInfoList); }
        }

        private VersionInfoModel _versionInfo;
        public VersionInfoModel VersionInfo 
        {
            get { return _versionInfo; }
            set { _versionInfo = value; RaisePropertyChanged(() => VersionInfo);}
        }

        /// <summary>
        /// 更新指令
        /// </summary>
        private RelayCommand _startUpdateCommand;
        public RelayCommand StartUpdateCommand
        {
            get
            {
                if (_startUpdateCommand == null)
                {
                    _startUpdateCommand = new RelayCommand(() => FileDown());
                }
                return _startUpdateCommand;
            }
            set { _startUpdateCommand = value; }
        }

        /// <summary>
        /// 进度条值
        /// </summary>
        private int percent = 0;
        public int Percent
        {
            get { return this.percent; }
            set
            {
                this.percent = value;
                RaisePropertyChanged("Percent");
            }
        }

        private bool toClose = false;
        /// <summary>
        /// 是否要关闭窗口
        /// </summary>
        public bool ToClose
        {
            get
            {
                return toClose;
            }
            set
            {
                if (toClose != value)
                {
                    toClose = value;
                    this.RaisePropertyChanged("ToClose");
                }
            }

        }
        #endregion

        private void InitData()
        {
            DirectoryInfo v1 = new DirectoryInfo(_strPath);


            var Record = new ErrorRecordModel()
            {
                Time = DateTime.Now.ToString("yyyyy/MMM/dddd"),
                Camera = 1,
                BeltLocation = "100M处",
                ErrorType = "纵撕"
            };
            var RecordTwo = new ErrorRecordModel()
            {
                Time = DateTime.Now.ToString("yyyyy/MMM/dddd"),
                Camera = 2,
                BeltLocation = "100M处",
                ErrorType = "纵撕"
            };
            var RecordThere = new ErrorRecordModel()
            {
                Time = DateTime.Now.ToString("yyyyy/MMM/dddd"),
                Camera = 3,
                BeltLocation = "100M处",
                ErrorType = "纵撕"
            };
            ErrorRecordList.Add(Record);
            ErrorRecordList.Add(RecordTwo);
            ErrorRecordList.Add(RecordThere);
            Record.ImageChangeMethod(v1);

        }

        //#region 返回消息
        //public event PropertyChangedEventHandler PropertyChanged;

        //private string message;

        //public string Message
        //{
        //    get => this.message;
        //    set
        //    {
        //        this.message = value;
        //        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Message)));
        //    }
        //}
       // #endregion

        #region Socket
        private async void StartSocketClient()
        {
            await Task.Factory.StartNew(() =>
             {
                 try
                 {
                     var IpAddress = ConfigurationManager.AppSettings["ServerIP"];
                     var Port = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
                     //var socket = new IOSocket(IpAddress, Port);
                     //socket.Receipt += Socket_Receipt;
                     //socket.Start();
                     //socket.SendAsync(new SocketDataPacket { Command = 0x04, Data = new byte[] { 1, 88 }, Size = 2 });
                 }
                 catch (Exception ex)
                 {
                     LogUtil.Error(ex.Message);
                 }
             });
        }

        //private void Socket_Receipt(object sender, SocketDataPacket e)
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

        //    Record.Message += "\t" + e.Command.ToString("x") + ":" + sb.ToString();
            
        //}

        /// <summary>
        /// 输出日志
        /// </summary>
        private async void Log(string log)
        {
            await Task.Run(() =>
            {
                LogUtil.Debug(DateTime.Now.ToString("mm:ss.fff") + " " + log + "\r\n\r\n");
            });
        }
        #endregion

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
                             // System.Diagnostics.Process.Start("explorer.exe", path);
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
            //totalFile += dirInfo.GetFiles().Length;//获取全部文件
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

        private void SelectedDown()
        {
            if (SelectedRow != null)
            {
                FileXyModel.Location = SelectedRow.Location;
                //FileXyModel.CoordinatesCount = SelectedRow.CoordinatesCount;
                //if (FileXyModel.CoordinatesCount > 0)
                //{

                //}
            }
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
  
        private Visibility _progressBar = Visibility.Hidden;
        public Visibility ProgressBar
        {
            get { return _progressBar; }
            set { _progressBar = value; RaisePropertyChanged(() => ProgressBar); }
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        private async void FileDown()
        {
            await Task.Run(() =>
             {
                 ProgressBar = Visibility.Visible;
                 int os_type = 2;//系统类型，1:linux，2:win
                 IFilesDownInterface downFile = new IFilesDownInterface();
                 var result = downFile.FilesDownInterf(os_type).Result;
                 if (result == null)
                 {
                     for (Percent = 0; Percent <= 100; Percent++)
                     {
                         Thread.Sleep(50);
                     }
                     LogUtil.Log("成功下载!");
                     LoginViewModel.WriteVersion();
                 }
                 else
                 {
                     MessageDialogManager.ShowDialogAsync(result.msg);
                     MessageBox.Show(result.msg);
                 }
                 ToClose = true;
             });

        }

        #region FTP下载
        private string callExeName;
        public void FileDownClick()
        {
            ProgressBar = Visibility.Visible;
            Process[] processes = Process.GetProcessesByName(this.callExeName);

            if (processes.Length > 0)
            {
                foreach (var p in processes)
                {
                    p.Kill();
                }
            }
            DownloadUpdateFile();
        }
        public void DownloadUpdateFile()
        {

            SFTPHelper sftp = new SFTPHelper(UpdateUrlModel.Update_Url, "22", "test", "ftp&User2021");
            sftp.Connect();
            var strList = sftp.GetFileList(UpdateUrlModel.FileDirectory, "*.");
            SFTPHelper.DownloadFtp(UpdateUrlModel.FileDirectory, UpdateUrlModel.updateFileDir, UpdateUrlModel.fileName, UpdateUrlModel.ftpServerIP, UpdateUrlModel.ftpPort, UpdateUrlModel.ftpUserID, UpdateUrlModel.ftpPassword);
        }
        #endregion

    }
}
