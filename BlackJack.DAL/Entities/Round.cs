using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Round
    {
        public int Id { get; set; }
        [Required]
        public int NumberRound { get; set; }

        public ICollection<Box> Boxes { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
