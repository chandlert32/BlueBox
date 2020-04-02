using RentAMovie.Data;
using RentAMovie.Models.GameModels;
using RentAMovie.Models.RatingModels.Game;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Services
{
    public class GameService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;

        public GameService(string userID) /* DEPENDENDCY INJECTION */
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        // CREATE
        public async Task<bool> CreateGameAsyc (GameCreate model)
        {
            Game entity = new Game
            {
                GameTitle = model.GameTitle,
                Type = model.Type,
                Player = model.Player,
                Online = model.Online,
                GameDescription = model.GameDescription,
                Year = model.Year,
            };

            _context.Games.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        // GET ALL
        public async Task<List<GameListItem>> GetAllGamesAsync()
        {
            // Get all games from db (Game)
            var entityList = await _context.Games.ToListAsync();

            // Turn the Games into GameListItems
            var gameList = entityList.Select(game => new GameListItem
            {
                GameId = game.GameId,
                GameTitle = game.GameTitle,
                Type = game.Type,
                AverageRating = game.AverageRating,
                RentalCount = game.Rentals.Count
            }).ToList();

            // return changed list
            return gameList;
        }

        // GET BY ID
        public async Task<GameDetail> GetGameByIdAsync(int gameId)
        {
            // Search Database by ID for Game
            var entity = await _context.Games.FindAsync(gameId);
            if (entity == null)
                // throw new Exception("No game found.");
                return null;

            // Turn the entity into the Detail
            var model = new GameDetail
            {
                GameId = entity.GameId,
                GameTitle = entity.GameTitle,
                Type = entity.Type,
                Player = entity.Player,
                Online = entity.Online,
                GameDescription = entity.GameDescription,
                Year = entity.Year,
                //Rentals = entity.Rentals,

            };

            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new GameRatingListItem
                {
                    RatingId = rating.RatingId,
                    GameId = entity.GameId,
                    GameTitle = entity.GameTitle,
                    Type = entity.Type,
                    IsUserOwned = rating.UserId == _userID,
                    Score = rating.Score,
                });
            }

            // return the detail model
            return model;
        }
    }
}
