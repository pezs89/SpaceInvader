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
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceInvader.Model;

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        DispatcherTimer timer;
        PlayerSpaceShip ship;
        public GameWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Timer_Tick;
            ship = new PlayerSpaceShip(20, GameCanvas.ActualHeight / 2, 10, 10, 5, 5);
            GameCanvas.Children.Add(ship.getSpaceShip());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Start();
            ship.Move(GameCanvas.ActualWidth, GameCanvas.ActualHeight, 10);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
            {
                this.ship.Move(20, GameCanvas.ActualHeight - 5, 5);
            }
        }
    }
}
