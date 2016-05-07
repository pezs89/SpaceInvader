using SpaceInvader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceInvader.DAL
{
    class CreditsXmlAccess
    {
        List<HighScoreModel> highScoreElementsList;
        public List<HighScoreModel> getXmlData()
        {
            string pathString = @"..\..\Resources\Scores.xml";

            try
            {
                if (File.Exists(pathString))
                {
                    XDocument highScoresFromXml = XDocument.Load(pathString);

                    var readData = highScoresFromXml.Descendants("Data");

                    highScoreElementsList = new List<HighScoreModel>();
                    var dataFromXml = from x in readData select x;

                    foreach (var item in dataFromXml)
                    {
                        highScoreElementsList.Add(new HighScoreModel((string)item.Element("Name"), (string)item.Element("Score")));
                    }
                    return highScoreElementsList;
                }
                return null;

            }
            catch (IOException)
            {
                return null;
            }

        }
    }
}
