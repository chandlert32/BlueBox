using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels.Game
{
    public class GameRatingListItem : RatingListItem
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string Type { get; set; }
    }
}
