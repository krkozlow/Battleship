using System;
using System.Collections.Generic;
using Battleship.Api.Model;
using Battleship.Core.Domain.ValueObjects;
using battleship_app.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace battleship_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipController
    {
        private readonly IBattleshipContext _battleshipContext;

        public BattleshipController(IBattleshipContext battleshipContext)
        {
            _battleshipContext = battleshipContext;
        }
        
        [HttpPost("StartGame/{sizeX}/{sizeY}")]
        public IEnumerable<SimplePlayerModel> StartGame([FromRoute] int sizeX, [FromRoute] int sizeY)
        {
            _battleshipContext.SetGame(sizeX, sizeY);

            var result = new ContextMapper(_battleshipContext).MapToSimplePlayerModel();

            return result;
        }

        [HttpPut("Shoot/{x}/{y}")]
        public IEnumerable<PlayerModel> Shoot([FromRoute] int x, [FromRoute] int y)
        {
            _battleshipContext.Shoot(x, y);

            var result = new ContextMapper(_battleshipContext).MapToPlayerModel();

            return result;
        }
    }
}
