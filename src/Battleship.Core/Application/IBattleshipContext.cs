using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;

namespace Battleship.Api.Model
{
    public interface IBattleshipContext
    {
        void SetGame(int sizeX, int sizeY);
        
        Game GetGame();

        void NextPlayer();

        void Shoot(int x, int y);
    }
}