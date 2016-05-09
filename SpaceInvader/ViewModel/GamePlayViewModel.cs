using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Shapes;

namespace SpaceInvader.ViewModel
{
    class GamePlayViewModel
    {
        private OptionsModel opt;
        private PlayerSpaceShip playerSpaceShip;
        private List<AmmoModel> ammoList;
        private List<EnemyObjects> enemyList;
        private List<PlayerSpaceShip> playerSpaceShipList;
        private List<AmmoModel> enemyAmmoList;
        private EnemyObjects enemy;
        private AmmoModel ammo;
        bool gameInSession = true;
        private int score;
        public int Counter { get; set; }

        public bool GameInSession
        {
            get
            {
                return gameInSession;
            }

            set
            {
                gameInSession = value;
            }
        }

        public PlayerSpaceShip PlayerSpaceShip
        {
            get
            {
                return playerSpaceShip;
            }

            set
            {
                playerSpaceShip = value;
            }
        }

        public OptionsModel Opt
        {
            get
            {
                return opt;
            }
        }

        public List<AmmoModel> AmmoList
        {
            get
            {
                return ammoList;
            }

            set
            {
                ammoList = value;
            }
        }

        public AmmoModel Ammo
        {
            get
            {
                return ammo;
            }

            set
            {
                ammo = value;
            }
        }

        public EnemyObjects Enemy
        {
            get
            {
                return enemy;
            }

            set
            {
                enemy = value;
            }
        }

        public List<EnemyObjects> EnemyList
        {
            get
            {
                return enemyList;
            }

            set
            {
                enemyList = value;
            }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public List<PlayerSpaceShip> PlayerSpaceShipList
        {
            get
            {
                return playerSpaceShipList;
            }

            set
            {
                playerSpaceShipList = value;
            }
        }

        public List<AmmoModel> EnemyAmmoList
        {
            get
            {
                return enemyAmmoList;
            }

            set
            {
                enemyAmmoList = value;
            }
        }

        public GamePlayViewModel()
        {
            opt = new OptionsModel();
            opt.optionsXmlDataProvider.getXmlData(Opt);
            ammoList = new List<AmmoModel>();
            enemyList = new List<EnemyObjects>();
            playerSpaceShipList = new List<PlayerSpaceShip>();
            enemyAmmoList = new List<AmmoModel>();
            PlayerSpaceShip = new PlayerSpaceShip(100, 100, 20, 20);
            PlayerSpaceShip.TakenDamage = 3;
            playerSpaceShipList.Add(PlayerSpaceShip);
        }
        public void RemoveEnemy(Canvas canvas)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].Area.X == 0)
                {
                    var enemyId = EnemyList[i].ObjectId;
                    EnemyList.Remove(EnemyList[i]);
                    var searchEnemy = canvas.Children.OfType<Rectangle>().FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == enemyId);
                    if (searchEnemy != null)
                    {
                        canvas.Children.Remove(searchEnemy);
                    }
                }
            }
        }

        public void AddEnemy(Canvas canvas)
        {
            Random rnd = new Random();
            Array enemyTypeValues = Enum.GetValues(typeof(Model.EnemyType));
            EnemyType randomEnemyType = (Model.EnemyType)enemyTypeValues.GetValue(rnd.Next(enemyTypeValues.Length));

            Enemy = new EnemyObjects(canvas.ActualWidth, rnd.Next(0, (int)canvas.ActualHeight - 20), 20, 20, randomEnemyType);
            canvas.Children.Add(Enemy.getSpaceShip());
            EnemyList.Add(Enemy);
        }

        public void AddPlayer(Canvas canvas)
        {
            foreach (var item in playerSpaceShipList)
            {
                canvas.Children.Add(item.getSpaceShip());
            }
        }

        public void RemoveBullet(Canvas canvas)
        {
            for (int i = 0; i < AmmoList.Count; i++)
            {
                if (AmmoList[i].Area.X == canvas.ActualWidth)
                {
                    var ammoId = AmmoList[i].ObjectId;
                    AmmoList.Remove(AmmoList[i]);
                    var searchAmmo = canvas.Children.OfType<Ellipse>().FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == ammoId);
                    if (searchAmmo != null)
                    {
                        canvas.Children.Remove(searchAmmo);
                    }
                }
            }
        }

        public void EnemyContactWithPlayer(Canvas canvas)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].Area.IntersectsWith(PlayerSpaceShip.Area))
                {
                    PlayerSpaceShip.TakenDamage -= 1;
                    int takenDmg = PlayerSpaceShip.TakenDamage;
                    if (PlayerSpaceShip.TakenDamage == 0)
                    {
                        gameInSession = false;
                    }
                    else
                    {
                        for (int j = 0; j < PlayerSpaceShipList.Count; j++)
                        {
                            var playerId = PlayerSpaceShipList[i].ObjectId;
                            PlayerSpaceShipList.Remove(PlayerSpaceShipList[i]);
                            var searchPlayer = canvas.Children.OfType<Rectangle>().FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == playerId);
                            if (searchPlayer != null)
                            {
                                canvas.Children.Remove(searchPlayer);
                            }

                        }
                        PlayerSpaceShip = new PlayerSpaceShip(10, canvas.ActualHeight / 2, 20, 20);
                        PlayerSpaceShip.TakenDamage = takenDmg;
                        playerSpaceShipList.Add(PlayerSpaceShip);
                        canvas.Children.Add(PlayerSpaceShip.getSpaceShip());
                        gameInSession = true;


                    }
                }
            }
        }

        public void EnemyAmmoHitPlayerSpaceShip(Canvas canvas)
        {
            for (int i = 0; i < EnemyAmmoList.Count; i++)
            {
                if (EnemyAmmoList[i].Area.IntersectsWith(PlayerSpaceShip.Area))
                {
                    PlayerSpaceShip.TakenDamage -= 1;
                    int takenDmg = PlayerSpaceShip.TakenDamage;

                    var ammoId = EnemyAmmoList[i].ObjectId;
                    AmmoList.Remove(AmmoList[i]);
                    var searchAmmo =
                    canvas.Children.OfType<Ellipse>()
                        .FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == ammoId);
                    if (searchAmmo != null)
                    {
                        canvas.Children.Remove(searchAmmo);
                    }

                    if (PlayerSpaceShip.TakenDamage == 0)
                    {
                        gameInSession = false;
                    }
                    else
                    {
                        for (int j = 0; j < PlayerSpaceShipList.Count; j++)
                        {
                            var playerId = PlayerSpaceShipList[i].ObjectId;
                            PlayerSpaceShipList.Remove(PlayerSpaceShipList[i]);
                            var searchPlayer = canvas.Children.OfType<Rectangle>().FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == playerId);
                            if (searchPlayer != null)
                            {
                                canvas.Children.Remove(searchPlayer);
                            }

                        }
                        PlayerSpaceShip = new PlayerSpaceShip(10, canvas.ActualHeight / 2, 20, 20);
                        PlayerSpaceShip.TakenDamage = takenDmg;
                        playerSpaceShipList.Add(PlayerSpaceShip);
                        canvas.Children.Add(PlayerSpaceShip.getSpaceShip());
                        gameInSession = true;
                    }
                }
            }
        }

        public void AmmoContactWithEnemy(Canvas canvas)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                for (int j = 0; j < AmmoList.Count; j++)
                {
                    if (EnemyList[i].Area.IntersectsWith(AmmoList[j].Area))
                    {
                        var enemyId = EnemyList[i].ObjectId;
                        var ammoId = AmmoList[j].ObjectId;
                        if (EnemyList[i].TypeOfEnemySpaceShip == EnemyType.Easy)
                        {
                            Score += 10;
                        }
                        else if (EnemyList[i].TypeOfEnemySpaceShip == EnemyType.Medium)
                        {
                            Score += 20;
                        }
                        else if (EnemyList[i].TypeOfEnemySpaceShip == EnemyType.Hard)
                        {
                            Score += 30;
                        }

                        EnemyList.Remove(EnemyList[i]);
                        AmmoList.Remove(AmmoList[j]);
                        var searchEnemy = canvas.Children.OfType<Rectangle>()
                                .FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == enemyId);

                        var searchAmmo =
                        canvas.Children.OfType<Ellipse>()
                            .FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == ammoId);
                        if (searchAmmo != null)
                        {
                            canvas.Children.Remove(searchAmmo);
                        }
                        if (searchEnemy != null)
                        {
                            canvas.Children.Remove(searchEnemy);
                        }
                        Counter++;
                    }
                }
            }
        }

        public string SpecKeys(Key inputKey)
        {
            string retVal = "";

            switch (inputKey)
            {
                case Key.Left:
                    retVal = "Left";
                    break;
                case Key.Right:
                    retVal = "Right";
                    break;
                case Key.Up:
                    retVal = "Up";
                    break;
                case Key.Down:
                    retVal = "Down";
                    break;
                case Key.Enter:

                    retVal = "Enter";
                    break;
                case Key.Space:
                    retVal = "Space";
                    break;
                case Key.LeftShift:
                    retVal = "LeftShift";
                    break;
                case Key.RightShift:
                    retVal = "RightShift";
                    break;
                case Key.LeftCtrl:
                    retVal = "LeftCtrl";
                    break;
                case Key.RightCtrl:
                    retVal = "RightCtrl";
                    break;
                case Key.LeftAlt:
                    retVal = "LeftAlt";
                    break;
                case Key.RightAlt:
                    retVal = "RightAlt";
                    break;
                case Key.Tab:
                    retVal = "Tab";
                    break;
                case Key.F1:
                    retVal = "F1";
                    break;
                case Key.F2:
                    retVal = "F2";
                    break;
                case Key.F3:
                    retVal = "F3";
                    break;
                case Key.F4:
                    retVal = "F4";
                    break;
                case Key.F5:
                    retVal = "F5";
                    break;
                case Key.F6:
                    retVal = "F6";
                    break;
                case Key.F7:
                    retVal = "F7";
                    break;
                case Key.F8:
                    retVal = "F8";
                    break;
                case Key.F9:
                    retVal = "F9";
                    break;
                case Key.F10:
                    retVal = "F10";
                    break;
                case Key.F11:
                    retVal = "F11";
                    break;
                case Key.F12:
                    retVal = "F12";
                    break;
                case Key.PageUp:
                    retVal = "PageUp";
                    break;
                case Key.PageDown:
                    retVal = "PageDown";
                    break;
                case Key.Home:
                    retVal = "Home";
                    break;
                case Key.Insert:
                    retVal = "Insert";
                    break;
                case Key.End:
                    retVal = "End";
                    break;
                case Key.Delete:
                    retVal = "Delete";
                    break;
                default:
                    retVal = inputKey.ToString();
                    break;
            }

            return retVal;
        }
    }
}
