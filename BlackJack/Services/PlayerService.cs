using System;
using BlackJack.DAL.EF;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class PlayerService 
    {
        private readonly PlayerRepository _playerRepository;
        public Player Player { get; set; }

        public PlayerService(BlackJackContext database)
        {
            _playerRepository = new PlayerRepository(database);
        }

        public void Continue(string name)
        {
            Player = _playerRepository.Find(Player => Player.Name.Equals(name)).ElementAt(0);
        }
        
        public void Create(string name)
        {
            _playerRepository.Create(new Player { Name = name, IsNotBot = true });
            Player = _playerRepository.Find(Player => Player.Name.Equals(name)).ElementAt(0);
        }

        public IEnumerable<Player> ShowListPlayers()
        {
            return _playerRepository.Find(Player => Player.IsNotBot.Equals(true));
        }

        public bool GetIsEmpty()
        {
            return !_playerRepository.Find(Player => Player.IsNotBot.Equals(true)).Any();
        }

        public bool GetIsEmpty(string name)
        {            
            return !_playerRepository.Find(Player => Player.Name.Equals(name)).Any();
        }

    }
}
