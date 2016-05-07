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
    public enum Direction
    {
        LeftMove, RightMove, UpMove, DownMove
    }
    class PlayerSpaceShip : MainObject
    {
        protected int takenDamage;
        private double horizontalMovement;
        private double verticalMovement;
        Direction movementDirection;

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

        public Direction MovementDirection
        {
            get
            {
                return movementDirection;
            }

            set
            {
                movementDirection = value;
            }
        }

        public PlayerSpaceShip(double posX, double posY, double width, double height, double horizontalMovement, double verticalMovement) : base(posX, posY, width, height)
        {
            this.horizontalMovement = horizontalMovement;
            this.verticalMovement = verticalMovement;
        }

        public Rectangle getSpaceShip()
        {
            Rectangle spaceShipRect = new Rectangle();
            spaceShipRect.Width = Area.Width;
            spaceShipRect.Height = Area.Height;

            spaceShipRect.Fill = Brushes.Blue;

            Binding rectangleXBinding = new Binding("Area.X");
            rectangleXBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.LeftProperty, rectangleXBinding);

            // Bind the Y position of the brick rectangle to the canvas.
            Binding rectangleYBinding = new Binding("Area.Y");
            rectangleYBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.TopProperty, rectangleYBinding);

            // Bind the width of the brick rectangle to the canvas.
            Binding rectangleWidthBinding = new Binding("Area.Width");
            rectangleWidthBinding.Source = this;
            spaceShipRect.SetBinding(Canvas.WidthProperty, rectangleWidthBinding);

            // Bind the height of the brick rectangle to the canvas.
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

        public void KeyMove(double shipSpeed, double canvasWidth, double canvasHeight)
        {
            if (Direction.LeftMove == movementDirection)
            {
                if (Area.X <= 0)
                {
                    area.X = 0;
                }
                else
                {
                    if (Area.X - 0 < shipSpeed)
                    {
                        area.X -= Area.X - 0;
                    }
                    else
                    {
                        area.X -= shipSpeed;
                    }
                }

                OnPropertyChanged("Area");
            }
            else if (Direction.RightMove == movementDirection)
            {
                if (Area.X + Area.Width >= canvasWidth)
                {
                    area.X = canvasWidth - Area.Width;
                }
                else
                {
                    if (canvasWidth - Area.X + Area.Width < shipSpeed)
                    {
                        area.X -= canvasWidth - Area.X + Area.Width;
                    }
                    else
                    {
                        area.X += shipSpeed;
                    }
                }
                OnPropertyChanged("Area");
            }
        }

    }
}
