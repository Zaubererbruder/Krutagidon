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
    private CardsOnPlay _cardsOnPlay;
    //MainDeck
    //Shop

    public GameBoard(List<Player> players, ITurnManager turnManager)
    {
        _players = players;
        _turnManager = turnManager;
        _actionsPool = new ActionsPool();
        _cardsOnPlay = new CardsOnPlay();
    }

    public ActionsPool ActionsPool => _actionsPool;
    public Player CurrentPlayer => _turnManager.CurrentPlayer;
    public CardsOnPlay CardsOnPlay => _cardsOnPlay;

    public event Action TurnChanged;

    public void EndTurn()
    {
        _cardsOnPlay.DiscardCards();
        CurrentPlayer.DiscardHand();
        CurrentPlayer.ResetPower();
        CurrentPlayer.GetCardsFromDeck(5);
        _turnManager.EndTurn();
        TurnChanged?.Invoke();
    }

    public void PlayCard(Card card)
    {
        ActionsPool.Add(card.CardActionsOnPlay.ToArray());
        CurrentPlayer.PlayCard(card);
        _cardsOnPlay.PlayCard(card);
    }

    public bool CanPlayCard(Card card)
    {
        if (CurrentPlayer != card.PlayerOwner)
            return false;

        return true;
    }
}
