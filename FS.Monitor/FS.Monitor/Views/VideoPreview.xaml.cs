using FS.Monitor.Common;
using FS.Monitor.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FS.Monitor.Views
{
    /// <summary>
    /// VideoPreview.xaml 的交互逻辑
    /// </summary>
    public partial class VideoPreview : UserControl
    {
        private List<VideoInfo> modelList = new List<VideoInfo>();
 
        private int i = 0;
        string url = Urls.RTSP_URL;
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;

        private ImageMagick.MagickImage originalMagickImage; // 图层图像修改前的状态
        public static  RoutedCommand OpenDrawerCommand;
        public VideoPreview()
        {
            InitializeComponent();
          
            //Bitmap bitmap = ImageSourceToBitmap(Image1); // img是前台Image控件
            //originalMagickImage = new ImageMagick.MagickImage(bitmap);
        }

        /// <summary>
        /// 调节色相。在原图的基础上增加/减少百分比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chroma_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // 只调整图像的Hue色相值
            //ImageMagick.Percentage brightness = new ImageMagick.Percentage(100); // 100%表示不改变该属性
            //ImageMagick.Percentage saturation = new ImageMagick.Percentage(100);
            //ImageMagick.Percentage hue = new ImageMagick.Percentage(e.NewValue); // 滑动条范围值0%~200%
            //ImageMagick.MagickImage newImage = new ImageMagick.MagickImage(originalMagickImage); // 相当于深复制
            //newImage.Modulate(brightness, saturation, hue);

            // 重新给Image控件赋值新图像
            //BitmapSource bitmapImage = newImage.ToBitmapSource();
            //bdVideo.Source = imageSource;
        }

        // 工具方法：ImageSource --> Bitmap
        public System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            BitmapSource m = (BitmapSource)imageSource;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
            new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride); bmp.UnlockBits(data);

            return bmp;
        }

        private async void Border_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                if (modelList.Count != 0)
                {
                    url = modelList[i].url;
                }

                Dispatcher.BeginInvoke(new Action(delegate
                {
                    VLCPlayer.VLCPlayer player = new VLCPlayer.VLCPlayer(url);
                   // this.Image1.Children.Add(player);
                }));
            });
        }

        /// <summary>
        /// 对比度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            //txtContrast.Text = Convert.ToString(Contrast.Value.ToString());
            //ApplyFilter(true);

            //int threshold = (int)e.NewValue;
            //Bitmap newBitmap = BitmapHelper.Contrast(Image1, threshold);

            //// 重新给Image控件赋值新图像
            //Image1.DataContext = SystemUtils.ConvertBitmapToBitmapImage(newBitmap);
        }
        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null)
            {
                return;
            }

            if (preview == true)
            {
                //ImageBrush ib = new ImageBrush();
                //ib.ImageSource = previewBitmap.Contrast(Convert.ToInt32(Contrast.Value));
                //bdVideo.Background = ib;
            }
            else
            {
                //resultBitmap = originalBitmap.Contrast(trcThreshold.Value);
            }
        }

        private void Slider_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtValue.Text = p.ToString();
            }
        }

        private void Contrast_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                //var p = slider.Maximum * d;
                var p = Math.Round(slider.Maximum * d);
                txtContrast.Text = p.ToString();
            }
        }

        private void Saturation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtSaturation.Text = p.ToString();
            }
        }

        private void Brightness_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtBrightness.Text = p.ToString();
            }
        }
        
        private void Chroma_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtChroma.Text = p.ToString();
            }
        }

        private void Lamp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtLamp.Text = p.ToString();
            }
        }

        private void Pitch_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var slider = (Slider)sender;
                System.Windows.Point position = e.GetPosition(slider);
                double d = 1.8d / slider.ActualWidth * position.X;
                var p = Math.Round(slider.Maximum * d);
                txtPitch.Text = p.ToString() + "°";
            }
        }
    }
}
