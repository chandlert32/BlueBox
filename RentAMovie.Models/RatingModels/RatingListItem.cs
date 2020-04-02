using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RatingModels
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int Score { get; set; }
        public bool IsUserOwned { get; set; }
    }
}
