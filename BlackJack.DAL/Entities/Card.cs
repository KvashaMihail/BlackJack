using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DAL.Entities
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public byte Value { get; set; }
        public byte Suit { get; set; }
        //public ICollection<RoundPlayerCard> RoundPlayerCards { get; set; }
    }
}
