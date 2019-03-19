﻿using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class Dealer
    {
        public List<int> Cards { get; set; }
        public RoundPlayer RoundPlayer { get; set; }
        public int Score { get; set; }
        public bool NotGiveCard { get; set; }

        private byte _currentCard;

        public Dealer()
        {
            RoundPlayer = new RoundPlayer { PlayerId = 8 };
            RoundPlayer.RoundPlayerCards = new List<RoundPlayerCard>();
            Cards = new List<int>();
        }

        private void AddDeck()
        {
            for (int i = 1; i < 53; i++)
            {
                Cards.Add(i);
            }
        }

        public void MixCards()
        {
            Cards.Clear();
            for (int i = 0; i < 4; i++)
            {
                AddDeck();
            }
            var rand = new Random();
            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                int j = rand.Next(i);
                int temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
            _currentCard = 0;
        }

        public int GiveCard()
        {
            return Cards[_currentCard++];
        }

        public void TakeAction()
        {
            if (Score > 16)
            {
                NotGiveCard = true;
            }
        }

        public int GetCard(int numberCard)
        {
            int cardId = GiveCard();
            RoundPlayer.RoundPlayerCards.Add(new RoundPlayerCard { CardId = cardId, NumberCard = numberCard });
            return cardId;
        }

    }
}
