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
        private RoundService _roundService;

        public PlayPage(BlackJackContext database)
        {
            _roundService = new RoundService(database);
        }

        public void ClearPage()
        {
            Console.Clear();
            Console.WriteLine("Процесс игры");
        }
    }
}
