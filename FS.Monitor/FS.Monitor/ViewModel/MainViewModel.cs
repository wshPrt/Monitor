using FS.Monitor.Common.Base;
using GalaSoft.MvvmLight;
using System;
using System.Windows;

namespace FS.Monitor.ViewModel
{
   
    public class MainViewModel : NotifyPropertyBase
    {

        private UIElement _mainContent;

        public UIElement MainContent
        {
            get { return _mainContent; }
            set
            {
                Set<UIElement>(ref _mainContent, value);
            }
        }

        public CommandBase TabChangedCommand { get; set; }

        public MainViewModel()
        {
            TabChangedCommand = new CommandBase(OnTabChanged);

            OnTabChanged("FS.Monitor.Views.VideoPreview");
        }

        private void OnTabChanged(object obj)
        {
            if (obj == null) return;
            // 完整方式
            //string[] strValues = o.ToString().Split('|');
            //Assembly assembly = Assembly.LoadFrom(strValues[0]);
            //Type type = assembly.GetType(strValues[1]);
            //this.MainContent = (UIElement)Activator.CreateInstance(type);

            // 简化方式，必须在同一个程序集下
            Type type = Type.GetType(obj.ToString());
            this.MainContent = (UIElement)Activator.CreateInstance(type);
        }
    }
}