using RentAMovie.Models.RatingModels.Game;
using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.GameModels
{
    public class GameDetail
    {
        public int GameId {get;set;}

        [Display(Name = "Title")]
        public string GameTitle { get; set; }
        public string Console { get; set; }
        public string Genre { get; set; }
        public int Player { get; set; }
        public bool Online { get; set; }

        [Display(Name = "Description")]
        public string GameDescription { get; set; }
        public DateTime Year { get; set; }

        public List<GameRatingListItem> Ratings { get; set; } = new List<GameRatingListItem>();
        public List<RentalListItem> Rentals { get; set; } = new List<RentalListItem>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? Modified { get; set; }

    }
}
