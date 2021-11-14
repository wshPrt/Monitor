using FS.Monitor.Model;
using FS.Monitor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace FS.Monitor.Views
{
    /// <summary>
    /// ControlBox.xaml 的交互逻辑
    /// </summary>
    public partial class ControlBox : UserControl
    {
        public ControlBox()
        {
            InitializeComponent();
            //this.DataContext = new ControlBoxViewModel();
            OnState();
        }
        private void OnState()
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                btnControlBox1.Background = System.Windows.Media.Brushes.Gray; //App._control.ControlState1Background;
                btnControlBox1.Foreground = System.Windows.Media.Brushes.LightGray; //App._control.ControlState1Foreground;
                btnControlBox2.Background = System.Windows.Media.Brushes.Gray; //App._control.ControlState2Background;
                btnControlBox2.Foreground = System.Windows.Media.Brushes.LightGray; //App._control.ControlState2Foreground;
                btnControlBox3.Background = System.Windows.Media.Brushes.Gray; //App._control.ControlState3Background;
                btnControlBox3.Foreground = System.Windows.Media.Brushes.LightGray; //App._control.ControlState3Foreground;
                btnCollectingBox.Background = System.Windows.Media.Brushes.Gray; //App._control.CollectingBoxBackground;
                btnCollectingBox.Foreground = System.Windows.Media.Brushes.LightGray; //App._control.CollectingBoxForeground;
                btnAlarmBox.Background = System.Windows.Media.Brushes.Gray;// App._control.AlarmBoxBackground;
                btnAlarmBox.Foreground = System.Windows.Media.Brushes.LightGray; //App._control.AlarmBoxForeground;
                btnAlarm.Background = System.Windows.Media.Brushes.Gray;
                btnAlarm.Foreground = System.Windows.Media.Brushes.LightGray;
            }));
        }

       public static int btnInt = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (btnInt == 0)
            {
                App._control.ControlState1Background = System.Windows.Media.Brushes.Gray;
                App._control.ControlState1Foreground = System.Windows.Media.Brushes.LightGray;
                btnInt = 1;
            }
            else 
            {
                BrushConverter conv = new BrushConverter();
                Brush bru = conv.ConvertFromInvariantString("#FF4ABAD0") as Brush;
                App._control.ControlState1Background = (System.Windows.Media.Brush)bru;
                App._control.ControlState1Foreground = System.Windows.Media.Brushes.White;
                btnInt = 0;
            }
           
        }


    }
}
