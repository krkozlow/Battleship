using Battleship.Core.Domain.ValueObjects;
using System;

namespace Battleship.Core.Domain
{
    public interface IShipOnGridSquareGenerator
    {
        (ShipDirection direction, int x, int y) Generate(Guid playerId, int sizeX, int sizeY);
    }
}