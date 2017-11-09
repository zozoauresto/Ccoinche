using System.Collections.Generic;
using Coinche.Game;

namespace Coinche.State
{
    public class State
    {
        private static Package _coinche;
        private static readonly List<Card> _cards = new List<Card>();
        private static int _pointsTeam1;
        private static int _pointsTeam2;
        private static int _totalTeam1;
        private static int _totalTeam2;
        private static int _biggerValue;
        private static int _biggerColor;
        private static int _round;
        private static int _pointsRound;
        private static int _bet;
        private static int _color;
        private static int _turn;
        private static int _leader;
        protected static readonly bool[] _ok = new bool[4];
        private static bool _over;

        protected State()
        {
            _totalTeam1 = 0;
            _totalTeam2 = 0;
            _over = false;
            _ok[0] = false;
            _ok[1] = false;
            _ok[2] = false;
            _ok[3] = false;
            _coinche = new Package();
            _turn = 0;
            _biggerColor = -1;
            _biggerValue = -1;
            _pointsRound = 0;
            _leader = 0;
        }


        protected static int getPointsTeam1()
        {
            return _pointsTeam1;
        }

        protected static int getPointsTeam2() 
        {
            return _pointsTeam2;
        }

        protected void setPointsTeam1(int nb) {
            _pointsTeam1 = nb;
        }

        protected void setPointsTeam2(int nb) {
            _pointsTeam2 = nb;
        }

        protected static void setOver(bool f) { _over = f; }

        public bool getOver() { return _over; }

        protected static Package getCoinche() { return _coinche; }

        protected static int getTurn() {
            return _turn;
        }

        protected static void setTurn(int _turn) {
            State._turn = _turn;
        }

        protected static int getColor() {
            return _color;
        }

        protected static void setColor(int _color) {
            State._color = _color;
        }

        protected static int getBet() {
            return _bet;
        }

        protected static void setBet(int _color) {
            _bet = _color;
        }

        protected static List<Card> getCards() { return _cards; }

        protected static int getRound() {
            return _round;
        }

        protected static void setRound(int _round) {
            State._round = _round;
        }

        protected static int getBiggerValue() {
            return _biggerValue;
        }

        protected static void setBiggerValue(int _biggerValue) {
            State._biggerValue = _biggerValue;
        }

        protected static int getBiggerColor() {
            return _biggerColor;
        }

        protected static void setBiggerColor(int _biggerColor) {
            State._biggerColor = _biggerColor;
        }

        protected static int getPointsRound() {
            return _pointsRound;
        }

        protected static void setPointsRound(int _pointsRound) {
            State._pointsRound = _pointsRound;
        }

        protected static int getLeader() {
            return _leader;
        }

        protected static void setLeader(int _leader) {
            State._leader = _leader;
        }

        protected static int getTotalTeam1() { return _totalTeam1; }

        protected static int getTotalTeam2() { return _totalTeam2; }

        protected static void setTotalTeam1(int nb) { _totalTeam1 = nb;}

        protected static void setTotalTeam2(int nb) { _totalTeam2 = nb;}

        protected static void addHand(Card card)
        {
            _cards.Add(card);
        }

        protected void delHand()
        {
            _cards.Clear();
        }
        
        public static void push(Game.Game g)
        {
            _leader = 0;
            _over = false;
            g.setInstance(Deal.instance());
        }
        
        public void action()
        {
            if (_pointsTeam1 > _pointsTeam2)
                _totalTeam1 += _bet;
            else
                _totalTeam2 += _bet;

            _pointsTeam2 = 0;
            _pointsTeam1 = 0;
            _bet = 0;
            _color = 0;
            _turn = 0;
            _cards.Clear();
            _over = true;
        }
    }
}