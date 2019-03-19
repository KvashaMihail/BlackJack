using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.EF;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Entities;

namespace BlackJack.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

        public enum Suit {
            Spade = 0,
            Club = 1,
            Diamond = 2,
            Heart = 3
        }

        public enum Rank {
            Deuce = 0,
            Three = 1,
            Four = 2,
            Five = 3,
            Six = 4,
            Seven = 5,
            Eight = 6,
            Nine = 7,
            Ten = 8,
            Jack = 9,
            Queen = 10,
            King = 11,
            Ace = 12
        };

        public CardService(BlackJackContext database)
        {
            _cardRepository = new CardRepository(database);
        }

        public int GetScoreCard(int idCard)
        {
            byte valueCard = _cardRepository.Get(idCard).Value;
            if (valueCard <= 8)
            {
                return valueCard + 2;
            }
            if (valueCard > 8 && valueCard < 12)
            {
                return 10;
            }
            return 11;
        }

        public string GetStringCard(int idCard)
        {
            Card card = _cardRepository.Get(idCard);
            return $"{(Suit)card.Suit} {(Rank)card.Value}"; 
        }
    }
}
