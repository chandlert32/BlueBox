using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.MovieModels
{
    public class MovieEdit
    {
        public int MovieId { get; set; }

        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Description")]
        public string MovieDescription { get; set; }
    }
}
