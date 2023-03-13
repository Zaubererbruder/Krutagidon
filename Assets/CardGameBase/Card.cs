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
    }

    public CardDefinition CardDefinition { get; private set; }
    public Player Owner { get; private set; }

    public void ChangeOwner(Player player)
    {
        Owner = player;
    }

    public void Play(Player cardOwner, ITarget target)
    {
        CardDefinition.ActivateCard(cardOwner, target);
    }
}

