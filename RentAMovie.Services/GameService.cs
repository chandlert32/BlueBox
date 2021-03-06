﻿using RentAMovie.Data;
using RentAMovie.Models.GameModels;
using RentAMovie.Models.RatingModels.Game;
using RentAMovie.Models.RentalModels;
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
            this._userID = userID;
        }

        // CREATE
        public async Task<bool> CreateGameAsyc(GameCreate model)
        {
            Game entity = new Game
            {
                GameTitle = model.GameTitle,
                Console = model.Console,
                Genre = model.Genre,
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
                Year = game.Year,
                Console = game.Console,
                Genre = game.Genre,
                AverageRating = game.AverageRating,
                RentalCount = game.Rentals.Count,
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
                Console = entity.Console,
                Genre = entity.Genre,
                Player = entity.Player,
                Online = entity.Online,
                GameDescription = entity.GameDescription,
                Year = entity.Year,
                Rentals = entity.Rentals.Select(rental => new RentalListItem
                {
                    RentalId = rental.RentalId,
                }).ToList(),

            };

            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new GameRatingListItem
                {
                    RatingId = rating.RatingId,
                    GameId = entity.GameId,
                    GameTitle = entity.GameTitle,
                    Description = rating.Description,
                    Score = rating.Score,
                });
            }

            // return the detail model
            return model;
        }

        // EDIT 
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId);

                entity.GameTitle = model.GameTitle;
                entity.Console = model.Console;
                entity.Genre = model.Genre;
                entity.Player = model.Player;
                entity.Online = model.Online;
                entity.GameDescription = model.GameDescription;
                entity.Year = model.Year;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
