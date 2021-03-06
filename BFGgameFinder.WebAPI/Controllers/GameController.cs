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


        // Build feature for admin to remove games, return 200 Ok 
        // if error return 400 "Game could not be removed"


        // Build a feature to show community posts related to game being viewed, Return 200 ok if community post are related to game
        // error code 400  saying "No community post related to the game"

        // would add a feature to filter game out based on the users gerne input, should return users with title of games based on the genre. 
        // if no games for genre will return error 400 saying "no game by that genre"


        // Build a feature that allows users to view games based off maturity rating


        //Build a feature that allows the user to select star ratings


        //This feature adds a method for sending back games that have been downloaded the most.
        //If this fails it will send back a game not found it will send back a "Game not found" error message.


        // Build a feature that allows user to search by name


        // Feature will be added here for if a user exceeds a 50 character limit. If they do there will be a "Character limit exceeded error" displayed


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

        //Already done // Done during the creation of the project



        //This is a feature for Admins to update games. This should update information on the game and return a 200 ok message. 
        //If it is not updated correctly it will return a 400 error with a message "Game was not successfully added"


        // Build a feature that shows you the release date of games.



    }
}
