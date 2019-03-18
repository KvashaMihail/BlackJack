using BlackJack.DAL.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BlackJack.DAL.Entities;
using BlackJack.Services;

namespace BlackJack.Pages
{
    public class TotalService
    {
        private BlackJackContext _database;
        private PlayerPage _playerPage;
        private GamePage _gamePage;

        public TotalService()
        {
            _database = new BlackJackContext();
            _playerPage = new PlayerPage(_database);
            _gamePage = new GamePage(_database);
        }

        public void Init()
        {
            ShowStartMessage();
            _playerPage.StartPage();
            _gamePage.StartPage();
            Console.Clear();
            Console.WriteLine("Процесс игры");
            Console.WriteLine($"Далее создаем игру: Игрок {_playerPage.Player.Name}; Игра {_gamePage.Game.Name} с {_gamePage.CountBots} ботами.");

        }

        private void ShowStartMessage()
        {
            Console.WriteLine("Игра BlackJack (БлэкДжэк)!");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

    }
}
