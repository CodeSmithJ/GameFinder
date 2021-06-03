using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BFGgameFinder.Models;
using BFGgameFinder.Models.GameModels;
using BFGgameFinder.Services;
using Microsoft.AspNet.Identity;


namespace BFGgameFinder.WebAPI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }

        //public IHttpActionResult Get(int id)
        //{
        //    GameService gameService = CreateGameService();
        //    var game = gameService.GetGameById(id);
        //    return Ok(game);
        //}
        private GameService CreateGameService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(userId);
            return gameService;
        }
    }
}
