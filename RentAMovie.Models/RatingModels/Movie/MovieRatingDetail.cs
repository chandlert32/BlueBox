using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels.Movie
{
    public class MovieRatingDetail
    {
        public int RatingId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
    }
}
