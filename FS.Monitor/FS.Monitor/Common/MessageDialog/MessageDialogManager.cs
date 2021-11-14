using FS.Monitor.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FS.Monitor.Common.MessageDialog
{
    public class MessageDialogManager : BaseWindow
    {
        /// <summary>
        /// 错误提示框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="isModeDialog"></param>
        public  static void ShowDialogAsync(string msg, bool isModeDialog = false)
        {
            MsgBoxView customMessageDialog = new MsgBoxView()
            {
                msg = { Text = msg },
            };

            if (isModeDialog)
            {                
                 customMessageDialog.ShowDialog();
            }
            else 
            {
                customMessageDialog.Show();
            }

        }

    }
}
