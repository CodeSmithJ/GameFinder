using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BFGgameFinder.Models;
using BFGgameFinder.Services;
using Microsoft.AspNet.Identity;


namespace BFGgameFinder.WebAPI.Controllers
{
    private GameService CreateGameService()
    {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var gameService = new GameService(userId);
        return gameService;
    }

    public class GameController : ApiController
    {
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }
    }
}
