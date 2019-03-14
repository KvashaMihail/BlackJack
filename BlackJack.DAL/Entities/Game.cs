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
        [Required]
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}
