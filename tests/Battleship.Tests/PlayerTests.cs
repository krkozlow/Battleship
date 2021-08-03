using System;
using System.ComponentModel.DataAnnotations;
using Battleship.Core.Domain.Entities;
using Battleship.Core.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_AddShipInGrid()
        {
            var player = CreateValidPlayer();
            Ship ship = new Destroyer(ShipDirection.Horizontal, 0, 0);
            
            player.AddShip(ship);
        }

        [Fact]
        public void Player_OnAddShipNotInGridThrowException()
        {
            var player = CreateValidPlayer();
            Ship ship = new Cruiser(ShipDirection.Horizontal, 9, 9);
            
            Action act = () =>  player.AddShip(ship);

            act.Should().ThrowExactly<PlayerFailedToAddShipException>();
        }

        [Fact]
        public void Player_ShootOnTarget()
        {
            var player = CreateValidPlayer();
            Ship ship = new Cruiser(ShipDirection.Horizontal, 0, 0);
            player.AddShip(ship);

            player.Shoot(0, 0);

            var square = player.GetSquares()[0][0];

            square.Should().Be(SquareState.OnTarget);
        }

        [Fact]
        public void Player_MissedShot()
        {
            var player = CreateValidPlayer();
            Ship ship = new Cruiser(ShipDirection.Horizontal, 0, 0);
            player.AddShip(ship);

            player.Shoot(5, 5);

            var square = player.GetSquares()[5][5];

            square.Should().Be(SquareState.Missed);
        }
        
        private Player CreateValidPlayer()
        {
            return new Player(Guid.NewGuid(), "Player name", new Grid(10, 10));
        }
    }
}