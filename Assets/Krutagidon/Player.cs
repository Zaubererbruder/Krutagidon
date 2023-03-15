using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Player
{
    private Deck _deck = new Deck();
    private ObservableCollection<Card> _hand = new ObservableCollection<Card>();
    private ObservableCollection<Card> _discard = new ObservableCollection<Card>();
    private GameBoard _gameBoard;

    public Player(string name)
    {
        Name = name;
    }

    public event Action HealthChanged;
    public event Action PowerChanged;

    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Power { get; private set; }

    public Deck Deck => _deck;
    public ObservableCollection<Card> Hand => _hand;
    public ObservableCollection<Card> Discard => _discard;

    public void Init()
    {
        Health = 20;
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

    public void Start()
    {
        TakeCardFromDeck(5);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        HealthChanged?.Invoke();
    }

    public void RaisePower(int power)
    {
        Power += power;
        PowerChanged?.Invoke();
    }

    public void TakeCardFromDeck(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _hand.Add(_deck.DrawCard());
        }
    }

    public void PlayCard(Card card)
    {
        if(!_hand.Contains(card))
        {
            throw new InvalidOperationException("You cannot play a card not in your hand");
        }

        _hand.Remove(card);
    }
}
