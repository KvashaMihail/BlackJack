using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class BotRoundService 
    {
        public RoundPlayer RoundPlayer { get; set; }
        public int Score { get; set; }
        public bool NotGiveCard { get; set; }

        public BotRoundService(int playerId)
        {
            RoundPlayer = new RoundPlayer { PlayerId = playerId };
            RoundPlayer.RoundPlayerCards = new List<RoundPlayerCard>();
        }

        public void TakeAction()
        {
            Random random = new Random();
            int scoreAmbitions = random.Next(15)+5;
            if (scoreAmbitions <= Score)
            {
                NotGiveCard = true;
            }
        }

        public void GetCard(int cardId, int numberCard)
        {
            RoundPlayer.RoundPlayerCards.Add(new RoundPlayerCard { CardId = cardId, NumberCard = numberCard });
        }

        //public void DealCards()
        //{

        //}
    }
}
