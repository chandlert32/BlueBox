using RentAMovie.Data;
using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Services
{
    public class RentalService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;

        public RentalService(string userID) /* DEPENDENDCY INJECTION */
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        // CREATE
        public async Task<bool> CreateRentalAsync (RentalCreate model)
        {
            Rental entity = new Rental
            {
                CustomerId = model.CustomerId,
                GameId = model.GameId,
                MovieId = model.MovieId,
            };

            _context.Rentals.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL
        public async Task<List<RentalListItem>> GetAllRentalsAsync()
        {
            // Get all rentals from db (Rental)
            var entityList = await _context.Rentals.ToListAsync();

            // Turn the Rentals into RentalListItems
            var rentList = entityList.Select(rent => new RentalListItem
            {
                RentalId = rent.RentalId,
                FullName = rent.Customer.FullName,
                GameTitle = rent.Game.GameTitle,
                MovieTitle = rent.Movie.MovieTitle,


            }).ToList();

            // return changed list
            return rentList;
        }

        // GET BY ID
        public async Task<RentalDetail> GetRentalByIdAsync(int rentalId)
        {
            // Search Database by ID for Rentals
            var entity = await _context.Rentals.FindAsync(rentalId);
            if (entity == null)
                // throw new Exception("No rental found.");
                return null;

            // Turn the entity into the Detail
            var model = new RentalDetail
            {
                FullName = entity.Customer.FullName,
                GameTitle = entity.Game.GameTitle,
                MovieTitle = entity.Movie.MovieTitle,
                Phone = entity.Customer.Phone,
                //DayRented = entity.DayRented,
                //ReturnDate = entity.ReturnDate


            };

            // return the detail model
            return model;
        }

        // DELETE
        public bool DeleteRental(int rentalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rentals
                        .Single(e => e.RentalId == rentalId);

                ctx.Rentals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
