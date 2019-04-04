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
            // 0;0 - top left
            // 0;5 - top right
            // 5;0 - bottom left
        }

        public Card[,] BoardCards;

        public List<Ship> ActiveShips;


        public void PlaceCard(Card card, Coordinates coordinates)
        {
            BoardCards[coordinates.X, coordinates.Y] = card;
            RemoveColidingShips(card, coordinates);
            
            var shipsToMove = ActiveShips.Where(s => s.CardCoordinates == coordinates).ToList();
            foreach (var ship in shipsToMove)
            {
                MoveShip(ship);
            }
        }

        private void MoveShip(Ship ship)
        {
            var card = BoardCards[ship.CardCoordinates.Y, ship.CardCoordinates.X];
            ship.MoveToPoint(card.Connections[ship.CardPoint]);

            if (ship.OutOfBounds)
            {
                ActiveShips.Remove(ship);
                return;
            }

            if (BoardCards[ship.CardCoordinates.Y, ship.CardCoordinates.X] != null)
            {
                MoveShip(ship);
            }
        }

        private void RemoveColidingShips(Card card, Coordinates coordinates)
        {
            var shipsToMove = ActiveShips.Where(s => s.CardCoordinates == coordinates).ToList();

            foreach (var cardUniqueConnection in card.UniqueConnections)
            {
                var leftShip = shipsToMove.FirstOrDefault(s => s.CardPoint == cardUniqueConnection.Key);
                if (leftShip == null)
                    continue;

                var rightShip = shipsToMove.FirstOrDefault(s => s.CardPoint == cardUniqueConnection.Value);
                if (rightShip == null)
                    continue;
                
                ActiveShips.Remove(leftShip);
                ActiveShips.Remove(rightShip);
            }
        }
    }
}
