using System;
using System.Collections.Generic;

public class CardViewsPool
{
    private Dictionary<Card, CardView> _pool = new Dictionary<Card, CardView>();

    public void Add(Card card, CardView cardView)
    {
        _pool.Add(card, cardView);
    }

    public CardView Get(Card card)
    {
        if (_pool.ContainsKey(card))
        {
            return _pool[card];
        }

        throw new NotImplementedException();
    }

    public bool TryGet(Card card, out CardView cardView)
    {
        return _pool.TryGetValue(card, out cardView);
    }

    public bool Contains(Card card)
    {
        return _pool.ContainsKey(card);
    }
}
