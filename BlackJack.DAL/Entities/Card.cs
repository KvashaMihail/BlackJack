using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public byte Value { get; set; }
        [Required]
        public byte Suit { get; set; }
        [Required]

        public int BoxId { get; set; }
        public Box Box { get; set; }
    }
}
