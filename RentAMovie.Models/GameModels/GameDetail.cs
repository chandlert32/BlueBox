using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels.Game
{
    public class GameDetail
    {
        public int GameId {get;set;}
        public string GameTitle { get; set; }
        public string Type { get; set; }
        public int Player { get; set; }
        public bool Online { get; set; }
        public string GameDescription { get; set; }
        public DateTime Year { get; set; }

        public List<GameRatingListItem> Ratings { get; set; }
        public List<RentalListItem> Rentals { get; set; }
    }
}
