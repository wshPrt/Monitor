using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FS.Monitor.Model
{
   public class ErrorRecordModel:ObservableObject
    {
        /// <summary>
        /// 时间
        /// </summary>
        private string _time;
        public string Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChanged(() => Time);}
        }

        /// <summary>
        /// 相机
        /// </summary>
        private int _camera;
        public int Camera
        {
            get { return _camera; }
            set { _camera = value; RaisePropertyChanged(() => Camera);}
        }

        /// <summary>
        /// 皮带位置
        /// </summary>
        private string _beltLocation;
        public string BeltLocation
        {
            get { return _beltLocation; }
            set { _beltLocation = value; RaisePropertyChanged(() => BeltLocation);}
        }

        /// <summary>
        /// 异常类型
        /// </summary>
        private string _errorType;
        public string ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; RaisePropertyChanged(() => ErrorType); }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        private string _rollerSourceLocal;
        public string RollerImageSource
        {
            get { return _rollerSourceLocal; }
            set { _rollerSourceLocal = value; RaisePropertyChanged(() => RollerImageSource);}
        }
        public void ImageChangeMethod(DirectoryInfo directoryInfo)
        {
            //切换图片
            var files = directoryInfo.GetFiles("*.bmp");
            RollerImageSource = files[0].FullName;
            //for (int i = 0; i < files.Count(); i++)
            //{
            //    var a = files[i].FullName;
            //    //RollerImageSource = a;
            //    var list = new List<String>();
            //    list.Add(a);

            //    RollerImageSource = list.ToString();
            //}

            // CombineBitmap(files);
            //var er = System.IO.Directory.GetCurrentDirectory() + @"\Ftp\";
            //var path = System.IO.Directory.GetFiles(er + "*.bmp");
            // colorBitmap(path);
            // CombineBitmap(path);
            //Task.Run(() =>
            //{
            //    var count = 0;
            //    while (true)
            //    {
            //        try
            //        {
            //            RollerImageSource = files[count].FullName;
            //        }
            //        catch (Exception ex)
            //        {

            //            Console.WriteLine(ex.ToString());
            //        }
            //        Thread.Sleep(295);
            //        count++;
            //        if (count >= files.Count()) count = 0;
            //    }
            //});
        }
        public BitmapImage colorBitmap(string path)
        {
            BitmapImage bitmapImage;
            bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = System.IO.File.OpenRead(path);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        Bitmap GetBitmap(byte[] buf)
        {
            Int16 width = BitConverter.ToInt16(buf, 18);
            Int16 height = BitConverter.ToInt16(buf, 22);

            Bitmap bitmap = new Bitmap(width, height);

            int imageSize = width * height * 4;
            int headerSize = BitConverter.ToInt16(buf, 10);

            System.Diagnostics.Debug.Assert(imageSize == buf.Length - headerSize);

            int offset = headerSize;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, height - y - 1, Color.FromArgb(buf[offset + 3], buf[offset], buf[offset + 1], buf[offset + 2]));
                    offset += 4;
                }
            }
            return bitmap;
        }
        public static System.Drawing.Bitmap CombineBitmap(string[] files)
        {
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                finalImage = new System.Drawing.Bitmap(width, height);

                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    g.Clear(System.Drawing.Color.Black);

                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception)
            {
                if (finalImage != null)
                    finalImage.Dispose();
                throw;
            }
            finally
            {
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
        /// <summary>
        /// 心跳包回复数据
        /// </summary>
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(() => Message);}
        }


    }
}
