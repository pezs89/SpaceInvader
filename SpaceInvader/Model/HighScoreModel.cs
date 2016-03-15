using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SpaceInvader.Model
{
    class HighScoreModel
    {
        public string PlayerName { get; set; }
        public string PlayerPoint { get; set; }

        public HighScoreModel() { }

        public HighScoreModel(string playerName, string playerPoint)
        {
            PlayerName = playerName;
            PlayerPoint = playerPoint;
        }
    }
}

