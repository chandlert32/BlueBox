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
        public string GameTitle { get; set; }

        [Required]
        public string Console { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int Player { get; set; }

        [Required]
        public bool Online { get; set; }

        [Required]
        public string GameDescription { get; set; }

        //public DateTime Year { get; set; }

        public double AverageRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                    return (double)Ratings.Sum(rating => rating.Score) / Ratings.Count;

                return 0;
            }
        }

        public virtual ICollection<GameRating> Ratings { get; set; } = new List<GameRating>();
        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? Modified { get; set; }

    }
}
