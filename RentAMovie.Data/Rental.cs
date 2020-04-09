using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Data
{
    public class Rental
    {
        public int RentalId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public string FirstName { get; set; }
        public string GameTitle { get; set; }
        public string MovieTitle { get; set; }

        /*public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }*/

        //public DateTime DayOfReturn { get; set; }


    }
}
