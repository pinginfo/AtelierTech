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

namespace RobotMove
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Robot robot;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            robot.Move(100, 500);
        }

        private void BtnTurn_Click(object sender, RoutedEventArgs e)
        {
            robot.Turn(45);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            robot.Disconnect();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            robot = new Robot("COM7");
        }
    }
}
