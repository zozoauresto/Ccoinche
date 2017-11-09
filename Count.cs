namespace Coinche.State
{
    public class Count : State
    {
        private static readonly Count _instance = new Count();

        private Count() {}

        public static State instance()
        {
            return _instance;
        }
        
        public void push(Game.Game g)
        {
            setLeader(0);
            setOver(false);
            g.setInstance(Deal.instance());
        }

        public void action() 
        {
            if (getPointsTeam1() > getPointsTeam2())
                setTotalTeam1(getTotalTeam1() + getBet());
            else
                setTotalTeam2(getTotalTeam2() + getBet());

            setPointsTeam1(0);
            setPointsTeam2(0);
            setBet(0);
            setColor(0);
            setTurn(0);
            getCards().Clear();
            setOver(true);
        }

    }
}