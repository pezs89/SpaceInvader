using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SpaceInvader.Model;

namespace SpaceInvader.DAL
{
    class OptionsXmlAccess
    {
        private string pathString = @"..\..\Resources\OptionsSettings.xml";

        public void getXmlData(OptionsModel opt)
        {
            try
            {
                if (File.Exists(pathString))
                {
                    XDocument optionsXml = XDocument.Load(pathString);

                    var readData = optionsXml.Descendants("option");

                    var xmlData = from x in readData select x;

                    foreach (var item in xmlData)
                    {
                        opt.MoveDown = (string)item.Element("movedown");
                        opt.MoveUp = (string)item.Element("moveup");
                        opt.MoveLeft = (string)item.Element("moveleft");
                        opt.MoveRight = (string)item.Element("moveright");
                        opt.Shoot = (string)item.Element("shoot");
                        opt.Pause = (string)item.Element("pause");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }

        public void setOptions(OptionsModel opt)
        {
            try
            {
                if (File.Exists(pathString))
                {
                    XDocument optionsXml = XDocument.Load(pathString);

                    var readData = optionsXml.Descendants("option");

                    var xmlData = from x in readData select x;

                    foreach (var item in xmlData)
                    {
                        xmlData.Single().Element("movedown").Value = opt.MoveDown;
                        xmlData.Single().Element("moveup").Value = opt.MoveUp;
                        xmlData.Single().Element("moveright").Value = opt.MoveRight;
                        xmlData.Single().Element("moveleft").Value = opt.MoveLeft;
                        xmlData.Single().Element("shoot").Value = opt.Shoot;
                        xmlData.Single().Element("pause").Value = opt.Pause;
                    }
                    optionsXml.Save(pathString);
                }
            }
            catch (IOException ex)
            {
                ex.ToString();
            }
        }
    }
}
