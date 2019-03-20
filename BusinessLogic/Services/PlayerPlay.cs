using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerPlay 
    {
        public RoundPlayer RoundPlayer { get; set; }
        public int Score { get; set; }
        public bool NotGiveCard { get; set; }
        private List<int> _scores;

        public PlayerPlay(int playerId)
        {
            RoundPlayer = new RoundPlayer { PlayerId = playerId };
            RoundPlayer.RoundPlayerCards = new List<RoundPlayerCard>();
            _scores = new List<int>();
        }

        public void GetCard(int cardId, int score, int numberCard)
        {
            RoundPlayer.RoundPlayerCards.Add(new RoundPlayerCard { CardId = cardId, NumberCard = numberCard });
            _scores.Add(score);
            if (_scores.Sum() > 21)
            {
                Scoring();
            }
            Score = _scores.Sum();            
        }

        private void Scoring()
        {
            int index = 0;
            foreach(int score in _scores)
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
