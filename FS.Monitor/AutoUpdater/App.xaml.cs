using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoUpdater
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //AutoUpdater.App app = new AutoUpdater.App();
            var resource = Application.LoadComponent(new Uri("../Theme/Style.xaml", UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(resource);
          //  DownFileProcess downUI = new DownFileProcess();
           
        }
     }
}
