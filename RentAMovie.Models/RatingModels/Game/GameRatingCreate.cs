using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels.Game
{
    public class GameRatingCreate
    {
        public int GameId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Score { get; set; }
        public string Description { get; set; }
    }
}
