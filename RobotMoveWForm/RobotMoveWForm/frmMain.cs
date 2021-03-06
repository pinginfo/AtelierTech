﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Add
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
//using Color = System.Windows.Media.Color;

namespace RobotMoveWForm
{
    public partial class frmMain : Form
    {
        private Robot robot;
        private AnalysePicture analyse;
        private VideoCaptureDevice videoCaptureDevice;
        private PictureData pictureData;
        int frameSkipFlag = 0;

        public frmMain(Robot robot, VideoCaptureDevice videoCaptureDevice)
        {
            InitializeComponent();
            this.robot = robot;
            this.videoCaptureDevice = videoCaptureDevice;
        }

        private void MoveRob(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int value = Convert.ToInt32(btn.Tag);
                  sendDirectionRobot(value);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoCaptureDevice.SignalToStop();
            robot.Disconnect();
            videoCaptureDevice.Stop();
            Application.Exit();
        }
        private void sendDirectionRobot(int numberDirection)
        {

            Button[] myArray = new Button[] {btn0,btn1,btn2,btn3, btn4, btn5, btn6, btn7, btn8 };
            int force = 100;
            uint time = 500;
            //0 1 2
            //3 4 5
            //6 7 8

            for (int i = 0; i < myArray.Length; i++)
            {
                changeColor(myArray[i], Color.FromKnownColor(KnownColor.Control));
            }

            switch (numberDirection)
            {
                case 0:
                    robot.Turn(-50, -100);
                    break;
                case 1:
                    robot.Move(force, time);
                    break;
                case 2:
                    robot.Turn(-100, -50);
                    break;
                case 3:
                    robot.Turn(50, -50);
                    break;
                case 5:
                    robot.Turn(-50, 50);
                    break;
                case 6:
                    robot.Turn(50, 100);
                    break;
                case 7:
                    robot.Move(-force, time);
                    break;
                case 8:
                    robot.Turn(100, 50);
                    break;
                default:
                    break;
            }
            changeColor(myArray[numberDirection], Color.Red);
        }
        private void changeColor(Button btn, Color newColor)
        {
            btn.BackColor = newColor;

        }
        private void FinalVideoSource_NewFrame(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap imageAnalysed = null;
            if (frameSkipFlag >= 2)
            {
                pictureData = analyse.getDirection((Bitmap)eventArgs.Frame.Clone());
                imageAnalysed = pictureData.Picture;
                sendDirectionRobot(pictureData.NumberCase);
                frameSkipFlag = 0;
            }

/*            Application.Current.Dispatcher.Invoke(() =>
            {*/
                imgBase.Image = image;
                if (imageAnalysed != null)
                {
                    imgProcessed.Image = imageAnalysed;
                }
          //  });
            frameSkipFlag++;
        }
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

        private void VideoStart()
        {
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(FinalVideoSource_NewFrame);
            videoCaptureDevice.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            analyse = new AnalysePicture();
            VideoStart();
        }
    }
}
