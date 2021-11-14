using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FS.Monitor.Common.IniFile.Configuration;

namespace FS.Monitor.Views
{
    /// <summary>
    /// QueryMaintain.xaml 的交互逻辑
    /// </summary>
    public partial class QueryMaintain : UserControl
    {
        public QueryMaintain()
        {
            InitializeComponent();
            this.Loaded += QueryMaintain_Loaded;
            
        }

        string path = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.Path_URL;
        private void QueryMaintain_Loaded(object sender, RoutedEventArgs e)
        {
            //using (FileStream ms = new FileStream(path, FileMode.Open, FileMode.Open, FileAccess.Read))
            //{
            //    BitmapImage bi = new BitmapImage();
            //    bi.BeginInit();
            //    bi.CacheOption = BitmapCacheOption.OnLoad;
            //    bi.StreamSource = ms;
            //    bi.EndInit();
            //    bi.Freeze();
            //    image.Source = bi;
            //}
        }

        private void btnZoom_Click(object sender, RoutedEventArgs e)
        {
            Zoom zoom = new Zoom();
            zoom.ShowDialog();
        }
        //DoubleAnimation da = new DoubleAnimation();
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

            //da.From = 0;
            //da.To = 100;
            //Storyboard board = new Storyboard();
            //Storyboard.SetTarget(da, image);
            //Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.BottomProperty));
            //board.Children.Add(da);
            //board.Begin();
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



            //da.From = 0;
            //da.To = 100;
            //Storyboard board = new Storyboard();
            //Storyboard.SetTarget(da, image);
            //Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.TopProperty));
            //board.Children.Add(da);
            //board.Begin();
        }

        private void btIsNotHidden_Click(object sender, RoutedEventArgs e)
        {
            //将背景框的颜色设置为黑色，因为已经将透明度设置为0.4了，所以黑色才会显示为灰色的效果
            stpBG.Background = Brushes.Black;

            //设置背景框充满整个屏幕
            Grid.SetColumnSpan(stpBG, 3);
            Grid.SetRowSpan(stpBG, 3);
            //   获得选中行DataGrid
            //DataGrid dg =(DataGrid)this.dgRecord.SelectedItem;
            //int count = ((FS.Monitor.Model.FileCoordinatesModel)dgRecord.SelectedItem).CoordinatesCount;
            //for (int i = 0; i < count; i++)
            //{
            //    ccl.Content = new ScanDialog();
            //}
            //添加内容
            ccl.Content = new ScanDialog();
            cc2.Content = new ScanDialog();
        }

        private void btIsHidden_Click(object sender, RoutedEventArgs e)
        {
            ccl.Content = null;
            cc2.Content = null;
        }
    }
}
