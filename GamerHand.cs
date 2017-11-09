using System;
using System.Collections.Generic;

namespace Coinche.Game
{
    public class GamerHand
    {
        private List<Card> _hand = new List<Card>();

        public GamerHand()
        {
        }

        public List<Card> GetHand()
        {
            return _hand;
        }

        public void addHand(Card card)
        {
            _hand.Add(card);
        }

        public void delHand()
        {
            _hand.Clear();
        }

        public void showHand()
        {
            var i = 1;
            
            Console.WriteLine("********************");
            Console.WriteLine("Votre main:");
            foreach (var hand in _hand)
            {
                if (!hand.getPlayed() && i < 9)
                    Console.Write(i + ") " + hand.valueToString() + " " + hand.colorToString() + " | ");
                ++i;
            }
            Console.WriteLine();
            Console.WriteLine("********************");
        }

        public void playCard(Card card)
        {
            foreach (var hand in _hand)
            {
                if (hand.getValue() == card.getValue() && hand.getColor() == card.getColor())
                {
                    hand.setPlayed(true);
                }
            }
        }
    }
}