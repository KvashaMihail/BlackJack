using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class PlayerRoundService 
    {
        public RoundPlayer RoundPlayer { get; set; }
        public int Score { get; set; }
        public bool NotGiveCard { get; set; }

        public PlayerRoundService(int playerId)
        {
            RoundPlayer = new RoundPlayer { PlayerId = playerId };
            RoundPlayer.RoundPlayerCards = new List<RoundPlayerCard>();
            Score = 0;
        }

        public void GetCard(int cardId, int numberCard)
        {
            RoundPlayer.RoundPlayerCards.Add(new RoundPlayerCard { CardId = cardId, NumberCard = numberCard });
        }

    }
}
