using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;
using System;

namespace Battleship.Core.Domain
{
    public interface IPlayerBuilder
    {
        Player Build();

        IPlayerBuilder AddPlayer(Guid id, string name);

        IPlayerBuilder AddGrid(int sizeX, int sizeY);

        IPlayerBuilder AddShip(Ship ship);
    }
}