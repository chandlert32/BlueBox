﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.CustomerModels
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
