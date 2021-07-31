using System;
using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;

namespace Battleship.Core.Domain
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private string _playerName;
        private Guid _playerId;
        private Player _player;

        public Player Build()
        {
            return _player;
        }

        public IPlayerBuilder AddPlayer(Guid id, string name)
        {
            _playerId = id;
            _playerName = name;

            return this;
        }

        public IPlayerBuilder AddGrid(int sizeX, int sizeY)
        {
            if (_playerId == null || _playerName == null)
            {
                throw new ArgumentException($"Failed to build player. Missing name {_playerName} or id {_playerId}.");
            }
            _player = new Player(_playerId, _playerName, new Grid(sizeX, sizeY));

            return this;
        }

        public IPlayerBuilder AddShip(Ship ship)
        {
            _player.AddShip(ship);

            return this;
        }
    }
}