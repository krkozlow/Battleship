using Battleship.Core.Domain;
using Battleship.Core.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Battleship.Core.Application.Domain
{
    public class ShipOnGridSquareGenerator : IShipOnGridSquareGenerator
    {
        private IDictionary<Guid, IList<(int, int)>> playerShipInitCoordinates = new Dictionary<Guid, IList<(int, int)>>();
        private Random random = new Random();
        
        public (ShipDirection direction, int x, int y) Generate(Guid playerId, int sizeX, int sizeY)
        {
            if (!playerShipInitCoordinates.ContainsKey(playerId))
            {
                playerShipInitCoordinates.Add(playerId, new Collection<(int, int)>());
            }

            var randomY = 0;
            do
            {
                randomY = random.Next(0, sizeY);
                
            } while (playerShipInitCoordinates[playerId].Any(x => x.Item2 == randomY));
            
            playerShipInitCoordinates[playerId].Add((0, randomY));

            return (ShipDirection.Horizontal, 0, randomY);
        }
    }
}