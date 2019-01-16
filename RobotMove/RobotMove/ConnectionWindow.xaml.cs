using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Threading;
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
using System.Windows.Shapes;
using AForge.Video.DirectShow;
using InTheHand.Net.Sockets;
using System.Management.Instrumentation;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace RobotMove
{
    /// <summary>
    /// Logique d'interaction pour ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        private Robot robot;
        private VideoCaptureDevice selectedVideoCaptureDevice;
        private DispatcherTimer dispatcherTimer;

        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,100);
            dispatcherTimer.Tick += new EventHandler(VerifyRobotConnection);

            //Initialize list of bluetooth devices
            cbxBluetoothDevices.DisplayMemberPath = "Key";
            foreach (COMPortInfo portInfo in COMPortInfo.GetCOMPortsInfo())
            {
                cbxBluetoothDevices.Items.Add(new KeyValuePair<string, string>(portInfo.Description, portInfo.Name));
            }
            //Initialize list of cameras
            FilterInfoCollection VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cbxCameras.DisplayMemberPath = "Key";
            foreach (FilterInfo deviceInfo in VideoCaptureDevices)
            {
                cbxCameras.Items.Add(new KeyValuePair<string, FilterInfo>(deviceInfo.Name, deviceInfo));
            }
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            string COMPort = ((KeyValuePair<string, string>)cbxBluetoothDevices.SelectedItem).Value;
            robot = new Robot(COMPort);
            Task.Run(async () =>
            {
                ConnectToRobot();
            });
        }

        private async void ConnectToRobot()
        {
            dispatcherTimer.Start();
            //Try to connect to selected bluetooth device
            try
            {
                robot.Initialize().Wait();
            }
            catch (Exception error)
            {
                Debug.Print(error.Message);
                MessageBox.Show("Could not conect sucessfully to the robot.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StopLoadAnimation()
        {
            dispatcherTimer.Stop();
            prbConnection.Value = 0;
        }

        private void BtnLaunch_Click(object sender, RoutedEventArgs e)
        {
            //Error management
            if (selectedVideoCaptureDevice == null)
            {
                MessageBox.Show("Cannot launch, please select a valid camera.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (robot == null || !robot.Connected)
            {
                MessageBox.Show("Cannot launch, the robot is not connected properly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Launch main program
            MainWindow window = new MainWindow(robot, selectedVideoCaptureDevice);
            window.Show();
            this.Close();
        }

        private void CbxCameras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Store selected camera
            this.selectedVideoCaptureDevice = new VideoCaptureDevice(((KeyValuePair < string, FilterInfo>)cbxCameras.SelectedItem).Value.MonikerString);
        }

        private void VerifyRobotConnection(object sender, EventArgs e)
        {
            DispatcherTimer timer = ((DispatcherTimer)sender);
            // Updating the Label which displays the current second
            if (robot.Connected)
            {
                timer.Stop();
                prbConnection.Value = 100;
            }
            else
            {
                prbConnection.Value += 100 * timer.Interval.TotalSeconds;
                if(prbConnection.Value > 100)
                {
                    prbConnection.Value = 0;
                }
            }

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
