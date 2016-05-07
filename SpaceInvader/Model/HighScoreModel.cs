using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using SpaceInvader.DAL;

namespace SpaceInvader.Model
{
    class HighScoreModel
    {
        public CreditsXmlAccess highScoreAccess { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPoint { get; set; }

        public HighScoreModel()
        {
            highScoreAccess = new CreditsXmlAccess();
        }

        public HighScoreModel(string playerName, string playerPoint)
        {
            PlayerName = playerName;
            PlayerPoint = playerPoint;
        }
    }
}

