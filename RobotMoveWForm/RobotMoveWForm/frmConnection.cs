using System;
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
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Input;

namespace RobotMoveWForm
{
    public partial class frmConnection : Form
    {
        private Robot robot;
        private VideoCaptureDevice selectedVideoCaptureDevice;
        private DispatcherTimer dispatcherTimer;

        public frmConnection()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Error management
            if (selectedVideoCaptureDevice == null)
            {
                MessageBox.Show("Cannot launch, please select a valid camera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (robot == null || !robot.Connected)
            {
                MessageBox.Show("Cannot launch, the robot is not connected properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Launch main program
            frmMain window = new frmMain(robot, selectedVideoCaptureDevice);
            window.Show();
            this.Hide();
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Tick += new EventHandler(VerifyRobotConnection);

            //Initialize list of bluetooth devices
            cbxBluetoothDevices.DisplayMember = "Key";
            foreach (COMPortInfo portInfo in COMPortInfo.GetCOMPortsInfo())
            {
                cbxBluetoothDevices.Items.Add(new KeyValuePair<string, string>(portInfo.Description, portInfo.Name));
            }
            //Initialize list of cameras
            FilterInfoCollection VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cbxCameras.DisplayMember = "Key";
            foreach (FilterInfo deviceInfo in VideoCaptureDevices)
            {
                cbxCameras.Items.Add(new KeyValuePair<string, FilterInfo>(deviceInfo.Name, deviceInfo));
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(cbxBluetoothDevices.SelectedItem != null)
            { 
            string COMPort = ((KeyValuePair<string, string>)cbxBluetoothDevices.SelectedItem).Value;
            robot = new Robot(COMPort);
            Task.Run(async () =>
            {
                ConnectToRobot();
            });
            }
            else
            {
                MessageBox.Show("Please choose a device");
            }
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
                MessageBox.Show("Could not connect sucessfully to the robot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Store selected camera
            this.selectedVideoCaptureDevice = new VideoCaptureDevice(((KeyValuePair<string, FilterInfo>)cbxCameras.SelectedItem).Value.MonikerString);
            checkOption();

        }
        private void StopLoadAnimation()
        {
            dispatcherTimer.Stop();
            prbConnection.Value = 0;
        }

        private void VerifyRobotConnection(object sender, EventArgs e)
        {
            DispatcherTimer timer = ((DispatcherTimer)sender);
            // Updating the Label which displays the current second
            if (robot.Connected)
            {
                timer.Stop();
                prbConnection.Value = 100;
                checkOption();
            }
            else
            {
                prbConnection.Value += (int)(100 * timer.Interval.TotalSeconds);
                if (prbConnection.Value >= 100)
                {
                    prbConnection.Value = 0;
                }
            }

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private void checkOption()
        {
            if(cbxCameras.SelectedItem != null & prbConnection.Value == 100)
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }
    }
}
 