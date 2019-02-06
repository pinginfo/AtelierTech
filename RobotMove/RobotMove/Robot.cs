using System;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMove
{
    public class Robot
    {
        Brick _brick;
        string _COMPort;
        bool _connected;

        public bool Connected { get => _connected; }

        /// <summary>
        /// Creates a basic robot instance
        /// </summary>
        public Robot()
        {
            _connected = false;
        }

        /// <summary>
        /// Creates the robot instance and initialize it directly
        /// </summary>
        /// <param name="COMPort">COM Port of the robot bluetooth interface. Ex : "COM5"</param>
        public Robot(string COMPort) : base()
        {
            _COMPort = COMPort;
        }

        /// <summary>
        /// Disconnect the robot
        /// </summary>
        public void Disconnect()
        {
            if (_brick != null)
            {
                _brick.Disconnect();
                _connected = false;
            }
        }

        /// <summary>
        /// Initialize the bluetooth connection with the objects comport
        /// Changes the connected attribute based on the sucess of the connection
        /// </summary>
        public async Task InitializeConnection()
        {
            _brick = new Brick(new BluetoothCommunication(_COMPort));

            try
            {
                await _brick.ConnectAsync();
                _connected = true;
                Console.WriteLine("Brick connected");
            }
            catch (Exception e)
            {
                _connected = false;
                Console.WriteLine("Brick error");
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        
        /// <summary>
        /// Move at a given speed and time
        /// </summary>
        /// <param name="speed">Between -100 and 100</param>
        /// <param name="timeMs">Time in milliseconds</param>
        public void Move(int speed, uint timeMs)
        {
            if (_connected)
            {
                Task.Run(async () =>
                {
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -speed, timeMs, true);
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -speed, timeMs, true);
                    _brick.BatchCommand.SendCommandAsync();
                });
            }
        }

        /// <summary>
        /// Turn some amount of degrees
        /// </summary>
        /// <param name="degrees"></param>
        public void Turn(int degrees)
        {
            if (_connected)
            {
                int force = 100;
                if (degrees < 0)
                {
                    force = -force;
                }

                Task.Run(async () =>
                {
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -force, 500, true);
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, force, 500, true);
                    _brick.BatchCommand.SendCommandAsync();
                });
            }
        }
    }
}
