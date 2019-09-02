namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using VaporStore.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Card
    {
        public Card()
        {
            this.Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        [Required]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}