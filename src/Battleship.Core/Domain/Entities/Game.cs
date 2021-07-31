using System;
using System.Collections;
using System.Collections.Generic;

namespace Battleship.Core.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}