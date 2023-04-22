using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    public Card(CardDefinition cardDefinition)
    {
        CardDefinition = cardDefinition;
        CardActionsOnPlay = new List<ICardAction>();
        foreach (ICardActionDefinition actionDefOnPlay in CardDefinition.ActionsOnPlay)
        {
            CardActionsOnPlay.Add(new BaseCardAction(this, actionDefOnPlay));
        }
    }
    public List<ICardAction> CardActionsOnPlay { get; private set; }
    public CardDefinition CardDefinition { get; private set; }
    public Player PlayerOwner { get; private set; }
    public CardState State { get;private set; }

    public void ChangeOwner(Player player)
    {
        PlayerOwner = player;
    }

    public void SetState(CardState state)
    {
        State = state;
    }
}

public enum CardState
{
    InDeck,
    InHand,
    InDiscard,
    InGame
}
