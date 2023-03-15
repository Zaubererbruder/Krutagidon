using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameBoard
{
    private List<Player> _players = new List<Player>();
    private ITurnManager _turnManager;
    private ActionsPool _actionsPool;
    private List<Card> _playedCards;
    //MainDeck
    //Shop

    public GameBoard(List<Player> players, ITurnManager turnManager)
    {
        _players = players;
        _turnManager = turnManager;
        _actionsPool = new ActionsPool();
        _playedCards = new List<Card>();
    }

    public ActionsPool ActionsPool => _actionsPool;

    public void PlayCard(Card card)
    {
        ActionsPool.Add(card.CardActionsOnPlay.ToArray());
        card.PlayerOwner.PlayCard(card);
        _playedCards.Add(card);
    }

    public bool CanPlayCard(Card card)
    {
        return true;
    }
}
