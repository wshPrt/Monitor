using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopyDLL
{
    class Program
    {
        private static string ProgressName = "FS.Monitor";
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        [STAThread]
        static void Main(string[] args)
        {
            KillProgress();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
               //重新下载

            }
            else 
            {
                //ClassZip.UnZip(path + "Upgrade" + "\\Upgrade.zip", path);
                 SharpZip.UnpackFiles(path + "Upgrade" + "\\Upgrade.zip", path);

                Process prc = new Process();
                prc.StartInfo = new ProcessStartInfo("FS.Monitor.exe");
                prc.Start();
            }
        }
        private static void KillProgress()
        {
            bool flag = true;
            while (flag)
            {
                Process[] processList = Process.GetProcesses();
                foreach (Process process in processList)
                {
                    if (process.ProcessName.Contains(ProgressName))
                    {
                        process.Kill();
                        Thread.Sleep(1000);
                    }
                    else
                        flag = false;
                }
            }
        }
    }
}
