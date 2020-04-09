using RentAMovie.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RentalModels
{
    public class RentalCreate
    {
        [Required]
        public int CustomerId { get; set; }
        public int GameId { get; set; }
        public int MovieId { get; set; }

        //public DateTime DayRented { get; set; }
        //public DateTime ReturnDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Game Game { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
