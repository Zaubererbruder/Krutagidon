using System.Collections.Generic;
using System.Collections.ObjectModel;

public abstract class Player : ITarget
{
    protected List<Stat> _stats = new List<Stat>();
    protected Deck _deck = new Deck();
    protected ObservableCollection<Card> _hand = new ObservableCollection<Card>();
    protected List<Card> _playedCards = new List<Card>();
    protected ObservableCollection<Card> _discard = new ObservableCollection<Card>();
    
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlyList<Stat> Stats => _stats;
    public Deck Deck => _deck;
    public ObservableCollection<Card> Hand => _hand;
    public ObservableCollection<Card> Discard => _discard;

    public abstract void Init();
    public abstract void Start();
    public abstract void PlayCard(Card card, ITarget target);

    protected int GetStat(int index)
    {
        if (_stats.Count > index)
            return Stats[0].Value;
        
        return 0;
    }
}

