using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.CustomerModels
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public List<RentalListItem> Rentals { get; set; }

        /*[Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }*/
    }
}
