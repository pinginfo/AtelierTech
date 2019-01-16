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
        IRobot robot;
        AnalysePicture analyse;
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideoSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            robot = new Robot("COM7");
            analyse = new AnalysePicture();
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                cbxCameras.Items.Add(VideoCaptureDevice.Name);
            }
            cbxCameras.SelectedIndex = 0;
        }

        private void VideoStart()
        {
            FinalVideoSource = new VideoCaptureDevice(VideoCaptureDevices[cbxCameras.SelectedIndex].MonikerString);
            FinalVideoSource.NewFrame += new NewFrameEventHandler(FinalVideoSource_NewFrame);
            FinalVideoSource.Start();
        }

        /// <summary>
        /// Method for convert bitmap to bitmapImage 
        /// </summary>
        /// <param name="bitmap">picture in Bitmap</param>
        /// <returns>picture in BitmapImage</returns>
        private BitmapImage BitmapToImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private BitmapSource ConvertBitmapToSource(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

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
                imgProcessed.Source = ConvertBitmapToSource(imageAnalysed);//TODO analysed image parameters
                sendDirectionRobot(analyse.getDirectionCase());
            });
        }

        private void sendDirectionRobot(int numberDirection)
        {
            switch (numberDirection)
            {
                case 0:
                    robot.Turn(-45);
                    debug.Content = "robot.Turn(-45)";
                    break;
                case 1:
                    robot.Move(100, 500);
                    debug.Content = "robot.Move(100,500)";
                    break;
                case 2:
                    robot.Turn(45);
                    debug.Content = "robot.Turn(45)";
                    break;
                case 3:
                    robot.Turn(-90);
                    debug.Content = "robot.Turn(-90)";
                    break;
                case 4:
                    robot.Move(0, 500);
                    debug.Content = "robot.Move(0,500)";
                    break;
                case 5:
                    robot.Turn(90);
                    debug.Content = "robot.Turn(90)";
                    break;
                case 6:
                    robot.Turn(-135);
                    debug.Content = "robot.Turn(-135)";
                    break;
                case 7:
                    robot.Move(-100, 500);
                    debug.Content = "robot.Move(-100,500)";
                    break;
                case 8:
                    robot.Turn(135);
                    debug.Content = "robot.Turn(135)";
                    break;
                default:
                    break;
            }
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
