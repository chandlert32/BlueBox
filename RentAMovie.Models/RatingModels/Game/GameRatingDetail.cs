using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels.Game
{
    public class GameRatingDetail
    {
        public int RatingId { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string Genre { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
    }
}
