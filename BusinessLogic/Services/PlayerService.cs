using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Models;
using BlackJack.DAL.EF;
using BlackJack.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService 
    {
        private readonly PlayerRepository _playerRepository;
        public Player Player { get; set; }

        public PlayerService()
        {
            _playerRepository = new PlayerRepository(new BlackJackContext());
        }

        public void Select(string name)
        {
            if (GetIsEmpty(name))
            {
                throw new ValidationException("Такого игрока нет, введите имя игрока из списка!");
            }
            Player = Mapper.ToModel(_playerRepository.Find(Player => Player.Name.Equals(name)).ElementAt(0));
        }
        
        public void Create(string name)
        {
            bool isCorrectly = Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9]*$");
            bool isEmptyPlayer = GetIsEmpty(name);
            if (!isCorrectly)
            {
                throw new ValidationException("Только латинские буквы и цифры!");
            }
            if (!isEmptyPlayer)
            {
                throw new ValidationException("Такое имя занято.");
            }
            _playerRepository.Create(Mapper.ToEntity(new Player { Name = name, IsBot = false }));
            Player = Mapper.ToModel(_playerRepository.Find(Player => Player.Name.Equals(name)).ElementAt(0));
        }

        public IEnumerable<Player> ShowListPlayers()
        {
            return Mapper.ToModel(_playerRepository.Find(Player => Player.IsBot.Equals(false)));
        }

        public bool GetIsEmpty()
        {
            return !_playerRepository.Find(Player => Player.IsBot.Equals(false)).Any();
        }

        public bool GetIsEmpty(string name)
        {            
            return !_playerRepository.Find(Player => Player.Name.Equals(name)).Any();
        }

        public IEnumerable<Player> GetPlayers(Player player, byte countBots)
        {
            IEnumerable<Player> players = Mapper.ToModel(_playerRepository.Find(Player => (Player.Id <= countBots) || (Player.Id == player.Id)));
            return players.Reverse();
        }
    }
}
