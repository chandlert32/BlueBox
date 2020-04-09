using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.CustomerModels
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
