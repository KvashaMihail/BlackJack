﻿using System;
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
        private readonly BlackJackContext _database;
        private readonly PlayerRepository _playerRepository;

        public PlayerService(BlackJackContext database)
        {
            _database = database;
            _playerRepository = new PlayerRepository(_database);
        }

        public void Continue()
        {
            
        }
        
        public void Create(string name)
        {
            _playerRepository.Create(new Player { Name = name, IsNotBot = true });
        }

        public void ShowListPlayers()
        {
            
        }

        public bool GetIsEmpty()
        {
            return !_playerRepository.Find(Player => Player.IsNotBot.Equals(true)).Any();
        }

        public bool GetIsEmptyPlayer(string name)
        {            
            return !_playerRepository.Find(Player => Player.Name.Equals(name)).Any();
        }

    }
}
