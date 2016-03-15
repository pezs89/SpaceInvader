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
            HighScoreModel = getXmlData();
        }

        public List<HighScoreModel> getXmlData()
        {
            string pathString = @"..\..\Resources\Scores.xml";

            try
            {
                if (File.Exists(pathString))
                {
                    XDocument highScoresFromXml = XDocument.Load(pathString);

                    var readData = highScoresFromXml.Descendants("Data");

                    List<HighScoreModel> highScoreElementsList = new List<HighScoreModel>();
                    var dataFromXml = from x in readData select x;

                    foreach (var item in dataFromXml)
                    {
                        highScoreElementsList.Add(new HighScoreModel((string)item.Element("Name"), (string)item.Element("Score")));
                    }
                    return highScoreElementsList;
                } return null;
                
            }
            catch (IOException)
            {
                return null;
            }

        }
    }
}
