using BlackJack.DAL.Entities;
using System.Data.Entity;

namespace BlackJack.DAL.EF
{
    public class BlackJackContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        public BlackJackContext(string connectionString) : base(connectionString)
        {

        }

    }
}
