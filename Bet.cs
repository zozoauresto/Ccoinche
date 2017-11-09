namespace Coinche.State
{
    public class Bet : State
    {
        private static readonly Bet _instance = new Bet();

        private Bet() {}
        
        public static State instance()
        {
            return _instance;
        }

        public void push(Game.Game g)
        {
            setTurn(0);
            setOver(false);
            _ok[0] = false;
            _ok[1] = false;
            _ok[2] = false;
            _ok[3] = false;
            g.setInstance(Round.instance());
            setRound(0);
        }

        public void action()
        {
//            if (getBet() < getValueCard())
//            {
//                _ok[getTurn()] = true;
//                for (var i =0; i < 4; i++)
//                    if (i != getTurn())
//                        _ok[i] = false;
//                setBet(getValueCard());
//                setColor(getColorCard());
//
//                setTurn((getTurn() + 1) % 4);
//            }
//            else if (getValueCard() == -6)
//            {
//                _ok[getTurn()] = true;
//                setValueCard(-1);
//                setTurn((getTurn() + 1) % 4);
//                if (!(_ok[0] && _ok[1] && _ok[2] && _ok[3])) {
//                }
//            }
//            else
//            {
//            }

            if (_ok[0] && _ok[1] && _ok[2] && _ok[3])
                setOver(true);
        }

        public static string colorToString() {
            switch (getColor()) {
                case 0:
                    return "COEUR";
                case 1:
                    return "CARREAU";
                case 2:
                    return "TREFLE";
                case 3:
                    return "PIQUE";
            }
            return "";
        }

        public static int stringToColor(string color) {
            switch (color.ToUpper()) {
                case "COEUR":
                    return 0;
                case "CARREAU":
                    return 1;
                case "TREFLE":
                    return 2;
                case "PIQUE":
                    return 3;
            }
            return -1;
        }

    }
}