using BlackJack.DAL.Entities;
using System.Data.Entity;

namespace BlackJack.DAL.EF
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<BlackJackContext>
    {
        protected override void Seed(BlackJackContext database)
        {
            for(byte value = 0; value < 13; value++)
            {
                database.Cards.Add(new Card { Value = value, Suit = 0 });
                database.Cards.Add(new Card { Value = value, Suit = 1 });
                database.Cards.Add(new Card { Value = value, Suit = 2 });
                database.Cards.Add(new Card { Value = value, Suit = 3 });            
            }
            database.Players.Add(new Player { Name = "Bob", IsBot = true });
            database.Players.Add(new Player { Name = "Kate", IsBot = true });
            database.Players.Add(new Player { Name = "Harry", IsBot = true });
            database.Players.Add(new Player { Name = "Randolph", IsBot = true });
            database.Players.Add(new Player { Name = "William", IsBot = true });
            database.Players.Add(new Player { Name = "Adam", IsBot = true });
            database.Players.Add(new Player { Name = "Olivia", IsBot = true });
            database.Players.Add(new Player { Name = "Dealer", IsBot = true });
            database.SaveChanges();
            base.Seed(database);
        }
    }

    public class BlackJackContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        public BlackJackContext() : base("DbConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        

    }
}
