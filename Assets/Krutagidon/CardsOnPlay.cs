using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CardsOnPlay
{
    private List<Card> _cardsList;

    public CardsOnPlay()
    {
        _cardsList = new List<Card>();
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public void PlayCard(Card card)
    {
        _cardsList.Add(card);
        CollectionChanged?.Invoke(this, 
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
    }

    public void DiscardCards()
    {
        for (int i = 0; i < _cardsList.Count;)
        {
            Card card = _cardsList[i];
            //if Постоянка
            card.PlayerOwner.Discard.Add(card);
            _cardsList.RemoveAt(i);
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, card));
        }
    }
}
