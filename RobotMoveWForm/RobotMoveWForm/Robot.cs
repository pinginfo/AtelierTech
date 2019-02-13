using System;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMoveWForm
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

        public void Disconnect()
        {
            if (_brick != null)
            {
                _brick.Disconnect();
                _connected = false;
            }
        }

        public async Task Initialize()
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
        

        public void Move(int force, uint timeMs)
        {
            if (_connected)
            {
                Task.Run(async () =>
                {
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -force, timeMs, true);
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -force, timeMs, true);
                    _brick.BatchCommand.SendCommandAsync();
                });
            }
        }

        /// <summary>
        /// Turn by specifiying the speed of both motors
        /// </summary>
        public void Turn(int leftMotorSpeed, int rightMotorSpeed)
        {
            if (_connected)
            {
                Task.Run(async () =>
                {
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, leftMotorSpeed, 500, true);
                    _brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, rightMotorSpeed, 500, true);
                    _brick.BatchCommand.SendCommandAsync();
                });
            }
        }
    }
}
