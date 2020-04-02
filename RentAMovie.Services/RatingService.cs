using RentAMovie.Data;
using RentAMovie.Models.RatingModels.Game;
using System;
using System.Collections.Generic;
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

        // Rate a Movie
    }
}
