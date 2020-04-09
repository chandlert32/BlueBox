using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RentalModels
{
    public class RentalDetail
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }

        [Display(Name = "Game Rented:")]
        public string GameTitle { get; set; }

        [Display(Name = "Movie Rented:")]
        public string MovieTitle { get; set; }
        
        [Display(Name = "Customer:")]
        public string FullName { get; set; }

        [Display(Name = "Customer Phone:")]
        public int Phone { get; set; }


        //public DateTime DayRented { get; set; }
        //public DateTime ReturnDate { get; set; }

    }
}
