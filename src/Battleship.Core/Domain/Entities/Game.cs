using Battleship.Core.Application.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace battleship_app.Model.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}