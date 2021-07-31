using System;

namespace Battleship.Core.Application.Domain
{
    public interface IPlayerBuilder
    {
        Player Build();

        IPlayerBuilder AddPlayer(Guid id, string name);

        IPlayerBuilder AddGrid(int sizeX, int sizeY);

        IPlayerBuilder AddShip(Ship ship);
    }
}