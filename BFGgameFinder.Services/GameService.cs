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
        public bool CreateNote(GameCreate model)
        {
            var entity =
                new Game()
                {
                    GamerTag = _userId,
                    GameName = model.GameName,
                    GameSystem = model.GameSystem,
                    ReleaseDate = DateTimeOffset.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameItemList> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => e.GamerTag == _userId)
                    .Select(
                        e =>
                        new GameItemList
                        {
                            GameId = e.GameId,
                            GameName = e.GameName,
                            ReleaseDate = e.ReleaseDate,
                            CategoryId = e.CategoryId,
                            CategoryName = e.Category.Name
                        }
                        );
                return query.ToArray();
            }
        }

        public GameDetails GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == id && e.GamerTag == _userId);
                return
                    new GameDetails
                    {
                        GameId = entity.GameId,
                        GameName = entity.GameName,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        CategoryId = entity.CategoryId,
                        Category = new CategoryListItem() { CategoryId = entity.Category.CategoryId, Name = entity.Category.Name }
                    };
            }
        }


        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == model.GameId && e.GamerTag == _userId);

                entity.GameName = model.GameName;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.Now;
                entity.CategoryId = model.CategoryId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == noteId && e.GamerTag == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
}
