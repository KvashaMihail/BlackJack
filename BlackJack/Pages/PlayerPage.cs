using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlackJack.Pages
{
    class PlayerPage
    {
        public int IdPlayer { get; set; }
        private readonly BlackJackContext _database;
        private PlayerService _playerService;

        public PlayerPage(BlackJackContext database)
        {
            _database = database;
            _playerService = new PlayerService(_database);
        }

        public void StartPage()
        {
            ClearPage();
            byte userChoise = AskChoisePlayer();
            JoinPlayer(userChoise);
            IdPlayer = _playerService.Player.Id;
        }

        private void ClearPage()
        {
            Console.Clear();
            Console.WriteLine("Меню игрока:");
        }

        private byte GetUserChoise()
        {
            string userChoiseString = Console.ReadLine();
            if (!((userChoiseString == "1") || (userChoiseString == "0")))
            {
                Console.WriteLine("Ошибка! Введите 0 или 1!");
                return GetUserChoise();
            }
            return Convert.ToByte(userChoiseString);
        }

        private byte AskChoisePlayer()
        {
            if (_playerService.GetIsEmpty())
            {
                Console.WriteLine("Для начала нужно добавить аккаунт");
                return 0;
            }
            Console.WriteLine("0 - Новый игрок");
            Console.WriteLine("1 - Выбрать игрока");
            return GetUserChoise();
        }

        private void JoinPlayer(byte userChoise)
        {
            ClearPage();
            if (userChoise == 1)
            {
                SelectPlayer();
            }
            if (userChoise == 0)
            {
                CreationWithValidationPlayer();
            }
        }

        private void SelectPlayer()
        {
            ShowListPlayers();
            Console.WriteLine("Введите имя игрока: ");
            _playerService.Continue(GetNamePlayer());
        }

        private void ShowListPlayers()
        {
            Console.WriteLine("Список игроков: ");
            IEnumerable<Player> listPlayers = _playerService.ShowListPlayers();
            foreach (Player player in listPlayers)
            {
                Console.WriteLine($"{player.Id}: {player.Name};");
            }
        }

        private string GetNamePlayer()
        {
            string namePlayer = Console.ReadLine();
            if (_playerService.GetIsEmptyPlayer(namePlayer))
            {
                Console.WriteLine("Такого игрока нет, введите имя игрока из списка!");
                return GetNamePlayer();
            }
            return namePlayer;
        }

        private void CreationWithValidationPlayer()
        {
            Console.Write("Введите имя игрока: ");
            string namePlayer = Console.ReadLine();
            var regex = new Regex(@"[a-zA-Z][a-zA-Z0-9]*");
            bool isCorrectly = Regex.IsMatch(namePlayer, "^[a-zA-Z][a-zA-Z0-9]*$");
            bool isEmptyPlayer = _playerService.GetIsEmptyPlayer(namePlayer);
            if (!isCorrectly)
            {
                Console.WriteLine("Только латинские буквы и цифры!");
                CreationWithValidationPlayer();
            }
            if (!isEmptyPlayer)
            {
                Console.WriteLine("Такое имя занято.");
                CreationWithValidationPlayer();
            }
            if (isEmptyPlayer & isCorrectly)
            {
                _playerService.Create(namePlayer);
            }
        }
    }
}
