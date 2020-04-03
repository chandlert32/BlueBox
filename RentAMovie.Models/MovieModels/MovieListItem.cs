using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.MovieModels
{
    public class MovieListItem
    {
        public int MovieId { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Average Rating")]
        public double AverageRating { get; set; }

        [Display(Name = "Rental Count")]
        public int RentalCount { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
