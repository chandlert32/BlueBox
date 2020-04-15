using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        [Display(Name = "Title")]
        public string GameTitle { get; set; }

        [Required]
        public string Console { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        public int Player { get; set; }

        [Required]
        public bool Online { get; set; }

        [Required]
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }

        [Required]
        [Range(1900, 2050)]
        [Display(Name = "Release Year")]
        public int Year { get; set; }
    }
}