using System.Collections.Generic;
using Tsuro.Extensions;

namespace Tsuro.Models
{
    public class Card
    {
        private readonly string _connections;

        public Card(string connections)
        {
            _connections = connections;
        }

        public Dictionary<byte, byte> Connections
        {
            get
            {
                var dictionary = new Dictionary<byte, byte>();
                var pairs = _connections.SplitIntoPairs();
                foreach (var pair in pairs)
                {
                    var end1 = byte.Parse(pair.Substring(0, 1));
                    var end2 = byte.Parse(pair.Substring(1, 1));
                    dictionary.Add(end1, end2);
                    dictionary.Add(end2, end1);
                }
                return dictionary;
            }
        }
    }
}