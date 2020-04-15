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
                Year = model.Year
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
                Year = movie.Year,
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
                Year = entity.Year,
                Genre = entity.Genre,
                MovieDescription = entity.MovieDescription,
                Rentals = entity.Rentals.Select(rental => new RentalListItem
                {
                    RentalId = rental.RentalId,
                }).ToList()

            };

            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new MovieRatingListItem
                {
                    RatingId = rating.RatingId,
                    MovieId = entity.MovieId,
                    MovieTitle = entity.MovieTitle,
                    Description = rating.Description,
                    Score = rating.Score,
                });
            }

            // return the detail model
            return model;
        }

        // EDIT 
        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == model.MovieId);

                entity.MovieTitle = model.MovieTitle;
                entity.Year = model.Year;
                entity.Genre = model.Genre;
                entity.MovieDescription = model.MovieDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == movieId);

                ctx.Movies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
