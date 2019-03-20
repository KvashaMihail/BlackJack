using System;
using BlackJack.DAL.EF;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService 
    {
        private readonly GameRepository _gameRepository;
        public Game Game { get; set; }

        public GameService(BlackJackContext database)
        {
            _gameRepository = new GameRepository(database);
        }

        public void Create(string name)
        {
            _gameRepository.Create(new Game { Name = name, DateStart = DateTime.Now, DateEnd = DateTime.Now});
            Game = _gameRepository.Find(Game => Game.Name.Equals(name)).ElementAt(0);
        }

        public void Continue()
        {

        }

        public void ShowListGames()
        {

        }

        public bool GetIsEmpty()
        {
            return !_gameRepository.GetAll().Any();
        }

        public bool GetIsEmpty(string name)
        {
            return !_gameRepository.Find(Game => Game.Name.Equals(name)).Any();
        }

    }
}
