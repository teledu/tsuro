using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsuro.Models
{
    public class Board
    {
        public Board()
        {
            BoardCards = new Card[6, 6];
        }

        public Card[,] BoardCards;

        public Ship[] Ships;


        public void PlaceCard(Card card, Coordinates coordinates)
        {
            BoardCards[coordinates.X, coordinates.Y] = card;
            MoveShips(coordinates);
        }

        private void MoveShips(Coordinates fromCard)
        {
            var shipsToMove = Ships.Where(s => s.CardCoordinates == fromCard);
            foreach (var ship in shipsToMove)
            {
                //move ship;
            }
        }
    }

    public class Ship
    {
        public Coordinates CardCoordinates;
        public byte CardPoint;
    }
}
