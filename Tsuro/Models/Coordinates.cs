using System;

namespace Tsuro.Models
{
    public class Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int x, int y)
        {
            if (x < 0 || x> 5)
                throw new IndexOutOfRangeException($"X value out of range");
            if (y < 0 || y > 5)
                throw new IndexOutOfRangeException($"Y value out of range");
            X = x;
            Y = y;
        }
    }
}