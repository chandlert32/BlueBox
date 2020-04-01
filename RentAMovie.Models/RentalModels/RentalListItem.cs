using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models.RentalModels
{
    class RentalListItem
    {
        public int RentalId { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public DateTime DayOfReturn { get; set; }


    }
}
