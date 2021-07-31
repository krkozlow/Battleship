using System;

namespace Battleship.Core.Application.Domain
{
    public interface IShipOnGridSquareGenerator
    {
        (ShipDirection direction, int x, int y) Generate(Guid playerId, int sizeX, int sizeY);
    }
}