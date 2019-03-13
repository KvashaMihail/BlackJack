using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Box
    {
        public int Id { get; set; }
        [Required]
        public double Bet { get; set; }
        public byte Score { get; set; }
        public byte Sequence { get; set; }

        public ICollection<Card> Cards { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
