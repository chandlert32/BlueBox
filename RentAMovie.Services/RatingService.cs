using RentAMovie.Data;
using RentAMovie.Models.RatingModels.Game;
using RentAMovie.Models.RatingModels.Movie;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Services
{
    public class RatingService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;

        public RatingService(string userID) /* DEPENDENDCY INJECTION */
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        // Rate a Game
        public async Task<bool> CreateGameRatingAsync(GameRatingCreate model)
        {
            var entity = new GameRating
            {
                GameId = model.GameId,
                Score = model.Score,
                Description = model.Description,
                UserId = _userID,
            };

            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL RATED GAMES
        public async Task<List<GameRatingListItem>> GetAllGameRatingsAsync()
        {
            // Get all games from db (Game)
            var entityList = await _context.GameRatings.ToListAsync();

            // Turn the GameRating into GameRatingListItems
            var gameratingList = entityList.Select(gamerating=> new GameRatingListItem
            {
                RatingId = gamerating.RatingId,
                GameTitle = gamerating.Game.GameTitle,
                Score = gamerating.Score,
                Description = gamerating.Description
            }).ToList();

            // return changed list
            return gameratingList;
        }





























        // Rate a Movie
        public async Task<bool> CreateMovieRatingAsync(MovieRatingCreate model)
        {
            var entity = new MovieRating
            {
                MovieId = model.MovieId,
                Score = model.Score,
                Description = model.Description,
                UserId = _userID,
            };

            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL RATED Movies
        public async Task<List<MovieRatingListItem>> GetAllMovieRatingsAsync()
        {
            // Get all games from db (Game)
            var entityList = await _context.MovieRatings.ToListAsync();

            // Turn the GameRating into GameRatingListItems
            var movieratingList = entityList.Select(movierating => new MovieRatingListItem
            {
                RatingId = movierating.RatingId,
                MovieTitle = movierating.Movie.MovieTitle,
                Score = movierating.Score,
                Description = movierating.Description
            }).ToList();

            // return changed list
            return movieratingList;
        }
    }
}
