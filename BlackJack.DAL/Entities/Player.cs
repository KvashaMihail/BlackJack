using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Money { get; set; }
        [Required]

        public ICollection<Game> Games { get; set; }
        public ICollection<Box> Boxes { get; set; }
        public int GameId { get; set; }
    }
}
