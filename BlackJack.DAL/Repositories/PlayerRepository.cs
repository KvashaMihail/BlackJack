using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private BlackJackContext _database;

        public PlayerRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(Player item)
        {
            _database.Players.Add(item);
        }

        public void Delete(int id)
        {
            Player item = _database.Players.Find(id);
            if (item != null)
            {
                _database.Players.Remove(item);
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            return _database.Players.Where(predicate).ToList();
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
        }
    }
}
