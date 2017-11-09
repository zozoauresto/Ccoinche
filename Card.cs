using System;

namespace Coinche.Game
{
    public class Card
    {
        private readonly int _color;
        private readonly int _value;
        private bool _played;

        public Card(int color, int value)
        {
            _color = color;
            _value = value;
            _played = false;
        }

        public int getColor()
        {
            return _color;
        }
        
        public int getValue() {
            return _value;
        }

        public bool getPlayed() {
            return _played;
        }

        public void setPlayed(bool _played) {
            this._played = _played;
        }

        public string valueToString()
        {
            switch (getValue())
            {
                case 0:
                    return "SEPT";
                case 1:
                    return "HUIT";
                case 2:
                    return "NEUF";
                case 3:
                    return "DIX";
                case 4:
                    return "VALET";
                case 5:
                    return "DAME";
                case 6:
                    return "ROI";
                case 7:
                    return "AS";
                default:
                    return null;
            }
        }

        public string colorToString()
        {
            switch (getColor())
            {
                case 0:
                    return "COEUR";
                case 1:
                    return "CARREAU";
                case 2:
                    return "TREFLE";
                case 3:
                    return "PIQUE";
                default:
                    return null;
            }
        }
    }
}