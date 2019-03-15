using BlackJack.DAL.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlackJack.Services
{
    public class TotalService
    {
        private BlackJackContext _database;
        private PlayerService _playerService;
        

        public TotalService()
        {
            _database = new BlackJackContext();
        }

        public void Init()
        {
            ShowStartMessage();
            byte userChoise = AskChoisePlayer();
            JoinPlayer(userChoise);
            
        }

        private void ShowStartMessage()
        {
            Console.WriteLine("Игра BlackJack (БлэкДжэк)!");
        }

        private byte GetUserChoise()
        {
            string userChoiseString = Console.ReadLine();
            if (!((userChoiseString == "1") || (userChoiseString == "0")))
            {
                Console.WriteLine("Ошибка! Введите 0 или 1!");
                return GetUserChoise();
            }
            Console.Clear();
            return Convert.ToByte(userChoiseString);
            
        }

        private byte AskChoisePlayer()
        {
            _playerService = new PlayerService(_database);
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
            _playerService = new PlayerService(_database);
            if (userChoise == 1)
            {
                Console.WriteLine("Берем существующего игрока!");
            }
            if (userChoise == 0)
            {
                CreatePlayer();
            }
        }

        private void CreatePlayer()
        {
            Console.Write("Введите имя игрока: ");
            string namePlayer = Console.ReadLine();
            var regex = new Regex(@"[a-zA-Z][a-zA-Z0-9]*");
            bool isCorrectly = Regex.IsMatch(namePlayer, "^[a-zA-Z][a-zA-Z0-9]*$");//regex.IsMatch(namePlayer); 

            bool isEmptyPlayer = !_playerService.GetIsEmptyPlayer(namePlayer);
            if (!isCorrectly)
            {
                Console.WriteLine("Только латинские буквы и цифры!");
                CreatePlayer();
            }
            if (isEmptyPlayer)
            {
                Console.WriteLine("Такое имя занято.");
                CreatePlayer();
            }
            if (!isEmptyPlayer & isCorrectly)
            {
                _playerService.Create(namePlayer);
            }            
        }
    }
}
