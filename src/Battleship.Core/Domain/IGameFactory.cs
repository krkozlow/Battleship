using Battleship.Core.Domain.Entities;
using System.Security.Cryptography.Xml;

namespace Battleship.Core.Domain
{
    public interface IGameFactory
    {
        Game Create(int sizeX, int sizeY);
    }
}