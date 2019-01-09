using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Get connected bluetooth devices
            BluetoothDeviceInfo[] devices;
            Bluetooth
            using (BluetoothClient sdp = new BluetoothClient())
            {
                devices = sdp.DiscoverDevices();
            }
            //Initialize list of bluetooth devices
            cbxBluetoothDevices.DisplayMemberPath = "Key";
            foreach (BluetoothDeviceInfo deviceInfo in devices)
            {
                cbxBluetoothDevices.Items.Add(new KeyValuePair<string, BluetoothDeviceInfo>(deviceInfo.DeviceName, deviceInfo));
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
            //Try to connect to selected bluetooth device
            try
            {
                string bluetoothAddress = ((KeyValuePair < string, BluetoothDeviceInfo>)cbxBluetoothDevices.SelectedItem).Value.DeviceAddress.ToString();
                robot = new Robot(bluetoothAddress);
                
            }
            catch (Exception error)
            {
                Debug.Print(error.Message);
                MessageBox.Show("Could not conect sucessfully to the robot.","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        /// <summary>
        /// Compile an array of COM port names associated with given VID and PID
        /// </summary>
        /// <param name="VID">string representing the vendor id of the USB/Serial convertor</param>
        /// <param name="PID">string representing the product id of the USB/Serial convertor</param>
        /// <returns></returns>
        private List<string> getPortByVPid(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
    }
}
