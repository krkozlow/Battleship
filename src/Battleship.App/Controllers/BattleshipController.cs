using System;
using Battleship.Core.Domain.ValueObjects;
using battleship_app.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace battleship_app.Controllers
{
    public class BattleshipController
    {
        [HttpPost("StartGame")]
        public IActionResult StartGame([FromQuery] int sizeX, [FromQuery] int sizeY)
        {
            var firstPlayer = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = "First player",
                Grid = new GridModel
                {
                    Squares = new[,]
                    {
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            };

            var secondPlayer = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = "First player",
                Grid = new GridModel
                {
                    Squares = new[,]
                    {
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            };

            return new OkObjectResult(new PlayersModel
            {
                Players = new []
                {
                    firstPlayer,
                    secondPlayer
                }
            });
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
                    Squares = new [,]
                    {
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty},
                        {SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty, SquareState.Empty}
                    }
                }
            });
        }
    }
}
