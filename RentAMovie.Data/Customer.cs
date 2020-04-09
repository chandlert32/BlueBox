using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }

        //public DateTime Birthday? { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
