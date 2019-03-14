using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class RoundPlayerCard
    {
        public int Id { get; set; }
        [Required]
        public int NumberCard { get; set; }

        public int RoundPlayerId { get; set; }
        public RoundPlayer RoundPlayer { get; set; }
    }
}
