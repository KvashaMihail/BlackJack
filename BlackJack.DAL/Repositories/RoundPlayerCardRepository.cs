using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class RoundPlayerCardRepository : IRepository<RoundPlayerCard>
    {
        private BlackJackContext _database;

        public RoundPlayerCardRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(RoundPlayerCard item)
        {
            _database.RoundPlayerCards.Add(item);
        }

        public void Delete(int id)
        {
            RoundPlayerCard item = _database.RoundPlayerCards.Find(id);
            if (item != null)
            {
                _database.RoundPlayerCards.Remove(item);
            }
        }

        public IEnumerable<RoundPlayerCard> Find(Func<RoundPlayerCard, bool> predicate)
        {
            return _database.RoundPlayerCards.Where(predicate).ToList();
        }

        public RoundPlayerCard Get(int id)
        {
            return _database.RoundPlayerCards.Find(id);
        }

        public IEnumerable<RoundPlayerCard> GetAll()
        {
            return _database.RoundPlayerCards;
        }

        public void Update(RoundPlayerCard item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }
    }
}
