using battleship_app.Model.Entities;
using System.Security.Cryptography.Xml;

namespace Battleship.Core.Application.Domain
{
    public interface IGameFactory
    {
        Game Create(int sizeX, int sizeY);
    }
}