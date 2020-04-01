using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Player { get; set; }

        [Required]
        public bool Online { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Year { get; set; }

        public virtual ICollection<GameRating> Ratings { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
