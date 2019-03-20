using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class Bot 
    {
        public RoundPlayer RoundPlayer { get; set; }
        public int Score { get; set; }
        public bool NotGiveCard { get; set; }
        private List<int> _scores;

        public Bot(int playerId)
        {
            RoundPlayer = new RoundPlayer { PlayerId = playerId };
            RoundPlayer.RoundPlayerCards = new List<RoundPlayerCard>();
            _scores = new List<int>();
        }

        public void TakeAction()
        {
            Random random = new Random();
            int scoreAmbitions = random.Next(5,15);
            if (scoreAmbitions <= Score)
            {
                NotGiveCard = true;
            }
        }

        public void GetCard(int cardId, int score, int numberCard)
        {
            RoundPlayer.RoundPlayerCards.Add(new RoundPlayerCard { CardId = cardId, NumberCard = numberCard });
            _scores.Add(score);
            if (_scores.Sum() > 21)
            {
                SetFirstAceScoreToOne();
            }
            Score = _scores.Sum();

        }

        private void SetFirstAceScoreToOne()
        {
            int index = 0;
            foreach (int score in _scores)
            {
                if (score == 11)
                {
                    _scores[index] = 1;
                    break;
                }
                index++;
            }
        }

    }
}
