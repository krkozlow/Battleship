using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;

namespace Battleship.Core.Domain
{
    public class TwoPlayerGameFactory : IGameFactory
    {
        private readonly IShipOnGridSquareGenerator _squareGenerator;

        public TwoPlayerGameFactory(IShipOnGridSquareGenerator squareGenerator)
        {
            _squareGenerator = squareGenerator;
        }

        public Game Create(int sizeX, int sizeY)
        {
            var firstPlayer = CreatePlayerBuiler("First player", sizeX, sizeY).Build();
            var secondPlayer = CreatePlayerBuiler("Second player", sizeX, sizeY).Build();

            return new Game
            {
                Id = Guid.NewGuid(),
                Players = new List<Player> { firstPlayer, secondPlayer }
            };
        }

        private IPlayerBuilder CreatePlayerBuiler(string playerName, int sizeX, int sizeY)
        {
            var playerId = Guid.NewGuid();
            var shipPoints = GenerateFourShipPoints(playerId, sizeX, sizeY);
            return new PlayerBuilder()
                .AddPlayer(playerId, playerName)
                .AddGrid(sizeX, sizeY)
                .AddShip(new ValueObjects.Battleship(shipPoints[0].Item1, shipPoints[0].Item2, shipPoints[0].Item3))
                .AddShip(new Carrier(shipPoints[1].Item1, shipPoints[1].Item2, shipPoints[1].Item3))
                .AddShip(new Destroyer(shipPoints[2].Item1, shipPoints[2].Item2, shipPoints[2].Item3))
                .AddShip(new Cruiser(shipPoints[3].Item1, shipPoints[3].Item2, shipPoints[3].Item3))
                .AddShip(new Submarine(shipPoints[4].Item1, shipPoints[4].Item2, shipPoints[4].Item3));
        }

        private IList<(ShipDirection, int, int)> GenerateFourShipPoints(Guid playerId, int sizeX, int sizeY)
        {
            var result = new List<(ShipDirection, int, int)>();
            for (int i = 0; i < 5; i++)
            {
                result.Add(_squareGenerator.Generate(playerId, sizeX, sizeY));
            }

            return result;
        }
    }
}