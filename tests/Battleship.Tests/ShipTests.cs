using System.Collections.Generic;
using Battleship.Core.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class ShipTests
    {
        [Fact]
        public void ShipTests_GetCoordinatesForHorizontalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Horizontal, 0, 0);

            var coordinates = ship.GetCoordaintes();
            var expectedCoordinates = new List<(int, int)>
            {
                (0, 0),
                (1, 0)
            };

            coordinates.Should().Equal(expectedCoordinates);
        }
        
        [Fact]
        public void ShipTests_GetCoordinatesForVerticalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Vertical, 0, 0);

            var coordinates = ship.GetCoordaintes();
            var expectedCoordinates = new List<(int, int)>
            {
                (0, 0),
                (0, 1)
            };

            coordinates.Should().Equal(expectedCoordinates);
        }
        
        [Fact]
        public void ShipTests_GetMaxCoordinatesForVerticalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Vertical, 0, 0);

            var coordinates = ship.GetMaxCoordinates();
            var expectedCoordinates = (0, 0);

            coordinates.Should().Be(expectedCoordinates);
        }
        
        [Fact]
        public void ShipTests_GetMinCoordinatesForVerticalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Vertical, 0, 0);

            var coordinates = ship.GetMinCoordinates();
            var expectedCoordinates = (0, 1);

            coordinates.Should().Be(expectedCoordinates);
        }
        
        [Fact]
        public void ShipTests_GetMaxCoordinatesForHorizontalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Horizontal, 0, 0);

            var coordinates = ship.GetMaxCoordinates();
            var expectedCoordinates = (0, 0);

            coordinates.Should().Be(expectedCoordinates);
        }
        
        [Fact]
        public void ShipTests_GetMinCoordinatesForHorizontalDestroyer()
        {
            Ship ship = new Destroyer(ShipDirection.Horizontal, 0, 0);

            var coordinates = ship.GetMinCoordinates();
            var expectedCoordinates = (1, 0);

            coordinates.Should().Be(expectedCoordinates);
        }
    }
}