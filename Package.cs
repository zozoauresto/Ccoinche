using System;
using System.Collections.Generic;

namespace Coinche.Game
{
    public class Package
    {
        private List<Card> _package = new List<Card>();
        private static Random rng = new Random();

        public Package()
        {
            var i = 0;

            while (i < 4)
            {
                var j = 0;
                while (j < 8)
                {
                    _package.Add(new Card(i, j));
                    ++j;
                }
                ++i;
            }
        }

        public List<Card> getPackage()
        {
            return _package;
        }

        public void deal()
        {
            int n = getPackage().Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _package[k];
                _package[k] = _package[n];
                _package[n] = value;
            }
        }
    }
}
    
