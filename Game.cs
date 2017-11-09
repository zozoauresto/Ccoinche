using Coinche.State;

namespace Coinche.Game
{
    public class Game
    {
        public static int NBR_END_GAME = 3000;

        private State.State _instance;

        public Game()
        {
            _instance = Deal.instance();
        }

        public void setInstance(State.State s)
        {
            _instance = s;
        }

        public State.State getInstance()
        {
            return _instance;
        }

        private void endGame(int team1, int team2)
        {
        }

        private void play() 
        {
            _instance.action();
            if (_instance.getOver())
                State.State.push(this);
        }
        
        public void push() 
        {
            State.State.push(this);
        }
    }
}