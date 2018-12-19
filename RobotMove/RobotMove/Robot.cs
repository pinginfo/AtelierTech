using System;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMove
{
    class Robot : IRobot
    {
        Brick _brick;
        bool _connected = false;

        public bool Connected { get => _connected; }

        /// <summary>
        /// Creates an empty robot instance
        /// </summary>
        public Robot()
        {
            
        }

        /// <summary>
        /// Creates the robot instance and initialize it directly
        /// </summary>
        /// <param name="COMPort">COM Port of the robot bluetooth interface. Ex : "COM5"</param>
        public Robot(string COMPort)
        {
            Initialize(COMPort);
        }

        

        public void Disconnect()
        {
            if (_brick != null)
            {
                _brick.Disconnect();
                _connected = false;
            }
        }

        public void Initialize(string COMPort)
        {
            _brick = new Brick(new BluetoothCommunication(COMPort));
            Task.Run(async () =>
            {
                try
                {
                    await _brick.ConnectAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
                _connected = true;
                Console.WriteLine("Brick connected");
            });
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
