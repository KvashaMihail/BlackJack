using BlackJack.DAL.Entities;
using System.Data.Entity;

namespace BlackJack.DAL.EF
{
    public class BlackJackContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public BlackJackContext(string connectionString) : base(connectionString)
        {

        }
    }
}
