using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardDefinition: ITarget
{
    public string Name { get; set; }
    protected List<Stat> Stats { get; set; } = new List<Stat>();
    protected List<CardAction> Actions { get; set; } = new List<CardAction>();
    public bool NeedTarget { get; protected set; }

    public delegate void CardAction(object sender, CardActionEventArgs e);

    public abstract void ActivateCard(Player cardOwner, ITarget target);
}
