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
        private Guid objectID;
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

        public Guid ObjectId
        {
            get { return objectID; }
            set { objectID = value; }
        }

        public MainObject(double posX, double posY, double width, double height)
        {
            Area = new Rect(posX, posY, width, height);
            objectID = Guid.NewGuid();
        }
    }
}
