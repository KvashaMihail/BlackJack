using System;
using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Services;

namespace BlackJack.Pages
{
    class PlayPage
    {
        private readonly Game _game;
        private Round _round;
        private IEnumerable<Player> _players;
        private int _countPlayers;

        private Dealer _dealerRoundService;
        private PlayerRoundService _playerRoundService;
        private List<BotRoundService> _botsRoundService;

        private readonly CardService _cardService;
        private readonly RoundService _roundService;
        private readonly PlayerService _playerService;

        public PlayPage(BlackJackContext database, Player player, Game game, byte countBots)
        {
            _countPlayers = countBots + 2;
            _roundService = new RoundService(database);
            _playerService = new PlayerService(database);
            _cardService = new CardService(database);
            _dealerRoundService = new Dealer();
            _game = game;
            _players = _playerService.GetPlayers(player, countBots);
        }

        public void ClearPage(int currentRound)
        {
            Console.Clear();
            Console.WriteLine($"Раунд {currentRound}");
        }

        public void StartPage()
        {
            int currentRound = 1;
            do
            {
                ClearPage(currentRound);
                StartRound(currentRound);
                SaveRound();
                currentRound++;
            }
            while (CheckIfExit());
        }

        private void StartRound(int currentRound)
        {
            _round = new Round { Game = _game, NumberRound = currentRound };
            _playerRoundService = new PlayerRoundService(_players.ElementAt(0).Id);
            _botsRoundService = new List<BotRoundService>();
            foreach (Player bot in _players.Skip(1))
            {
                BotRoundService botRoundService = new BotRoundService(bot.Id);
                _botsRoundService.Add(botRoundService);
            }
            _dealerRoundService.MixCards();
            ShowNamePlayersString();
            int numberCard = 1;
            NextCard(numberCard++);
            NextCard(numberCard++);
            ShowScores();
            if (CheckIfBlackJack() >= _countPlayers)
            {
                ShowEnd();
            }
            if (CheckIfBlackJack() < _countPlayers)
            {
                NextStep(numberCard);
            }
        }

        private void SaveRound()
        {

        }

        private bool CheckIfExit()
        {
            Console.WriteLine("Закончить игру? (yes/no)");
            string playerResponse = Console.ReadLine();
            if (playerResponse == "yes")
            {
                return false;
            }
            return true;
        }

        private void ShowNamePlayersString()
        {
            Console.Write("Players:");
            foreach (Player player in _players)
            {
                Console.Write("{0, 15}", player.Name);
            }
            Console.WriteLine("{0, 15}", "Dealer");
        }

        private void ShowScores()
        {
            Console.Write("Scores :");
            Console.Write("{0, 15}", _playerRoundService.Score);
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                Console.Write("{0, 15}", botRoundService.Score);
            }
            Console.WriteLine("{0, 15}", _dealerRoundService.Score);
        }

        private void NextCard(int numberCard)
        {
            int idCard;
            Console.Write("[Card{0, 2}]", numberCard);
            if (!_playerRoundService.NotGiveCard)
            {
                idCard = _dealerRoundService.GiveCard();
                _playerRoundService.GetCard(idCard, numberCard);
                _playerRoundService.Score += _cardService.GetScoreCard(idCard);
                Console.Write("{0, 15}", _cardService.GetStringCard(idCard));
            }
            if (_playerRoundService.NotGiveCard)
            {
                Console.Write("{0, 15}", "----");
            }

            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                if (!botRoundService.NotGiveCard)
                {
                    idCard = _dealerRoundService.GiveCard();
                    botRoundService.GetCard(idCard, numberCard);
                    botRoundService.Score += _cardService.GetScoreCard(idCard);
                    Console.Write("{0, 15}", _cardService.GetStringCard(idCard));
                }
                if (botRoundService.NotGiveCard)
                {
                    Console.Write("{0, 15}", "----");
                }
                
            }
            if (!_dealerRoundService.NotGiveCard)
            {
                idCard = _dealerRoundService.GetCard(numberCard);
                _dealerRoundService.Score += _cardService.GetScoreCard(idCard);
                Console.WriteLine("{0, 15}", _cardService.GetStringCard(idCard));
            }
            if (_dealerRoundService.NotGiveCard)
            {
                Console.Write("{0, 15}", "----");
            }
            
        }

        private int CheckIfBlackJack()
        {
            int countPlayersEndGame = 0;
            if (_dealerRoundService.Score == 21)
            {
                countPlayersEndGame = _countPlayers;
                _dealerRoundService.RoundPlayer.IsWin = true;
                _playerRoundService.RoundPlayer.IsWin = false;
                foreach (BotRoundService botRoundService in _botsRoundService)
                {
                    botRoundService.RoundPlayer.IsWin = false;
                }
            }
            if (_playerRoundService.Score == 21)
            {
                _playerRoundService.RoundPlayer.IsWin = true;
                _playerRoundService.NotGiveCard = true;
                countPlayersEndGame++;
            }
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                if (botRoundService.Score == 21)
                {
                    botRoundService.RoundPlayer.IsWin = true;
                    botRoundService.NotGiveCard = true;
                    countPlayersEndGame++;
                }
            }
            return countPlayersEndGame;
        }

        private int CheckIfOver()
        {
            int countPlayersEndGame = 0;
            if (_dealerRoundService.Score > 21)
            {
                countPlayersEndGame = _countPlayers;
                _dealerRoundService.RoundPlayer.IsWin = false;
                _playerRoundService.RoundPlayer.IsWin = true;
                foreach (BotRoundService botRoundService in _botsRoundService)
                {
                    botRoundService.RoundPlayer.IsWin = true;
                }
            }
            if (_playerRoundService.Score > 21)
            {
                _playerRoundService.RoundPlayer.IsWin = false;
                _playerRoundService.NotGiveCard = true;
                countPlayersEndGame++;
            }
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                if (botRoundService.Score > 21)
                {
                    botRoundService.RoundPlayer.IsWin = false;
                    botRoundService.NotGiveCard = true;
                    countPlayersEndGame++;
                }
            }
            return countPlayersEndGame;
        }

        private bool CheckIfGetCard()
        {
            Console.Write("Взять карту? (yes/no): ");
            string playerResponse = Console.ReadLine();
            if (playerResponse == "yes")
            {
                return false;
            }
            return true;
        }

        private int TakeAction()
        {
            int countPlayersEndGame = 0;
            if (!_playerRoundService.NotGiveCard)
            {
                _playerRoundService.NotGiveCard = CheckIfGetCard();
            }            
            if (_playerRoundService.NotGiveCard)
            {
                countPlayersEndGame++;
            }
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                botRoundService.TakeAction();
                if (botRoundService.NotGiveCard)
                {
                    countPlayersEndGame++;
                }
            }
            return countPlayersEndGame;
        }

        private void ShowEnd()
        {
            Console.Write("Result :");
            Console.Write("{0, 15}", _playerRoundService.RoundPlayer.IsWin);
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                Console.Write("{0, 15}", botRoundService.RoundPlayer.IsWin);
            }
            Console.WriteLine("{0, 15}", _dealerRoundService.RoundPlayer.IsWin);
        }

        private void CheckIsWin()
        {
            int score = _dealerRoundService.Score;
            if (_playerRoundService.Score > score)
            {
                _playerRoundService.RoundPlayer.IsWin = true;
            }
            foreach (BotRoundService botRoundService in _botsRoundService)
            {
                if (botRoundService.Score > score)
                {
                    botRoundService.RoundPlayer.IsWin = true;
                }
            }

        }

        private int NextStep(int numberCard)
        {
            int countPlayersEndGame = TakeAction();
            NextCard(numberCard++);
            ShowScores();
            countPlayersEndGame  += CheckIfOver();
            if (countPlayersEndGame < _countPlayers)
            {
                NextStep(numberCard);
                return 0;
            }
            if (countPlayersEndGame >= _countPlayers)
            {
                ShowEnd();
                return 0;
            }
            if ((countPlayersEndGame >= _countPlayers) & _dealerRoundService.Score > 21)
            {
                CheckIsWin();
                ShowEnd();
                return 0;
            }
            return 0;
        }
    }
}
