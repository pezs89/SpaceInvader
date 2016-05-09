using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SpaceInvader.Model
{
    class AmmoModel : MainObject
    {
        private const double ammoSpeed = 20;

        public AmmoModel(double posX, double posY, double width, double height) : base(posX, posY, width, height)
        {
        }

        public Ellipse getAmmo()
        {
            Ellipse ammoEllipse = new Ellipse();
            ammoEllipse.Tag = ObjectId;
            ammoEllipse.Width = Area.Width;
            ammoEllipse.Height = Area.Height;

            ammoEllipse.Fill = Brushes.Yellow;
            ammoEllipse.Stroke = Brushes.Black;
            ammoEllipse.StrokeThickness = 1;

            Binding ellipseXBinding = new Binding("Area.X");
            ellipseXBinding.Source = this;
            ammoEllipse.SetBinding(Canvas.LeftProperty, ellipseXBinding);

            Binding ellipseYBinding = new Binding("Area.Y");
            ellipseYBinding.Source = this;
            ammoEllipse.SetBinding(Canvas.TopProperty, ellipseYBinding);

            Binding ellipseWidthBinding = new Binding("Area.Width");
            ellipseWidthBinding.Source = this;
            ammoEllipse.SetBinding(Canvas.WidthProperty, ellipseWidthBinding);
            
            Binding ellipseHeightBinding = new Binding("Area.Height");
            ellipseHeightBinding.Source = this;
            ammoEllipse.SetBinding(Canvas.HeightProperty, ellipseHeightBinding);

            return ammoEllipse;
        }

        public void MoveFromPlayer()
        {
            this.area.X = this.area.X + ammoSpeed;
            OnPropertyChanged("Area");
        }

        public void MoveFromEnemy()
        {
            this.area.X = this.area.X - (ammoSpeed - 5);
            OnPropertyChanged("Area");
        }
    }
}
