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
        private EnemyObjects enemy;
        private AmmoModel ammo;
        private List<EnemyObjects> deleteFromEnemyList;
        bool gameIsPaused;
        bool gameInSession;
        private int score;

        public bool GameIsPaused
        {
            get
            {
                return gameIsPaused;
            }

            set
            {
                gameIsPaused = value;
            }
        }

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


        public List<EnemyObjects> DeleteFromEnemyList
        {
            get
            {
                return deleteFromEnemyList;
            }

            set
            {
                deleteFromEnemyList = value;
            }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public GamePlayViewModel()
        {
            opt = new OptionsModel();
            opt.optionsXmlDataProvider.getXmlData(Opt);
            ammoList = new List<AmmoModel>();
            enemyList = new List<EnemyObjects>();
            deleteFromEnemyList = new List<EnemyObjects>();
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
                        EnemyList.Remove(EnemyList[i]);
                        AmmoList.Remove(AmmoList[j]);
                        var searchEnemy = canvas.Children.OfType<Rectangle>()
                                .FirstOrDefault(x => x.Tag != null && (Guid)x.Tag == enemyId);
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
