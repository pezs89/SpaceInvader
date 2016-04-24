using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SpaceInvader.Model
{
    public enum EnemyType
    {
        Easy, 
        Medium,
        Hard,
        Boss
    }
    class EnemyObjects : MainObject
    {
        EnemyType typeOfEnemySpaceShip;
        protected int takenDamage;
        private double horizontalMovement;
        private double verticalMovement;

        public EnemyType TypeOfEnemySpaceShip
        {
            get
            {
                return typeOfEnemySpaceShip;
            }

            set
            {
                typeOfEnemySpaceShip = value;
            }
        }

        public int TakenDamage
        {
            get
            {
                return takenDamage;
            }

            set
            {
                takenDamage = value;
            }
        }

        public double HorizontalMovement
        {
            get
            {
                return horizontalMovement;
            }

            set
            {
                horizontalMovement = value;
            }
        }

        public double VerticalMovement
        {
            get
            {
                return verticalMovement;
            }

            set
            {
                verticalMovement = value;
            }
        }

        public EnemyObjects(double posX, double posY, double width, double height, double horizontalMovement, double verticalMovement, EnemyType typeOfEnemy) : base(posX, posY, width, height)
        {
            this.horizontalMovement = horizontalMovement;
            this.verticalMovement = verticalMovement;
            this.typeOfEnemySpaceShip = typeOfEnemy;
        }

        public Rectangle getSpaceShip()
        {
            Rectangle spaceShipRect = new Rectangle();
            spaceShipRect.Width = Area.Width;
            spaceShipRect.Height = Area.Height;

            Binding rectangleXBinding = new Binding("Area.X");
            rectangleXBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.LeftProperty, rectangleXBinding);
            
            Binding rectangleYBinding = new Binding("Area.Y");
            rectangleYBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.TopProperty, rectangleYBinding);
            
            Binding rectangleWidthBinding = new Binding("Area.Width");
            rectangleWidthBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.WidthProperty, rectangleWidthBinding);
            
            Binding rectangleHeightBinding = new Binding("Area.Height");
            rectangleHeightBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.HeightProperty, rectangleHeightBinding);

            return spaceShipRect;
        }

        public bool Move(double canvasWidth, double canvasHeight, double speed)
        {
            if (Area.X <= canvasWidth)
            {
                return true;
            }
            else
            {
                area.X += speed;

                OnPropertyChanged("Area");

                return false;
            }
        }

    }
}
