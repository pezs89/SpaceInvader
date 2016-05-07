using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.IO;

namespace SpaceInvader.ViewModel
{
    class HighScoreViewModel
    {
        List<HighScoreModel> highScoreModel;
        HighScoreModel hsModel;

        public List<HighScoreModel> HighScoreModel
        {
            get
            {
                return highScoreModel;
            }

            set
            {
                highScoreModel = value;
            }
        }

        public HighScoreViewModel()
        {
            hsModel = new HighScoreModel();
            HighScoreModel = hsModel.highScoreAccess.getXmlData();
        }
    }
}
