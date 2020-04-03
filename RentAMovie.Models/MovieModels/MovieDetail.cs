using RentAMovie.Models.RatingModels.Movie;
using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.MovieModels
{
    public class MovieDetail
    {
        public int MovieId { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Description")]
        public string MovieDescription { get; set; }
        public DateTime Year { get; set; }
        public List<MovieRatingListItem> Ratings { get; set; } = new List<MovieRatingListItem>();
        public List<RentalListItem> Rentals { get; set; } = new List<RentalListItem>();

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
