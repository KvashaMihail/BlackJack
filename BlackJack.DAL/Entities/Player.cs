using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlackJack.DAL.Entities
{
    public class Player
    {

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsNotBot { get; set; }
        

        public ICollection<RoundPlayer> RoundPlayers { get; set; }

        
    }
}
