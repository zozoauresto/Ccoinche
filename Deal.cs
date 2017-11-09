namespace Coinche.State
{
    public class Deal : State
    {
        private static readonly Deal _instance = new Deal();

        private Deal()
        {
        }

        public static State instance()
        {
            return _instance;
        }

        public void push(Game.Game g)
        {
            setOver(false);
            g.setInstance(Bet.instance());
        }

        public void action()
        {
            getCoinche().deal();

            var client = 0;
            var nbrCard = 0;

            foreach (var card in getCoinche().getPackage())
            {
                ++nbrCard;
                if (nbrCard % 8 == 0 && nbrCard != 0)
                    ++client;
                if (client > 3)
                    break;
            }
            setOver(true);
        }
    }
}