using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Model;

namespace SpaceInvader.View
{
    class EndGameViewModel
    {
        List<HighScoreModel> highScoreModel;
        HighScoreModel hsModel;
        private const int highScoreLimit = 100;
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

        public EndGameViewModel()
        {
            hsModel = new HighScoreModel();
            highScoreModel = hsModel.highScoreAccess.getXmlData();
        }

        public bool CheckScore(int playerScore)
        {
            highScoreModel.Sort((x, y) => int.Parse(y.PlayerPoint).CompareTo(int.Parse(x.PlayerPoint)));
            bool returnValue = false;

            for (int i = 0; i < highScoreModel.Count; i++)
            {
                if (int.Parse(highScoreModel[i].PlayerPoint) < playerScore)
                {
                    if (!returnValue)
                    {
                        returnValue = true;
                        break;
                    }
                }
            }

            return returnValue;
        }

        public void SaveScore(string playerName, int playerScore)
        {
            highScoreModel.Add(new HighScoreModel(playerName, playerScore.ToString()));
            highScoreModel.Sort((x, y) => int.Parse(y.PlayerPoint).CompareTo(int.Parse(x.PlayerPoint)));

            if (highScoreModel.Count >= highScoreLimit)
            {
                int i = highScoreModel.Count - 1;

                while (i >= highScoreLimit)
                {
                    highScoreModel.RemoveAt(i);
                    i--;
                }
            }
            hsModel.highScoreAccess.SaveScore(highScoreModel);
        }
    }
}
