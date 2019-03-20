using System;
using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.BusinessLogic.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BlackJack.BusinessLogic.Pages
{
    class GamePage
    {
        public byte CountBots { get; set; }
        public Game Game { get; set; }
        public byte UserChoice { get; set; }

        private GameService _gameService;

        public GamePage(BlackJackContext database)
        {
            _gameService = new GameService(database);
        }

        public void StartPage()
        {
            ClearPage();
            UserChoice = AskChoiseMenuGame();
            AcceptChoise(UserChoice);
        }

        private void ClearPage()
        {
            Console.Clear();
            Console.WriteLine("Меню игры");
        }

        private byte AskChoiseMenuGame()
        {
            Console.WriteLine("0 - Начать игру");
            Console.WriteLine("1 - Просмотр игр");
            return GetUserChoise();
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

        private void AcceptChoise(byte userChoise)
        {
            ClearPage();
            if (userChoise == 1)
            {
                Console.WriteLine("Смотрим список игр");
            }
            if (userChoise == 0)
            {
                CreateGame();

            }
        }

        private void CreateGame()
        {
            _gameService.Create(GetNameGame());
            Game = _gameService.Game;
            CountBots = GetCountBots();
        }

        private string GetNameGame()
        {
            Console.Write("Введите имя игры: ");
            string nameGame = Console.ReadLine();
            bool isCorrectly = Regex.IsMatch(nameGame, "^[a-zA-Z][a-zA-Z0-9]*$");
            bool isEmptyGame = _gameService.GetIsEmpty(nameGame);
            if (!isCorrectly)
            {
                Console.WriteLine("Только латинские буквы и цифры!");
                nameGame = GetNameGame();
            }
            if (!isEmptyGame)
            {
                Console.WriteLine("Такое имя занято.");
                nameGame = GetNameGame();
            }
            return nameGame;
        }

        private byte GetCountBots()
        {
            Console.Write("Введите количество ботов: ");
            string countBotsString = Console.ReadLine();
            bool isCorrectly = Regex.IsMatch(countBotsString, "^[0-7]$");
            if (!isCorrectly)
            {
                Console.WriteLine("Количество ботов может быть только от 0 до 7!");
                return GetCountBots();
            }
            return Convert.ToByte(countBotsString);
        }
    }
}
