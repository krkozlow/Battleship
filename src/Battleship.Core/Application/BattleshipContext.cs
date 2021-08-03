using System.Linq;
using Battleship.Api.Model;
using Battleship.Core.Domain;
using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;

namespace Battleship.Core.Application
{
    public class BattleshipContext : IBattleshipContext
    {
        private readonly IGameFactory _gameFactory;
        private Game _game;
        private Player _currentPlayer;
        private static object SyncObject = new object();

        public BattleshipContext(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void SetGame(int sizeX, int sizeY)
        {
            if (_game == null)
            {
                lock (SyncObject)
                {
                    if (_game == null)
                    {
                        _game = _gameFactory.Create(sizeX, sizeY);
                        _currentPlayer = _game.Players.First();
                    }
                }
            }
        }

        public Game GetGame()
        {
            return _game;
        }

        public void NextPlayer()
        {
            if (_currentPlayer.GetId() == _game.Players.First().GetId())
            {
                _currentPlayer = _game.Players.Last();
            }
            else
            {
                _currentPlayer = _game.Players.First();
            }
        }

        public void Shoot(int x, int y)
        {
            var shootResult = _currentPlayer.Shoot(x, y);
            if (shootResult == SquareState.Missed)
            {
                NextPlayer();
            }
            else
            {
                _currentPlayer.UpdateScore();
            }
        }
    }
}