using RentAMovie.Data;
using RentAMovie.Models.MovieModels;
using RentAMovie.Models.RatingModels.Movie;
using RentAMovie.Models.RentalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;

        public MovieService(string userID) /* DEPENDENDCY INJECTION */
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        // CREATE
        public async Task<bool> CreateMovieAsyc(MovieCreate model)
        {
            Movie entity = new Movie
            {
                MovieTitle = model.MovieTitle,
                Genre = model.Genre,
                MovieDescription = model.MovieDescription,
            };

            _context.Movies.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL
        public async Task<List<MovieListItem>> GetAllMoviesAsync()
        {
            // Get all games from db (Movie)
            var entityList = await _context.Movies.ToListAsync();

            // Turn the Movies into MovieListItems
            var movieList = entityList.Select(movie => new MovieListItem
            {
                MovieId = movie.MovieId,
                MovieTitle = movie.MovieTitle,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating,
                RentalCount = movie.Rentals.Count
            }).ToList();

            // return changed list
            return movieList;
        }

        // GET BY ID
        public async Task<MovieDetail> GetMovieByIdAsync(int movieId)
        {
            // Search Database by ID for Game
            var entity = await _context.Movies.FindAsync(movieId);
            if (entity == null)
                // throw new Exception("No game found.");
                return null;

            // Turn the entity into the Detail
            var model = new MovieDetail
            {
                MovieId = entity.MovieId,
                MovieTitle = entity.MovieTitle,
                Genre = entity.Genre,
                MovieDescription = entity.MovieDescription,
                Rentals = entity.Rentals.Select(rental => new RentalListItem
                {
                    RentalId = rental.RentalId,
                    //DayOfReturn = rental.DayOfReturn,
                }).ToList()
                //Year = entity.Year,
                //Ratings = entity.Ratings,
                //Rentals = entity.Rentals,

            };

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
            }

            // return the detail model
            return model;
        }
    }
}
