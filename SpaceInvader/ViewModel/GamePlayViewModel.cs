using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;
using System.Windows.Controls;

namespace SpaceInvader.ViewModel
{
    class GamePlayViewModel
    {
        OptionsModel opt;
        PlayerSpaceShip playerSpaceShip;

        public GamePlayViewModel()
        {
            opt = new OptionsModel();
            opt.optionsXmlDataProvider.getXmlData(opt);
        }
    }
}
