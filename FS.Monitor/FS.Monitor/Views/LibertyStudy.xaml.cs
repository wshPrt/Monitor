using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FS.Monitor.Views
{
    /// <summary>
    /// LibertyStudy.xaml 的交互逻辑
    /// </summary>
    public partial class LibertyStudy : UserControl
    {
        public LibertyStudy()
        {
            InitializeComponent();
            pgLearn.Maximum = 100;
            pgLearn.Minimum = 0;
        }

        private void btnForwardThrough_Click(object sender, RoutedEventArgs e)
        {
            double to = (this.viewer1.ActualHeight - this.image.ActualHeight);
            DoubleAnimation animation = new DoubleAnimation(to, duration: new Duration(TimeSpan.FromSeconds(value: 3)), FillBehavior.HoldEnd);
            animation.Completed += delegate
            {
                this.translate1.Y = to;
            };
            animation.Freeze();
            this.translate1.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void btnZoom_Click(object sender, RoutedEventArgs e)
        {
            Zoom zoom = new Zoom();
            zoom.ShowDialog();
        }

        private void btIsNotHidden_Click(object sender, RoutedEventArgs e)
        {
            ////将背景框的颜色设置为黑色，因为已经将透明度设置为0.4了，所以黑色才会显示为灰色的效果
            //stpBG.Background = Brushes.Black;
            ////设置背景框充满整个屏幕
            //Grid.SetColumnSpan(stpBG, 3);
            //Grid.SetRowSpan(stpBG, 3);
            ////   获得选中行DataGrid
            //ccl.Content = new ScanDialog();
            //cc2.Content = new ScanDialog();
        }
        private void btnReadBack_Click(object sender, RoutedEventArgs e)
        {
            int to = 0;
            DoubleAnimation animation = new DoubleAnimation(to, duration: new Duration(TimeSpan.FromSeconds(value: 3)), FillBehavior.HoldEnd);
            animation.Completed += delegate
            {

                this.translate1.Y = to;
            };
            animation.Freeze();
            this.translate1.BeginAnimation(TranslateTransform.YProperty, animation);
        }
        private void btIsHidden_Click(object sender, RoutedEventArgs e)
        {
            ccl.Content = null;
            cc2.Content = null;
        }
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);
        private void btnStartLearn_Click(object sender, RoutedEventArgs e)
        {
            //UpdateProgressBarDelegate updateProgressBaDelegate = new UpdateProgressBarDelegate(pgLearn.SetValue);
            //for (int i = (int)pgLearn.Minimum; i <= (int)pgLearn.Maximum; i++)
            //{
            //    Dispatcher.Invoke(updateProgressBaDelegate,
            //        DispatcherPriority.Background, 
            //        new object[] 
            //        {
            //            RangeBase.ValueProperty, Convert.ToDouble(i) 
            //        });
            //}
            updateProgress();
            txtLearning.Visibility = Visibility.Hidden;
            spAutonomous.Visibility = Visibility.Visible;
        }
        private void updateProgress() 
        {
            btnStartLearn.Visibility = Visibility.Hidden;
            txtLearning.Visibility = Visibility.Visible;
            double value = 0;
            double total = 100d;//得到循环次数
            while (value < total)
            {
                double jd = Math.Round(((value + 1) * (pgLearn.Maximum / total)), 4);

                pgLearn.Dispatcher.Invoke(new Action<System.Windows.DependencyProperty,object>(pgLearn.SetValue),
                 System.Windows.Threading.DispatcherPriority.Background,
                 ProgressBar.ValueProperty,jd);
                //这里是加数据或费时的操作;挂起50毫秒
                Thread.Sleep(50);
                txtLearn.Text = jd + "﹪";
                value++;
            }
        }

        private void btnAgain_Click(object sender, RoutedEventArgs e)
        {
            spAutonomous.Visibility = Visibility.Hidden;
            updateProgress();
            txtLearning.Visibility = Visibility.Hidden;
            spAutonomous.Visibility = Visibility.Visible;
        }

        private void dgRecord_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
