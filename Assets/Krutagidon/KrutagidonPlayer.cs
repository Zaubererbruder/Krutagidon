using System;
using System.Collections.Generic;

public class KrutagidonPlayer : Player
{

    public KrutagidonPlayer(string name) : base(name)
    {
        
    }

    public event Action HealthChanged;

    public int Health => GetStat(0);

    public override void Init()
    {
        _stats = new List<Stat>();
        _stats.Add(
            new Stat(KrutagidonStats.HealthStatType, 20)
            );
        HealthChanged?.Invoke();

        List<Card> cardsList = new List<Card>();
        cardsList.Add(
            CreateCard(KrutagidonCards.FizzleCardDefinition) 
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.FizzleCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.FizzleCardDefinition)
            );


        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );
        cardsList.Add(
            CreateCard(KrutagidonCards.GlyphCardDefinition)
            );


        cardsList.Add(
            CreateCard(KrutagidonCards.WandCardDefinition)
            );

        _deck.AddCardsToDeck(cardsList, true);
    }

    public Card CreateCard(CardDefinition definition)
    {
        Card card = new Card(definition);
        card.ChangeOwner(this);
        return card;
    }

    public override void Start()
    {
        TakeCardFromDeck(5);
    }

    public void TakeDamage(int damage)
    {
        _stats[0].ChangeValue(-damage);
        HealthChanged?.Invoke();
    }

    public void TakeCardFromDeck(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _hand.Add(_deck.DrawCard());
        }
    }

    public override void PlayCard(Card card, ITarget target)
    {
        if(!_hand.Contains(card))
        {
            throw new InvalidOperationException("You cannot play a card not in your hand");
        }

        if(card.CardDefinition.NeedTarget && target == null)
        {
            throw new InvalidOperationException("This card requires a target");
        }

        _hand.Remove(card);
        _playedCards.Add(card);

        card.Play(this, target);
    }
}
