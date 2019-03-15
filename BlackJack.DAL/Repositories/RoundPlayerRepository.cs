using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class RoundPlayerRepository : IRepository<RoundPlayer>
    {
        private BlackJackContext _database;

        public RoundPlayerRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(RoundPlayer item)
        {
            _database.RoundPlayers.Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            RoundPlayer item = _database.RoundPlayers.Find(id);
            if (item != null)
            {
                _database.RoundPlayers.Remove(item);
                _database.SaveChanges();
            }
        }

        public IEnumerable<RoundPlayer> Find(Func<RoundPlayer, bool> predicate)
        {
            return _database.RoundPlayers.Where(predicate).ToList();
        }

        public RoundPlayer Get(int id)
        {
            return _database.RoundPlayers.Find(id);
        }

        public IEnumerable<RoundPlayer> GetAll()
        {
            return _database.RoundPlayers;
        }

        public void Update(RoundPlayer item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
