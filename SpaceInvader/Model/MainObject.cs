using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceInvader.Model
{
    class MainObject : Bindable
    {
        protected Rect area;

        public Rect Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
                OnPropertyChanged("Area");
            }
        }

        public MainObject(double posX, double posY, double width, double height)
        {
            Area = new Rect(posX, posY, width, height);
        }
    }
}
