using Battleship.Core.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Core.Domain.Entities
{
    public class Player
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly Grid _grid;
        private readonly IList<Ship> _ships;
        private int _score;

        public Player(Guid id, string name, Grid grid)
        {
            _id = id;
            _name = name;
            _grid = grid;
            _ships = new List<Ship>();
        }

        public void AddShip(Ship ship)
        {
            if (!ShipIsInGrid(ship))
            {
                throw new PlayerFailedToAddShipException();
            }

            _ships.Add(ship);
        }

        public SquareState Shoot(int x, int y)
        {
            var shootResult = SquareState.Missed;
            foreach (var ship in _ships)
            {
                var shipCoordinates = ship.GetCoordaintes();
                if (shipCoordinates.Any(c => c.Equals((x, y))))
                {
                    shootResult = SquareState.OnTarget;
                    break;
                }
            }

            _grid[x, y] = shootResult;

            return shootResult;
        }

        public void UpdateScore()
        {
            ++_score;
        }
        
        public Guid GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetScore()
        {
            return _score;
        }
        
        public SquareState[][] GetSquares()
        {
            return _grid?.GetSquares();
        }
        
        private bool ShipIsInGrid(Ship ship)
        {
            var shipCoordinates = ship.GetCoordaintes();
            var max = ship.GetMaxCoordinates();
            var min = ship.GetMinCoordinates();

            return min.Item1 < _grid._sizeX
                   && min.Item2 < _grid._sizeY
                   && max.Item1 < _grid._sizeX
                   && max.Item2 < _grid._sizeY;
        }
    }

    public class PlayerFailedToAddShipException : Exception
    {

    }
}