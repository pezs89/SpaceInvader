using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        public PlayerSpaceShip(double posX, double posY, double width, double height) : base(posX, posY, width, height)
        {
        }

        public Rectangle getSpaceShip()
        {
            Rectangle spaceShipRect = new Rectangle();
            spaceShipRect.Width = Area.Width;
            spaceShipRect.Height = Area.Height;

            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(@"..\..\Resources\vipermarkii.png", UriKind.Relative));

            spaceShipRect.Fill = imgBrush;
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
            else if (Direction.DownMove == movementDirection)
            {
                if (Area.Y + Area.Height >= canvasHeight)
                {
                    area.Y = canvasHeight - Area.Height;
                }
                else
                {
                    if (canvasHeight - Area.Y + Area.Height < shipSpeed)
                    {
                        area.Y -= canvasHeight - Area.Y + Area.Height;
                    }
                    else
                    {
                        area.Y += shipSpeed;
                    }
                }
                OnPropertyChanged("Area");
            }
            else if (Direction.UpMove == movementDirection)
            {
                if (Area.Y <= 0)
                {
                    area.Y = 0;
                }
                else
                {
                    if (Area.Y - 0 < shipSpeed)
                    {
                        area.Y -= Area.Y - 0;
                    }
                    else
                    {
                        area.Y -= shipSpeed;
                    }
                }
                OnPropertyChanged("Area");
            }
        }

        public AmmoModel Shoot()
        {
            return new AmmoModel(this.area.X + this.area.Width, this.area.Y + 7, 7, 7);
        }

    }
}
