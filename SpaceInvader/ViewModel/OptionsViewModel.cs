using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;
using System.IO;
using System.Xml.Linq;
using System.Windows.Input;

namespace SpaceInvader.ViewModel
{
    class OptionsViewModel
    {
        OptionsModel optModel;
        private string pathString = @"..\..\Resources\OptionsSettings.xml";
        public bool IsChanged = false;


        public OptionsModel OptModel
        {
            get
            {
                return optModel;
            }

            set
            {
                optModel = value;
            }
        }

        public OptionsViewModel()
        {
            optModel = getOptionsXmlData();
        }

        public OptionsModel getOptionsXmlData()
        {
            try
            {
                if (File.Exists(pathString))
                {
                    XDocument optionsXml = XDocument.Load(pathString);

                    var readData = optionsXml.Descendants("option");

                    optModel = new OptionsModel();

                    var xmlData = from x in readData select x;

                    foreach (var item in xmlData)
                    {
                        optModel.MoveDown = (string)item.Element("movedown");
                        optModel.MoveUp = (string)item.Element("moveup");
                        optModel.MoveLeft = (string)item.Element("moveleft");
                        optModel.MoveRight = (string)item.Element("moveright");
                        optModel.Shoot = (string)item.Element("shoot");
                        optModel.Pause = (string)item.Element("pause");
                        optModel.IsKeyboardEnabled = (bool)item.Element("keyboard");
                        optModel.IsMouseEnabled = (bool)item.Element("mouse");
                    }
                    return optModel;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setOptionsXmlData()
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
                        xmlData.Single().Element("movedown").Value = optModel.MoveDown;
                        xmlData.Single().Element("moveup").Value = optModel.MoveUp;
                        xmlData.Single().Element("moveright").Value = optModel.MoveRight;
                        xmlData.Single().Element("moveleft").Value = optModel.MoveLeft;
                        xmlData.Single().Element("shoot").Value = optModel.Shoot;
                        xmlData.Single().Element("pause").Value = optModel.Pause;
                        xmlData.Single().Element("keyboard").Value = optModel.IsKeyboardEnabled.ToString();
                        xmlData.Single().Element("mouse").Value = optModel.IsMouseEnabled.ToString();
                    }
                    optionsXml.Save(pathString);
                }
            }
            catch (IOException ex)
            {
                ex.ToString();
            }
        }

        public bool Check(string inputKey)
        {
            if (!string.IsNullOrEmpty(inputKey))
            {
                if (inputKey == optModel.MoveDown || inputKey == optModel.MoveRight || inputKey == optModel.MoveLeft || inputKey == optModel.Pause || inputKey == optModel.Shoot)
                {
                    return false;
                }
                else if (inputKey == optModel.MoveUp || inputKey == optModel.MoveRight || inputKey == optModel.MoveLeft || inputKey == optModel.Pause || inputKey == optModel.Shoot)
                {
                    return false;
                }
                else if (inputKey == optModel.MoveDown || inputKey == optModel.MoveUp || inputKey == optModel.MoveLeft || inputKey == optModel.Pause || inputKey == optModel.Shoot)
                {
                    return false;
                }
                else if (inputKey == optModel.MoveDown || inputKey == optModel.MoveUp || inputKey == optModel.MoveRight || inputKey == optModel.Pause || inputKey == optModel.Shoot)
                {
                    return false;
                }
                else if (inputKey == optModel.MoveDown || inputKey == optModel.MoveUp || inputKey == optModel.MoveRight || inputKey == optModel.MoveLeft || inputKey == optModel.Shoot)
                {
                    return false;
                }
                else if (inputKey == optModel.MoveDown || inputKey == optModel.MoveUp || inputKey == optModel.MoveRight || inputKey == optModel.Pause || inputKey == optModel.MoveLeft)
                {
                    return false;
                }
                IsChanged = false;
            }
            IsChanged = true;
            return true;
        }
        public string SpecKeys(Key inputKey)
        {
            string retVal = "";

            switch (inputKey)
            {
                case Key.Left:
                    retVal = "Left";
                    break;
                case Key.Right:
                    retVal = "Right";
                    break;
                case Key.Up:
                    retVal = "Up";
                    break;
                case Key.Down:
                    retVal = "Down";
                    break;
                case Key.Enter:
                    retVal = "Enter";
                    break;
                case Key.Space:
                    retVal = "Space";
                    break;
                case Key.LeftShift:
                    retVal = "LeftShift";
                    break;
                case Key.RightShift:
                    retVal = "RightShift";
                    break;
                case Key.LeftCtrl:
                    retVal = "LeftCtrl";
                    break;
                case Key.RightCtrl:
                    retVal = "RightCtrl";
                    break;
                case Key.LeftAlt:
                    retVal = "LeftAlt";
                    break;
                case Key.RightAlt:
                    retVal = "RightAlt";
                    break;
                case Key.Tab:
                    retVal = "Tab";
                    break;
                case Key.F1:
                    retVal = "F1";
                    break;
                case Key.F2:
                    retVal = "F2";
                    break;
                case Key.F3:
                    retVal = "F3";
                    break;
                case Key.F4:
                    retVal = "F4";
                    break;
                case Key.F5:
                    retVal = "F5";
                    break;
                case Key.F6:
                    retVal = "F6";
                    break;
                case Key.F7:
                    retVal = "F7";
                    break;
                case Key.F8:
                    retVal = "F8";
                    break;
                case Key.F9:
                    retVal = "F9";
                    break;
                case Key.F10:
                    retVal = "F10";
                    break;
                case Key.F11:
                    retVal = "F11";
                    break;
                case Key.F12:
                    retVal = "F12";
                    break;
                case Key.PageUp:
                    retVal = "PageUp";
                    break;
                case Key.PageDown:
                    retVal = "PageDown";
                    break;
                case Key.Home:
                    retVal = "Home";
                    break;
                case Key.Insert:
                    retVal = "Insert";
                    break;
                case Key.End:
                    retVal = "End";
                    break;
                case Key.Delete:
                    retVal = "Delete";
                    break;
                default:
                    retVal = inputKey.ToString();
                    break;
            }
            return retVal;
        }
    }
}
