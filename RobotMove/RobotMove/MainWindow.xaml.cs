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
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
//using System.Windows.Media.Imaging.BitmapImage;

namespace RobotMove
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Robot robot;
        private AnalysePicture analyse;
        private VideoCaptureDevice videoCaptureDevice;

        public MainWindow(Robot robot, VideoCaptureDevice videoCaptureDevice)
        {
            InitializeComponent();
            this.robot = robot;
            this.videoCaptureDevice = videoCaptureDevice;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            analyse = new AnalysePicture();
            VideoStart();
        }

        private void VideoStart()
        {
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(FinalVideoSource_NewFrame);
            videoCaptureDevice.Start();
        }

        /// <summary>
        /// Converts a Bitmap object to a BitmapSource object (format 24RGB)
        /// </summary>
        private BitmapSource ConvertBitmapToSource(Bitmap bitmap)
        {
            //Get data from image
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Convert image to source using data
            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        private void FinalVideoSource_NewFrame(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap imageAnalysed = analyse.getDirection((Bitmap)eventArgs.Frame.Clone()).picture;
            Application.Current.Dispatcher.Invoke(() =>
            {
                imgBase.Source = ConvertBitmapToSource(image);
                imgProcessed.Source = ConvertBitmapToSource(imageAnalysed);
            });
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            robot.Move(100, 500);
            VideoStart();
        }

        private void BtnTurn_Click(object sender, RoutedEventArgs e)
        {
            robot.Turn(45);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            robot.Disconnect();
        }
    }
}
