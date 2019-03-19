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
        private PlayPage _playPage;
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
            if (_gamePage.UserChoice == 0)
            {
                _playPage = new PlayPage(_database, _playerPage.Player, _gamePage.Game, _gamePage.CountBots);
                _playPage.StartPage();
            }
        }

        private void ShowStartMessage()
        {
            Console.WriteLine("Игра BlackJack (БлэкДжэк)!");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

    }
}
