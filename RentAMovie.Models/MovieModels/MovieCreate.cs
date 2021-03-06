﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.MovieModels
{
    public class MovieCreate
    {
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string MovieDescription { get; set; }

        [Required]
        [Range(1900, 2050)]
        [Display(Name ="Release Year")]
        public int Year { get; set; }
    }
}
