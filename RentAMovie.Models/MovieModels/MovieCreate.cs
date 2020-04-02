using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.MovieModels
{
    public class MovieCreate
    {
        [Required]
        public string MovieTitle { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string MovieDescription { get; set; }

        //public DateTime Year { get; set; }
    }
}
