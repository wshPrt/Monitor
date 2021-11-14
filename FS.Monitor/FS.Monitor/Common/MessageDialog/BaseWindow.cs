using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FS.Monitor.Common.MessageDialog
{
    public partial class BaseWindow : Window
    {
        public BaseWindow() : base()
        {
            this.Closed += Window_Closed;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.ResizeMode = ResizeMode.NoResize;
        }
        public void SyncComplete()
        {
            this.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(this, "操作完成！", "提示");
            });
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            //容器Grid
            Grid grid = this.Owner.Content as Grid;
            //父级窗体原来的内容
            UIElement original = VisualTreeHelper.GetChild(grid, 0) as UIElement;
            //将父级窗体原来的内容在容器Grid中移除
            grid.Children.Remove(original);
            //赋给父级窗体
            this.Owner.Content = original;
        }
        public bool? ShowDialog(Window owner)
        {
            //蒙板
            Grid layer = new Grid() { Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)) };
            //父级窗体原来的内容
            UIElement original = owner.Content as UIElement;
            owner.Content = null;
            //容器Grid
            Grid container = new Grid();
            container.Children.Add(original);//放入原来的内容
            container.Children.Add(layer);//在上面放一层蒙板
                                          //将装有原来内容和蒙板的容器赋给父级窗体
            owner.Content = container;
            this.Owner = owner;
            return this.ShowDialog();
        }
    }
}
