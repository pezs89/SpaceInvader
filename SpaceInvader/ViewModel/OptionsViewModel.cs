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
            optModel = new OptionsModel();
            optModel.optionsXmlDataProvider.getXmlData(optModel);
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
