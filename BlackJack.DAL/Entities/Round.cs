using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DAL.Entities
{
    public class Round
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int NumberRound { get; set; }

        public ICollection<RoundPlayer> RoundPlayers { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
