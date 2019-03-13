using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class BoxRepository : IRepository<Box>
    {
        private BlackJackContext _database;

        public BoxRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(Box item)
        {
            _database.Boxes.Add(item);
        }

        public void Delete(int id)
        {
            Box item = _database.Boxes.Find(id);
            if (item != null)
            {
                _database.Boxes.Remove(item);
            }
        }

        public IEnumerable<Box> Find(Func<Box, bool> predicate)
        {
            return _database.Boxes.Where(predicate).ToList();
        }

        public Box Get(int id)
        {
            return _database.Boxes.Find(id);
        }

        public IEnumerable<Box> GetAll()
        {
            return _database.Boxes;
        }

        public void Update(Box item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }
    }
}
