using BFGgameFinder.Data;
using BFGgameFinder.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGgameFinder.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    GamerTag = _userId,
                    GameId = model.GameId,
                    GameName = model.GameName,
                    Rating = model.Rating,
                    Genre = new Genre() { GenreType = model.Genre.GenreType},
                    GameSystem = new GameSystem() { GameSystemType = model.GameSystem.GameSystemType},
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<GameDetails> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => e.GamerTag == _userId)
                    .Select(
                        e =>
                        new GameDetails
                        {
                            GameId = e.GameId,
                            GameName = e.GameName,
                            Rating = e.Rating,
                            Genre = new Genre() { GenreType = e.Genre.GenreType },
                            //GameSystems = e.GameSystems.GameSystemType
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
