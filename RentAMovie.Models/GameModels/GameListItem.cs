using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.GameModels
{
    public class GameListItem
    {
        public int GameId { get; set; }

        [Display(Name = "Title")]
        public string GameTitle { get; set; }
        public string Type { get; set; }

        [Display(Name="Average Rating")]
        public double AverageRating { get; set; }

        [Display(Name = "Rental Count")]
        public int RentalCount { get; set; }

        //For what Console?

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
