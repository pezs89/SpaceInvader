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
        DispatcherTimer timerOfEnemyAdding;
        DispatcherTimer timerOfEnemyMovement;
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
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

            timerOfEnemyAdding = new DispatcherTimer();
            timerOfEnemyAdding.Interval = new TimeSpan(0, 0, 1);
            timerOfEnemyAdding.Tick += TimerOfEnemyAdding_Tick;
            timerOfEnemyAdding.Start();

            timerOfEnemyMovement = new DispatcherTimer();
            timerOfEnemyMovement.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timerOfEnemyMovement.Tick += TimerOfEnemyMovement_Tick;
            timerOfEnemyMovement.Start();
        }

        private void TimerOfEnemyMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < gamePlayVM.EnemyList.Count; i++)
            {
                gamePlayVM.EnemyList[i].Move(GameCanvas.ActualWidth, GameCanvas.ActualHeight, 10);
            }
            gamePlayVM.RemoveBullet(GameCanvas);
            gamePlayVM.RemoveEnemy(GameCanvas);

            gamePlayVM.AmmoContactWithEnemy(GameCanvas);
            ScoreLabel.Content = gamePlayVM.Score;
        }

        private void TimerOfEnemyAdding_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Array enemyTypeValues = Enum.GetValues(typeof(Model.EnemyType));
            Model.EnemyType randomEnemyType = (Model.EnemyType)enemyTypeValues.GetValue(rnd.Next(enemyTypeValues.Length));

            gamePlayVM.Enemy = new Model.EnemyObjects(GameCanvas.ActualWidth, rnd.Next(0, (int)GameCanvas.ActualHeight - 20), 20, 20, randomEnemyType);
            GameCanvas.Children.Add(gamePlayVM.Enemy.getSpaceShip());
            gamePlayVM.EnemyList.Add(gamePlayVM.Enemy);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < gamePlayVM.AmmoList.Count; i++)
            {
                gamePlayVM.AmmoList[i].Move();
            }


            if (gamePlayVM.Counter == 10)
            {
                timer.Stop();
                timerOfEnemyAdding.Stop();
                timerOfEnemyMovement.Stop();

                EndGameWindow childWindow = new EndGameWindow();
                childWindow.ScoreTextBox.Text = this.ScoreLabel.Content.ToString();
                childWindow.Show();
                this.Close();
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
        }
    }
}

