using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
/*
    Carrier	5
    2	Battleship	4
    3	Cruiser	3
    4	Submarine	3
    5	Destroyer 2
*/
namespace Battleship.Core.Domain.ValueObjects
{
    public abstract class Ship
    {
        public ShipDirection Direction { get; protected set; }


        public ShipState State { get; protected set; }
        
        public int Size { get; protected set; }

        public int InitX { get; protected set; }

        public int InitY { get; protected set; }

        public IEnumerable<(int, int)> GetCoordaintes()
        {
            var coordinates = new List<(int, int)>();
            if (Direction == ShipDirection.Horizontal)
            {
                for (int i = 0; i < Size; i++)
                {
                    coordinates.Add((InitX + i, InitY));
                }
            }
            if (Direction == ShipDirection.Vertical)
            {
                for (int i = 0; i < Size; i++)
                {
                    coordinates.Add((InitX, InitY + i));
                }
            }

            return coordinates;
        }

        public (int, int) GetMaxCoordinates()
        {
            if (Direction == ShipDirection.Horizontal)
            {
                return GetCoordaintes().OrderBy(x => x.Item1).First();
            }
            if (Direction == ShipDirection.Vertical)
            {
                return GetCoordaintes().OrderBy(x => x.Item2).First();
            }

            throw new ArgumentException();
        }

        public (int, int) GetMinCoordinates()
        {
            if (Direction == ShipDirection.Horizontal)
            {
                return GetCoordaintes().OrderByDescending(x => x.Item1).First();
            }
            if (Direction == ShipDirection.Vertical)
            {
                return GetCoordaintes().OrderByDescending(x => x.Item2).First();
            }

            throw new ArgumentException();
        }
    }

    public class Battleship : Ship
    {
        public Battleship(ShipDirection direction, int initX, int initY)
        {
            InitX = initX;
            InitY = initY;
            Direction = direction;
            Size = 2;
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer(ShipDirection direction, int initX, int initY)
        {
            InitX = initX;
            InitY = initY;
            Direction = direction;
            Size = 2;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser(ShipDirection direction, int initX, int initY)
        {
            InitX = initX;
            InitY = initY;
            Direction = direction;
            Size = 2;
        }
    }

    public class Submarine : Ship
    {
        public Submarine(ShipDirection direction, int initX, int initY)
        {
            InitX = initX;
            InitY = initY;
            Direction = direction;
            Size = 2;
        }
    }

    public class Carrier : Ship
    {
        public Carrier(ShipDirection direction, int initX, int initY)
        {
            InitX = initX;
            InitY = initY;
            Direction = direction;
            Size = 2;
        }
    }

    public enum ShipDirection
    {
        Horizontal,
        Vertical
    }

    public enum ShipState
    {
        New,
        Destroyed
    }
}