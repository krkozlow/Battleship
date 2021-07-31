using System;
using System.Text;

namespace Battleship.Core.Domain.ValueObjects
{
    public class Grid
    {
        private const int MIN_GRID_SIZE = 2;
        private SquareState[,] _squares;
        public readonly int _sizeX;
        public readonly int _sizeY;

        public Grid(int sizeX, int sizeY)
        {
            Guard(sizeX, sizeY);

            _sizeX = sizeX;
            _sizeY = sizeY;
            _squares = new SquareState[_sizeX, _sizeY];
        }

        public SquareState this[int x, int y]
        {
            get { return _squares[x, y]; }
            set { _squares[x, y] = value; }
        }

        public (int, int) GetGridSize()
        {
            return (_sizeX, _sizeY);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    builder.Append(_squares[i, j]);
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        private void Guard(int sizeX, int sizeY)
        {
            if (sizeX < MIN_GRID_SIZE || sizeY < MIN_GRID_SIZE)
            {
                throw new InvalidGridException();
            }
        }
    }

    public enum SquareState
    {
        Empty,
        Missed,
        OnTarget
    }

    public class InvalidGridException : Exception
    {

    }
}