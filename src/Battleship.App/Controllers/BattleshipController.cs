using System;
using System.Collections.Generic;
using Battleship.Core.Domain.ValueObjects;
using battleship_app.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace battleship_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipController
    {
        [HttpPost("StartGame")]
        public PlayersModel StartGame([FromQuery] int sizeX, [FromQuery] int sizeY)
        {
            var firstPlayer = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = "First player",
                Grid = new GridModel
                {
                    SizeX = 10,
                    SizeY = 10,
                    Squares = new[]
                    {
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            };

            var secondPlayer = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = "First player",
                Grid = new GridModel
                {
                    SizeX = 10,
                    SizeY = 10,
                    Squares = new[]
                    {
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            };

            return new PlayersModel
            {
                Players = new []
                {
                    firstPlayer,
                    secondPlayer
                }
            };
        }

        [HttpPut("Shoot")]
        public IActionResult Shoot([FromQuery] int x, [FromQuery] int y)
        {
            return new OkObjectResult(new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = "First player",
                Grid = new GridModel
                {
                    SizeX = 10,
                    SizeY = 10,
                    Squares = new[]
                    {
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        new []{SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            });
        }
    }
}
