using Battleship.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Core.Domain.ValueObjects;

namespace battleship_app.DTOs
{
    public class PlayersModel
    {
        public IEnumerable<PlayerModel> Players { get; set; }
    }

    public class PlayerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public GridModel Grid { get; set; }
    }

    public class GridModel
    {
        public int SizeX { get; set; }

        public int SizeY { get; set; }
        public SquareState[][] Squares { get; set; }
    }
}