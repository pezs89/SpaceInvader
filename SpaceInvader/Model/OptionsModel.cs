using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader.Model
{
    class OptionsModel
    {
        public string MoveLeft { get; set; }
        public string MoveRight { get; set; }
        public string MoveUp { get; set; }
        public string MoveDown { get; set; }

        public string Pause { get; set; }
        public string Shoot { get; set; }

        public bool IsKeyboardEnabled { get; set; }
        public bool IsMouseEnabled { get; set; }

        public OptionsModel() { }

        public OptionsModel(string moveLeft,string moveRight, string moveUp, string moveDown, string pause, string shoot, bool isKeyboardEnabled, bool isMouseEnabled)
        {
            this.MoveLeft = moveLeft;
            this.MoveRight = MoveRight;
            this.MoveUp = moveUp;
            this.MoveDown = MoveDown;
            this.Pause = pause;
            this.Shoot = shoot;
            this.IsKeyboardEnabled = isKeyboardEnabled;
            this.IsMouseEnabled = isMouseEnabled;
        }

    }
}
