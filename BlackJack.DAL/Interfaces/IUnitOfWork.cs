using BlackJack.DAL.Entities;
using System;

namespace BlackJack.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get; }
        IRepository<Player> Players { get; }
        IRepository<Round> Rounds { get; }
        IRepository<Box> Boxes { get; }
        IRepository<Card> Cards { get; }
        void Save();
    }
}
