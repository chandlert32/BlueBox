using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.GameModels
{
    public class GameEdit
    {
        public int GameId { get; set; }

        [Display(Name = "Title")]
        public string GameTitle { get; set; }
        public string Type { get; set; }
        public int Player { get; set; }
        public bool Online { get; set; }

        [Display(Name = "Description")]
        public string GameDescription { get; set; }
    }
}
