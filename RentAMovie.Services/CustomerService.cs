using RentAMovie.Data;
using RentAMovie.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;

        public CustomerService(string userID) /* DEPENDENDCY INJECTION */
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        // CREATE
        public async Task<bool> CreateCustomerAsyc(CustomerCreate model)
        {
            Customer entity = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Phone = model.Phone,
                Email = model.Email,
                CreatedUtc = DateTimeOffset.Now
            };

            _context.Customers.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL
        public async Task<List<CustomerListItem>> GetAllCustomersAsync()
        {
            // Get all customers from db (Customer)
            var entityList = await _context.Customers.ToListAsync();

            // Turn the Customers into CustomerListItems
            var customerList = entityList.Select(customer => new CustomerListItem
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                RentalCount = customer.Rentals.Count
            }).ToList();

            // return changed list
            return customerList;
        }

        // GET BY ID
        public async Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
        {
            // Search Database by ID for Customer
            var entity = await _context.Customers.FindAsync(customerId);
            if (entity == null)
                // throw new Exception("No game found.");
                return null;

            // Turn the entity into the Detail
            var model = new CustomerDetail
            {
                CustomerId = entity.CustomerId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Phone = entity.Phone,
                Email = entity.Email,
                /*Rentals = entity.Rentals.Select(rental => new RentalListItem
                {
                    RentalId = rental.RentalId,
                    //DayOfReturn = rental.DayOfReturn,
                }).ToList()*/

                //Year = entity.Year,
                //Ratings = entity.Ratings,
                //Rentals = entity.Rentals,

            };

            /*
            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new MovieRatingListItem
                {
                    RatingId = rating.RatingId,
                    MovieId = entity.MovieId,
                    MovieTitle = entity.MovieTitle,
                    Description = rating.Description,
                    IsUserOwned = rating.UserId == _userID,
                    Score = rating.Score,
                });
            }*/

            // return the detail model
            return model;
        }

        // EDIT 
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Age = model.Age;
                entity.Phone = model.Phone;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
