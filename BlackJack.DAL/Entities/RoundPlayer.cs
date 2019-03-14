using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class RoundPlayer
    {
        public int Id { get; set; }
        [Required]
        public bool IsWin { get; set; }

        public ICollection<RoundPlayerCard> RoundPlayerCards { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
