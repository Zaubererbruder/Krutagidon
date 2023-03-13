using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Deck
{
    private Stack<Card> _cards;
    public Deck()
    {
        _cards = new Stack<Card>();
    }

    public int Count => _cards.Count;

    public event Action DeckChanged;

    public Card DrawCard()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty");
        }

        Card card = _cards.Pop();
        DeckChanged?.Invoke();
        return card;
    }

    public void Shuffle()
    {
        List<Card> shuffled = new List<Card>(_cards);

        Random rng = new Random();
        int n = shuffled.Count;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = value;
        }

        _cards = new Stack<Card>(shuffled);
        DeckChanged?.Invoke();
    }

    public void AddCardsToDeck(List<Card> cards, bool shuffle)
    {
        _cards = new Stack<Card>(cards);
        DeckChanged?.Invoke();
        if (shuffle)
            Shuffle();
    }

}
