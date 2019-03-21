using BlackJack.Common.Enums;
using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Repositories;

namespace BlackJack.BusinessLogic.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

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
            return (int)RankScore.Ace;
        }

        public string GetStringCard(int idCard)
        {
            Card card = _cardRepository.Get(idCard);
            return $"{(Suit)card.Suit} {(Rank)card.Value}"; 
        }
    }
}
