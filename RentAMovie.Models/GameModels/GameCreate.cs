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
        public string GameTitle { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Player { get; set; }

        [Required]
        public bool Online { get; set; }

        [Required]
        public string GameDescription { get; set; }

        //public DateTime Year { get; set; }
    }
}