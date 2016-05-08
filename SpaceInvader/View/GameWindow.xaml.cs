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
using SpaceInvader.ViewModel;
using System.Diagnostics;

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        DispatcherTimer timer;
        GamePlayViewModel gamePlayVM;

        public const double spaceShipSpeed = 10;
        public GameWindow()
        {
            InitializeComponent();
            gamePlayVM = new GamePlayViewModel();
            this.DataContext = gamePlayVM;

            gamePlayVM.PlayerSpaceShip = new Model.PlayerSpaceShip(100, 100, 20, 20);
            GameCanvas.Children.Add(gamePlayVM.PlayerSpaceShip.getSpaceShip());

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < gamePlayVM.AmmoList.Count; i++)
            {
                gamePlayVM.AmmoList[i].Move();
            }
            for (int i = 0; i < gamePlayVM.EnemyList.Count; i++)
            {
                gamePlayVM.EnemyList[i].Move(GameCanvas.ActualWidth,GameCanvas.ActualHeight, 10);
            }

            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                gamePlayVM.GameIsPaused = true;

                if (MessageBox.Show("Do you want to quit?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    gamePlayVM.GameInSession = false;
                }
            }
            else if (gamePlayVM.SpecKeys(e.Key) == gamePlayVM.Opt.MoveLeft)
            {
                gamePlayVM.PlayerSpaceShip.MovementDirection = Model.Direction.LeftMove;
                gamePlayVM.PlayerSpaceShip.KeyMove(spaceShipSpeed, GameCanvas.ActualWidth, GameCanvas.ActualHeight);
            }
            else if (gamePlayVM.SpecKeys(e.Key) == gamePlayVM.Opt.MoveRight)
            {
                gamePlayVM.PlayerSpaceShip.MovementDirection = Model.Direction.RightMove;
                gamePlayVM.PlayerSpaceShip.KeyMove(spaceShipSpeed, GameCanvas.ActualWidth, GameCanvas.ActualHeight);
            }
            else if (gamePlayVM.SpecKeys(e.Key) == gamePlayVM.Opt.MoveUp)
            {
                gamePlayVM.PlayerSpaceShip.MovementDirection = Model.Direction.UpMove;
                gamePlayVM.PlayerSpaceShip.KeyMove(spaceShipSpeed, GameCanvas.ActualWidth, GameCanvas.ActualHeight);
            }
            else if (gamePlayVM.SpecKeys(e.Key) == gamePlayVM.Opt.MoveDown)
            {
                gamePlayVM.PlayerSpaceShip.MovementDirection = Model.Direction.DownMove;
                gamePlayVM.PlayerSpaceShip.KeyMove(spaceShipSpeed, GameCanvas.ActualWidth, GameCanvas.ActualHeight);
            }
            else if (gamePlayVM.SpecKeys(e.Key) == gamePlayVM.Opt.Shoot)
            {
                gamePlayVM.Ammo = gamePlayVM.PlayerSpaceShip.Shoot();
                this.GameCanvas.Children.Add(gamePlayVM.Ammo.getAmmo());
                gamePlayVM.AmmoList.Add(gamePlayVM.Ammo);
            }
            else if (e.Key == Key.Left)
            {
                gamePlayVM.Enemy = new Model.EnemyObjects(GameCanvas.ActualWidth, GameCanvas.ActualHeight / 2, 20, 20, Model.EnemyType.Easy);
                GameCanvas.Children.Add(gamePlayVM.Enemy.getSpaceShip());
                gamePlayVM.EnemyList.Add(gamePlayVM.Enemy);
            }
        }
    }
}

