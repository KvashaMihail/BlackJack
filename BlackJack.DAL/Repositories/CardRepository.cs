using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : IRepository<Card>
    {
        private BlackJackContext _database;

        public CardRepository(BlackJackContext database)
        {
            _database = database;
        }

        public void Create(Card item)
        {
            _database.Cards.Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            Card item = _database.Cards.Find(id);
            if (item != null)
            {
                _database.Cards.Remove(item);
                _database.SaveChanges();
            }
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            return _database.Cards.Where(predicate).ToList();
        }

        public Card Get(int id)
        {
            return _database.Cards.Find(id);
        }

        public IEnumerable<Card> GetAll()
        {
            return _database.Cards;
        }

        public void Update(Card item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
