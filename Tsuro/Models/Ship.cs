using System;

namespace Tsuro.Models
{
    public class Ship
    {
        public Coordinates CardCoordinates;
        public byte CardPoint;  // 0 - left on top edge, 1 - right on top edge, 2 - top on right edge, etc...

        public bool OutOfBounds => CardCoordinates.X < 0
                                   || CardCoordinates.X > 5
                                   || CardCoordinates.Y < 0
                                   || CardCoordinates.Y > 5;

        public void MoveToPoint(byte destinationCardPoint)
        {
            switch (destinationCardPoint)
            {
                case 0:
                case 1:
                    CardCoordinates.Y--;
                    CardPoint = (byte)(5 - destinationCardPoint);
                    return;
                case 2:
                case 3:
                    CardCoordinates.X++;
                    CardPoint = (byte)(9 - destinationCardPoint);
                    return;
                case 4:
                case 5:
                    CardCoordinates.Y++;
                    CardPoint = (byte)(5 - destinationCardPoint);
                    return;
                case 6:
                case 7:
                    CardCoordinates.X--;
                    CardPoint = (byte)(9 - destinationCardPoint);
                    return;

            }
        }
    }
}