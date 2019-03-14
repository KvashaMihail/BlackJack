using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DAL.Entities
{
    public class RoundPlayerCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int NumberCard { get; set; }

        public int RoundPlayerId { get; set; }
        public RoundPlayer RoundPlayer { get; set; }
    }
}
