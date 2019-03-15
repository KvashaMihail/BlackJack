using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class RoundRepository : IRepository<Round>
    {
        private BlackJackContext _database;

        public RoundRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(Round item)
        {
            _database.Rounds.Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            Round item = _database.Rounds.Find(id);
            if (item != null)
            {
                _database.Rounds.Remove(item);
                _database.SaveChanges();
            }
        }

        public IEnumerable<Round> Find(Func<Round, bool> predicate)
        {
            return _database.Rounds.Where(predicate).ToList();
        }

        public Round Get(int id)
        {
            return _database.Rounds.Find(id);
        }

        public IEnumerable<Round> GetAll()
        {
            return _database.Rounds;
        }

        public void Update(Round item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
