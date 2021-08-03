using Battleship.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Api.Model;
using Battleship.Core.Domain.ValueObjects;

namespace battleship_app.DTOs
{
    public class SimplePlayerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
    
    public class PlayerModel
    {
        public Guid Id { get; set; }
        
        public SquareState[][] Squares { get; set; }

        public int Score { get; set; }
    }
    
    public class ContextMapper
    {
        private readonly IBattleshipContext _context;

        public ContextMapper(IBattleshipContext context)
        {
            _context = context;
        }
        
        public IEnumerable<PlayerModel> MapToPlayerModel()
        {
            return new List<PlayerModel>
            {
                new PlayerModel
                {
                    Id = _context.GetGame().Players.ElementAt(0).GetId(),
                    Squares = _context.GetGame().Players.ElementAt(0).GetSquares(),
                    Score = _context.GetGame().Players.ElementAt(0).GetScore()
                },
                new PlayerModel
                {
                    Id = _context.GetGame().Players.ElementAt(1).GetId(),
                    Squares = _context.GetGame().Players.ElementAt(1).GetSquares(),
                    Score = _context.GetGame().Players.ElementAt(1).GetScore()
                }
            };
        }

        public IEnumerable<SimplePlayerModel> MapToSimplePlayerModel()
        {
            return new List<SimplePlayerModel>
            {
                new SimplePlayerModel
                {
                    Id = _context.GetGame().Players.ElementAt(0).GetId(),
                    Name = _context.GetGame().Players.ElementAt(0).GetName()
                },
                new SimplePlayerModel
                {
                    Id = _context.GetGame().Players.ElementAt(1).GetId(),
                    Name = _context.GetGame().Players.ElementAt(1).GetName()
                }
            };
        }
    }
}