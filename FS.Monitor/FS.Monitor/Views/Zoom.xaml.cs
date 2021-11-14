using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FS.Monitor.Views
{
    /// <summary>
    /// Zoom.xaml 的交互逻辑
    /// </summary>
    public partial class Zoom : Window
    {
        private System.Drawing.Rectangle rc = Screen.PrimaryScreen.Bounds;
        private NotifyIcon MyNotifyIcon = null;
        private ExitWindow exitWindow;
        public Zoom()
        {
            InitializeComponent();
            this.PreviewKeyDown += Zoom_PreviewKeyDown;
            InitTray();
            InitImage();
            //exitWindow = new ExitWindow(this);
            //exitWindow.Show();
        }

        private void Zoom_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.KeyStates == Keyboard.GetKeyStates(Key.Space))
            {
                Mangnify();
            }
        }
        private void Mangnify()
        {
            InitImage();
            this.Show();
           // exitWindow.Show();
        }
        private void InitImage()
        {
            Bitmap bmp = ShotScreen();
            image.Width = rc.Width;
            image.Height = rc.Height;
            image.Source = BitmapToImagesource(bmp);
        }

        //桌面右下角显示内容
        private void InitTray()
        {
            MyNotifyIcon = new NotifyIcon();
            Uri uri = new Uri(@"\images\Title.ico", UriKind.Relative);
            MyNotifyIcon.Icon = new System.Drawing.Icon(System.Windows.Application.GetResourceStream(uri).Stream);


           // MyNotifyIcon.BalloonTipText = "放大已开始";
            //MyNotifyIcon.Visible = true;
            //MyNotifyIcon.ShowBalloonTip(100);

            Container container = new Container();
            ContextMenuStrip myContextMenuStrip = new ContextMenuStrip(container);
            myContextMenuStrip.Width = 50;
            myContextMenuStrip.ShowCheckMargin = false;
            myContextMenuStrip.Margin = new System.Windows.Forms.Padding(1);

            ToolStripMenuItem m_magnify = new ToolStripMenuItem("放大");
            m_magnify.Click += new EventHandler(m_magnify_Click);
            myContextMenuStrip.Items.Add(m_magnify);

            ToolStripMenuItem m_exit = new ToolStripMenuItem("退出");
            m_exit.Click += new EventHandler(m_exit_Click);
            myContextMenuStrip.Items.Add(m_exit);

            MyNotifyIcon.ContextMenuStrip = myContextMenuStrip;
        }

        private void m_magnify_Click(object sender, EventArgs e)
        {
            Mangnify();
        }
        //退出
        private void m_exit_Click(object sender, EventArgs e)
        {
            MyNotifyIcon.Dispose();
            Process.GetCurrentProcess().Kill();
        }

        private Bitmap ShotScreen()
        {
            Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
            }
            return bmp;
        }

        public static ImageSource BitmapToImagesource(Bitmap bmp)
        {
            if (bmp == null) return null;
            ImageSource m_ImageSource = null;
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            m_ImageSource = (ImageSource)imageSourceConverter.ConvertFrom(stream);
            return m_ImageSource;
        }

        //放大
        private void imageArea_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point rate = new System.Windows.Point(5, 5);
            System.Windows.Point pos = e.MouseDevice.GetPosition(rootLayout);  //相对于outsideGrid 获取鼠标的坐标    
            Rect viewBox = vb.Viewbox;    //这里的Viewbox和前台的一样   这里就是获取前台Viewbox的值  
            double xoffset = 0;  //因为鼠标要让它在矩形(放大镜)的中间  那么我们就要让矩形的左上角重新移动位置    
            double yoffset = 0;

            xoffset = magnifierEllipse.ActualWidth / 2;
            yoffset = magnifierEllipse.ActualHeight / 2;

            viewBox.X = pos.X - xoffset + (magnifierEllipse.ActualWidth - magnifierEllipse.ActualWidth / rate.X) / 2;
            viewBox.Y = pos.Y - yoffset + (magnifierEllipse.ActualHeight - magnifierEllipse.ActualHeight / rate.Y) / 2;
            vb.Viewbox = viewBox;
            Canvas.SetLeft(magnifierCanvas, pos.X - xoffset);  //同理重新定位Canvas magnifierCanvas的坐标    
            Canvas.SetTop(magnifierCanvas, pos.Y - yoffset);
        }
    }
}
