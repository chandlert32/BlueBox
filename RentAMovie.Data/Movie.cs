using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string MovieTitle { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string MovieDescription { get; set; }

        [Required]
        public DateTime Year { get;set; }

        public double AverageRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                    return (double)Ratings.Sum(rating => rating.Score) / Ratings.Count;

                return 0;
            }
        }

        public virtual ICollection<MovieRating> Ratings { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
