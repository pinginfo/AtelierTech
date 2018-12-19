using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMove
{
    interface IRobot
    {
        /// <summary>
        /// Turn the robot some degrees clockwise
        /// </summary>
        /// <param name="degrees">Number of degrees (can be negative)</param>
        void Turn(int degrees);

        /// <summary>
        /// Move the robot forward or backward
        /// </summary>
        /// <param name="force">Force or speed wanted</param>
        /// <param name="timeMs">The time to move at that force in ms</param>
        void Move(int force, uint timeMs);

        /// <summary>
        /// Initialize communications with the robot
        /// </summary>
        /// <remarks>
        /// Disconnect function must be called when application closes or the COM Port will freeze.
        /// </remarks>
        /// <param name="COMPort">COM Port of the robot bluetooth interface. Ex : "COM5"</param>
        void Initialize(string COMPort);

        /// <summary>
        /// Disconnects the communications with the robot
        /// </summary>
        void Disconnect();
    }
}
