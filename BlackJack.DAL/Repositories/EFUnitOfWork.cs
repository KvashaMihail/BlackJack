using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;

namespace BlackJack.DAL.Repositories 
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlackJackContext _database;
        private GameRepository _gameRepository;
        private PlayerRepository _playerRepository;
        private RoundRepository _roundRepository;
        private BoxRepository _boxRepository;
        private CardRepository _cardRepository;

        public EFUnitOfWork(string connectionString)
        {
            _database = new BlackJackContext(connectionString);
        }
        public IRepository<Game> Games
        {
            get
            {
                if (_gameRepository == null)
                    _gameRepository = new GameRepository(_database);
                return _gameRepository;
            }
        }

        public IRepository<Player> Players
        {
            get
            {
                if (_playerRepository == null)
                    _playerRepository = new PlayerRepository(_database);
                return _playerRepository;
            }
        }

        public IRepository<Round> Rounds
        {
            get
            {
                if (_roundRepository == null)
                    _roundRepository = new RoundRepository(_database);
                return _roundRepository;
            }
        }

        public IRepository<Box> Boxes
        {
            get
            {
                if (_boxRepository == null)
                    _boxRepository = new BoxRepository(_database);
                return _boxRepository;
            }
        }

        public IRepository<Card> Cards
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new CardRepository(_database);
                return _cardRepository;
            }
        }


        public void Save()
        {
            _database.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
