using System;
using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services;

namespace BlackJack.BusinessLogic.Pages
{
    class PlayPage
    {
        private readonly Game _game;
        private Round _round;
        private IEnumerable<Player> _players;
        private int _countPlayers;

        private Dealer _dealer;
        private PlayerPlay _player;
        private List<Bot> _bots;

        private readonly CardService _cardService;
        private readonly RoundService _roundService;
        private readonly PlayerService _playerService;

        public PlayPage(BlackJackContext database, Player player, Game game, byte countBots)
        {
            _countPlayers = countBots + 2;
            _roundService = new RoundService(database);
            _playerService = new PlayerService(database);
            _cardService = new CardService(database);            
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
            _player = new Services.PlayerPlay(_players.ElementAt(0).Id);
            _bots = new List<Bot>();
            _dealer = new Dealer();
            foreach (DAL.Entities.Player player in _players.Skip(1))
            {
                Bot bot = new Bot(player.Id);
                _bots.Add(bot);
            }
            _dealer.MixCards();
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
            foreach (DAL.Entities.Player player in _players)
            {
                Console.Write("{0, 15}", player.Name);
            }
            Console.WriteLine("{0, 15}", "Dealer");
        }

        private void ShowScores()
        {
            Console.Write("Scores :");
            Console.Write("{0, 15}", _player.Score);
            foreach (Bot bot in _bots)
            {
                Console.Write("{0, 15}", bot.Score);
            }
            Console.WriteLine("{0, 15}", _dealer.Score);
        }

        private void NextCard(int numberCard)
        {
            int idCard;
            int score;
            Console.Write("[Card{0, 2}]", numberCard);
            if (!_player.NotGiveCard)
            {
                idCard = _dealer.GiveCard();
                score = _cardService.GetScoreCard(idCard);
                _player.GetCard(idCard, score, numberCard);
                Console.Write("{0, 15}", _cardService.GetStringCard(idCard));
            }
            if (_player.NotGiveCard)
            {
                Console.Write("{0, 15}", " ");
            }

            foreach (Bot bot in _bots)
            {
                if (!bot.NotGiveCard)
                {
                    idCard = _dealer.GiveCard();
                    score = _cardService.GetScoreCard(idCard);
                    bot.GetCard(idCard, score, numberCard);
                    Console.Write("{0, 15}", _cardService.GetStringCard(idCard));
                }
                if (bot.NotGiveCard)
                {
                    Console.Write("{0, 15}", " ");
                }                
            }
            if (!_dealer.NotGiveCard)
            {
                idCard = _dealer.GiveCard();                
                score = _cardService.GetScoreCard(idCard);
                _dealer.GetCard(idCard, score, numberCard);
                Console.WriteLine("{0, 15}", _cardService.GetStringCard(idCard));
            }
            if (_dealer.NotGiveCard)
            {
                Console.WriteLine("{0, 15}", " ");
            }           
        }

        private int CheckIfBlackJack()
        {
            int countPlayersEndGame = 0;
            if (_dealer.Score == 21)
            {
                countPlayersEndGame = _countPlayers;
                _dealer.RoundPlayer.IsWin = true;
                _player.RoundPlayer.IsWin = false;
                foreach (Bot bot in _bots)
                {
                    bot.RoundPlayer.IsWin = false;
                }
            }
            if (_player.Score == 21)
            {
                _player.RoundPlayer.IsWin = true;
                _player.NotGiveCard = true;
                countPlayersEndGame++;
            }
            foreach (Bot bot in _bots)
            {
                if (bot.Score == 21)
                {
                    bot.RoundPlayer.IsWin = true;
                    bot.NotGiveCard = true;
                    countPlayersEndGame++;
                }
            }
            return countPlayersEndGame;
        }

        private int CheckIfOver()
        {
            int countPlayersEndGame = 0;
            if (_dealer.Score > 21)
            {
                countPlayersEndGame = _countPlayers;
                _dealer.RoundPlayer.IsWin = false;
                _player.RoundPlayer.IsWin = true;
                foreach (Bot bot in _bots)
                {
                    bot.RoundPlayer.IsWin = true;
                }
            }
            if (_player.Score > 21)
            {
                _player.RoundPlayer.IsWin = false;
                _player.NotGiveCard = true;
                countPlayersEndGame++;
            }
            foreach (Bot bot in _bots)
            {
                if (bot.Score > 21)
                {
                    bot.RoundPlayer.IsWin = false;
                    bot.NotGiveCard = true;
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
            if (!_player.NotGiveCard)
            {
                _player.NotGiveCard = CheckIfGetCard();
            }            
            if (_player.NotGiveCard)
            {
                countPlayersEndGame++;
            }
            foreach (Bot bot in _bots)
            {
                bot.TakeAction();
                if (bot.NotGiveCard)
                {
                    countPlayersEndGame++;
                }
            }
            _dealer.TakeAction();
            if (_dealer.NotGiveCard)
            {
                countPlayersEndGame++;
            }
            return countPlayersEndGame;
        }

        private void ShowEnd()
        {
            Console.Write("Result :");
            Console.Write("{0, 15}", _player.RoundPlayer.IsWin);
            foreach (Bot bot in _bots)
            {
                Console.Write("{0, 15}", bot.RoundPlayer.IsWin);
            }
            Console.WriteLine();
        }

        private void CheckIsWin()
        {
            int score = _dealer.Score;
            _dealer.RoundPlayer.IsWin = true;
            if (_player.Score > score & _player.Score <= 21)
            {
                _player.RoundPlayer.IsWin = true;
                _dealer.RoundPlayer.IsWin = false;
            }
            foreach (Bot bot in _bots)
            {
                if (bot.Score > score & bot.Score <= 21)
                {
                    bot.RoundPlayer.IsWin = true;
                    _dealer.RoundPlayer.IsWin = false;
                }
            }

        }

        private int NextStep(int numberCard)
        {
            int countPlayersEndGame = TakeAction();
            if (countPlayersEndGame < _countPlayers)
            {
                NextCard(numberCard++);
                ShowScores();
            }                        
            countPlayersEndGame  += CheckIfOver();
            if (countPlayersEndGame < _countPlayers)
            {
                NextStep(numberCard);
                return 0;
            }
            if ((countPlayersEndGame >= _countPlayers) & _dealer.Score <= 21)
            {
                CheckIsWin();
                ShowEnd();
                return 0;
            }
            if (countPlayersEndGame >= _countPlayers)
            {
                ShowEnd();
                return 0;
            }            
            return 0;
        }
    }
}
