using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BlackJack.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte CountPlayers { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]

        public ICollection<Player> Players { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public int PlayerId { get; set; }
    }
}
