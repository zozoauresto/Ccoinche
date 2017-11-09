using Coinche.Game;

namespace Coinche.State
{
    public class Round : State
    {
        private static Round _instance = new Round();
        
        private Round() {}

        public static State instance()
    {
        return _instance;
    }

    public void push(Game.Game g)
    {
        setRound(0);
        setOver(false);
        g.setInstance(Count.instance());
    }

    public void action() {
        if (getCards().Count < 4)
        {
//            var card = new Card(getColorCard(), getValueCard());
//            addHand(card);

            setTurn((getTurn() + 1) % 4);
        }

        if (getCards().Count == 4)
        {
            countPoints();
            delHand();
            setRound(getRound() + 1);
            setBiggerColor(-1);
            setBiggerValue(-1);
            setPointsRound(0);
            setTurn(getLeader());
        }
        if (getRound() != 8) return;
        if (getTurn() % 2 == 0) {
            setPointsTeam1(getPointsTeam1() + 10);
        } else {
            setPointsTeam2(getPointsTeam2() + 10);
        }
        setOver(true);
    }

    private void countPoints()
    {
        var i = getLeader();

        foreach (var card in getCards())
        {
            newLeader(card, i);
            addPointsRound(card);
            i = (i + 1) % 4;
        }
        if (getTurn() % 2 == 0) {
            setPointsTeam1(getPointsTeam1() + getPointsRound());
        } else {
            setPointsTeam2(getPointsTeam2() + getPointsRound());
        }
    }

    private static void newLeader(Card card, int player)
    {
        if (player == getLeader())
        {
            setBiggerValue(card.getValue());
            setBiggerColor(card.getColor());
            setLeader(player);
        }
        else
        {
           if (card.getColor() == getBiggerColor())
           {
               if (getBiggerColor() == getColor())
               {
                   if (card.getValue() == 4)
                   {
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else if (getBiggerValue() == 4) {
                   }
                   else if (card.getValue() == 2)
                   {
                       if (getBiggerValue() == 4) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else if (getBiggerValue() == 2)
                   {
                       if (card.getValue() != 4) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else if (card.getValue() == 3)
                   {
                       if (getBiggerValue() == 2 && getBiggerValue() == 4 && getBiggerValue() == 7) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else if (getBiggerValue() == 3)
                   {
                       if (card.getValue() != 2 && card.getValue() == 4 && card.getValue() == 7) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else
                   {
                       if (card.getValue() <= getBiggerValue()) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
               }
               else
               {
                   if (card.getValue() == 3)
                   {
                       if (getBiggerValue() == 7) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else if (getBiggerValue() == 3)
                   {
                       if (card.getValue() != 7) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
                   else
                   {
                       if (card.getValue() <= getBiggerValue()) return;
                       setBiggerValue(card.getValue());
                       setLeader(player);
                   }
               }
           }
           else
           {
               if (card.getColor() != getColor()) return;
               setBiggerValue(card.getValue());
               setBiggerColor(card.getColor());
               setLeader(player);
           }
        }
    }

    private static void addPointsRound(Card card)
    {
        switch (card.getValue())
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                if (card.getColor() == getColor())
                    setPointsRound(getPointsRound() + 14);
                break;
            case 3:
                setPointsRound(getPointsRound() + 10);
                break;
            case 4:
                if (card.getColor() == getColor())
                    setPointsRound(getPointsRound() + 20);
                else
                    setPointsRound(getPointsRound() + 2);
                break;
            case 5:
                setPointsRound(getPointsRound() + 3);
                break;
            case 6:
                setPointsRound(getPointsRound() + 4);
                break;
            case 7:
                setPointsRound(getPointsRound() + 11);
                break;
            default:
                break;
        }
    }

    }
}