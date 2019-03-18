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
        

        public TotalService()
        {
            _database = new BlackJackContext();
            _playerPage = new PlayerPage(_database);
        }

        public void Init()
        {
            ShowStartMessage();
            _playerPage.StartPage();
        }

        private void ShowStartMessage()
        {
            Console.WriteLine("Игра BlackJack (БлэкДжэк)!");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

    }
}
