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

        public void SaveScore(List<HighScoreModel> highscores)
        {
            string pathString = @"..\..\Resources\Scores.xml";
            try
            {
                if (highscores != null && highscores.Count > 0)
                {
                    highscores.Sort((x, y) => int.Parse(y.PlayerPoint).CompareTo(int.Parse(x.PlayerPoint)));

                    XDocument highscoresFromXml = XDocument.Load(pathString);
                    var readDataFromXml = highscoresFromXml.Descendants("Data");

                    var fromXml = from x in readDataFromXml
                                  select x;

                    int i = 0;
                    foreach (var oneItem in fromXml)
                    {
                        oneItem.Element("Name").Value = highscores[i].PlayerName;
                        oneItem.Element("Score").Value = highscores[i].PlayerPoint;

                        i++;
                    }
                    
                    if (highscores.Count > i)
                    {
                        for (int j = i; j < highscores.Count; j++)
                        {
                            XElement nameElement = new XElement("Name", highscores[j].PlayerName);
                            XElement scoreElement = new XElement("Score", highscores[j].PlayerPoint);
                            XAttribute placeAttribute = new XAttribute("ID", (j + 1).ToString());
                            XElement newElements = new XElement("Data", placeAttribute, nameElement, scoreElement);
                            
                            highscoresFromXml.Element("Person").Add(newElements);
                        }
                    }
                    highscoresFromXml.Save(pathString);
                }
            }
            catch
            { }
        }
    }
}
