using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {

        private BlackJackContext _database;

        public GameRepository(BlackJackContext database)
        {
            this._database = database;
        }

        public void Create(Game item)
        {          
            _database.Games.Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            Game item = _database.Games.Find(id);
            if (item != null)
            {
                _database.Games.Remove(item);
                _database.SaveChanges();
            }
        }

        public IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return _database.Games.Where(predicate).ToList();
        }

        public Game Get(int id)
        {
            return _database.Games.Find(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _database.Games;
            //return Find(Game => Game.Rounds.FirstOrDefault().RoundPlayers.Any(player => player.PlayerId == idPlayer));
        }

        public void Update(Game item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
