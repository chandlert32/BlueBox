using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RentalModels
{
    public class RentalListItem
    {
        public int RentalId { get; set; }

        [Display(Name = "Customer")]
        public string FullName { get; set; }

        [Display(Name = "Game Rented")]
        public string GameTitle { get; set; }

        [Display(Name = "Movie Rented")]
        public string MovieTitle { get; set; }



    }
}
