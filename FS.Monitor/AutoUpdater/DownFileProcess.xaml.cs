using AutoUpdater.Commom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoUpdater
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DownFileProcess : Window
    {
       
        private string callExeName;
        private string appDir;
        public DownFileProcess()
        {
            InitializeComponent();
        }

        private void W_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.ProgressBar.Visibility = Visibility.Visible;
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
           
            SFTPHelper sftp = new SFTPHelper(UpdateUrl.Update_Url, "22", "test", "ftp&User2021");
            sftp.Connect();
            SFTPHelper.DownloadFtp(UpdateUrl.FileDirectory, UpdateUrl.updateFileDir,UpdateUrl.fileName,UpdateUrl.ftpServerIP,UpdateUrl.ftpPort,UpdateUrl.ftpUserID,UpdateUrl.ftpPassword);
       
            //  var result =  sftp.GetFileList(UpdateUrl.FileDirectory, "*.zip");

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(UpdateUrl.RemoteUpdateUrl);
            //request.Method = WebRequestMethods.Ftp.UploadFile;
            //request.Credentials = new NetworkCredential("test", "ftp&User2021");

            //string url = UpdateUrl.RemoteUpdateUrl + callExeName + "update.zip";
            //var client = new System.Net.WebClient();
            //client.DownloadProgressChanged += (sender, e) =>
            //{
            //    UpdateProcess(e.BytesReceived, e.TotalBytesToReceive);
            //};
            //client.DownloadDataCompleted += (sender, e) =>
            //{
            //    string zipFilePath = System.IO.Path.Combine(updateFileDir, "update.zip");
            //    byte[] data = e.Result;
            //    BinaryWriter writer = new BinaryWriter(new FileStream(zipFilePath, FileMode.OpenOrCreate));
            //    writer.Write(data);
            //    writer.Flush();
            //    writer.Close();

            //    System.Threading.ThreadPool.QueueUserWorkItem((s) =>
            //    {
            //        Action f = () =>
            //        {
            //            txtProcess.Text = "开始更新程序...";

            //        };
            //        this.Dispatcher.Invoke(f);

            //        string tempDir = System.IO.Path.Combine(updateFileDir, "temp");
            //        if (!Directory.Exists(tempDir))
            //        {
            //            Directory.CreateDirectory(tempDir);
            //        }
            //        UnZipFile(zipFilePath, tempDir);

            //        //移动文件
            //        //App
            //        if (Directory.Exists(System.IO.Path.Combine(tempDir, "App")))
            //        {
            //            CopyDirectory(System.IO.Path.Combine(tempDir, "App"), appDir);
            //        }

            //        f = () =>
            //        {
            //            txtProcess.Text = "更新完成!";

            //            try
            //            {
            //                //清空缓存文件夹
            //                string rootUpdateDir = updateFileDir.Substring(0, updateFileDir.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            //                foreach (string p in System.IO.Directory.EnumerateDirectories(rootUpdateDir))
            //                {
            //                    if (!p.ToLower().Equals(updateFileDir.ToLower()))
            //                    {
            //                        System.IO.Directory.Delete(p, true);
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                //MessageBox.Show(ex.Message);
            //            }

            //        };
            //        this.Dispatcher.Invoke(f);

            //        try
            //        {
            //            f = () =>
            //            {
            //                AlertWin alert = new AlertWin("更新完成,是否现在启动软件?") { WindowStartupLocation = WindowStartupLocation.CenterOwner, Owner = this };
            //                alert.Title = "更新完成";
            //                alert.YesBtnEventCallBack += () =>
            //                {
            //                    //启动软件
            //                    string exePath = System.IO.Path.Combine(appDir, callExeName + ".exe");
            //                    var info = new System.Diagnostics.ProcessStartInfo(exePath);
            //                    info.UseShellExecute = true;
            //                    info.WorkingDirectory = appDir;// exePath.Substring(0, exePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            //                    System.Diagnostics.Process.Start(info);
            //                };
            //                alert.Width = 400;
            //                alert.Height = 300;
            //                alert.ShowDialog();

            //                this.Close();
            //            };
            //            this.Dispatcher.Invoke(f);
            //        }
            //        catch (Exception ex)
            //        {
            //            //MessageBox.Show(ex.Message);
            //        }
            //    });

            //};
          //  client.DownloadDataAsync(new Uri(url));
        }

        private static void UnZipFile(string zipFilePath, string targetDir)
        {
            ICCEmbedded.SharpZipLib.Zip.FastZipEvents evt = new ICCEmbedded.SharpZipLib.Zip.FastZipEvents();
            ICCEmbedded.SharpZipLib.Zip.FastZip fz = new ICCEmbedded.SharpZipLib.Zip.FastZip(evt);
            fz.ExtractZip(zipFilePath, targetDir, "");
        }

        public void UpdateProcess(long current, long total)
        {
            string status = (int)((float)current * 100 / (float)total) + "%";
            this.txtProcess.Text = status;
            rectProcess.Width = ((float)current / (float)total) * bProcess.ActualWidth;
        }

        public void CopyDirectory(string sourceDirName, string destDirName)
        {
            try
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                    File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));
                }
                if (destDirName[destDirName.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                    destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;
                string[] files = Directory.GetFiles(sourceDirName);
                foreach (string file in files)
                {
                    File.Copy(file, destDirName + System.IO.Path.GetFileName(file), true);
                    File.SetAttributes(destDirName + System.IO.Path.GetFileName(file), FileAttributes.Normal);
                }
                string[] dirs = Directory.GetDirectories(sourceDirName);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("复制文件错误");
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsCanConnectFtp(string ftpServerFilePath, string ftpUserId, string ftpPwd, out string errorMsg)
        {
            bool flag = true;
            FtpWebResponse ftpResponse = null;
            FtpWebRequest ftpRequest = null;
            errorMsg = string.Empty;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("FTP://" + ftpServerFilePath));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.Timeout = 2 * 1000;//超时时间设置为2秒。
                ftpRequest.Credentials = new NetworkCredential(ftpUserId, ftpPwd);
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            }
            catch (WebException exception)
            {
                ftpResponse = (FtpWebResponse)exception.Response;
                switch (ftpResponse.StatusCode)
                {
                    case FtpStatusCode.ActionNotTakenFileUnavailable:
                        errorMsg = "下载的文件不存在";
                        break;
                    case FtpStatusCode.ActionNotTakenFileUnavailableOrBusy:
                        errorMsg = "下载的文件正在使用,请稍后再试";
                        break;
                    default:
                        errorMsg = "发生未知错误";
                        break;
                }
                flag = false;
            }
            catch
            {
                errorMsg = "网络连接发生错误,请稍后再试";
                flag = true;
            }
            finally
            {
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                }
            }
            return flag;
        }

    }
 }
