using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

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

        public void RemoveEnemy(Canvas canvas)
        {
            var images = canvas.Children.OfType<EnemyObjects>().ToList();
            foreach (var item in images)
            {
                canvas.Children.Remove(item.getSpaceShip());
            }
        }

        public GamePlayViewModel()
        {
            opt = new OptionsModel();
            opt.optionsXmlDataProvider.getXmlData(Opt);
            ammoList = new List<AmmoModel>();
            enemyList = new List<EnemyObjects>();
            deleteFromEnemyList = new List<EnemyObjects>();
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
