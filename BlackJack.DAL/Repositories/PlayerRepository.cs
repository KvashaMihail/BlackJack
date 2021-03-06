﻿using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository 
    {
        private BlackJackContext _database;

        public PlayerRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(Player item)
        {
            _database.Players.Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            Player item = _database.Players.Find(id);
            if (item != null)
            {
                _database.Players.Remove(item);
                _database.SaveChanges();
            }
        }

        public List<Player> Find(Func<Player, bool> predicate)
        {
            return _database.Players.Where(predicate).ToList();
        }

        public Player GetPlayerByName(string name)
        {
            return _database.Players.Where(p => p.Name == name).FirstOrDefault();
        }

        public Player Get(int id)
        {
            return _database.Players.Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _database.Players;
        }

        public void Update(Player item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
