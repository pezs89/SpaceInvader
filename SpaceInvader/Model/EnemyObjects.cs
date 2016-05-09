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
    public enum EnemyType
    {
        Easy,
        Medium,
        Hard
    }
    class EnemyObjects : MainObject
    {
        EnemyType typeOfEnemySpaceShip;

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

        public EnemyObjects(double posX, double posY, double width, double height, EnemyType typeOfEnemy) : base(posX, posY, width, height)
        {
            this.typeOfEnemySpaceShip = typeOfEnemy;
        }

        public Rectangle getSpaceShip()
        {
            Rectangle spaceShipRect = new Rectangle();
            spaceShipRect.Tag = ObjectId;
            spaceShipRect.Width = Area.Width;
            spaceShipRect.Height = Area.Height;

            if (TypeOfEnemySpaceShip == EnemyType.Easy)
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"..\..\Resources\EasyEnemy.png", UriKind.Relative));
                spaceShipRect.Fill = imgBrush;
            }
            else if (TypeOfEnemySpaceShip == EnemyType.Medium)
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"..\..\Resources\mediumEnemy.png", UriKind.Relative));
                spaceShipRect.Fill = imgBrush;
            }
            else if (TypeOfEnemySpaceShip == EnemyType.Hard)
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"..\..\Resources\hardenemy.png", UriKind.Relative));
                spaceShipRect.Fill = imgBrush;
            }
            
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

        public void Move(double canvasWidth, double canvasHeight, double speed)
        {
            switch (typeOfEnemySpaceShip)
            {
                case EnemyType.Easy:
                case EnemyType.Medium:
                case EnemyType.Hard:
                    if (Area.X <= 0)
                    {
                        area.X = 0;
                    }
                    else
                    {
                        if (Area.X - 0 < speed)
                        {
                            area.X -= Area.X - 0;
                        }
                        else
                        {
                            area.X -= speed;
                        }
                    }

                    OnPropertyChanged("Area");
                    break;
                default:
                    break;
            }
        }
        public AmmoModel Shoot()
        {
            return new AmmoModel(this.area.X , this.area.Y + 7, 7, 7);
        }

    }
}
