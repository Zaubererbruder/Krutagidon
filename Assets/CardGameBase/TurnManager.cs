using System;
using System.Collections.Generic;

public class TurnManager<TPlayer> : ITurnManager<TPlayer> where TPlayer : Player
{
    private List<TPlayer> _players = new List<TPlayer>();
    private int _currentIndex;

    public TurnManager()
    {

    }

    public event Action TurnChanged;

    public TPlayer CurrentPlayer => _players[_currentIndex];

    public void NextTurn()
    {
        _currentIndex = (_currentIndex + 1) % _players.Count;
        //CurrentPlayer = _players[_currentIndex];
        TurnChanged?.Invoke();
    }

    public void Init(List<TPlayer> players)
    {
        Reset(players, 0);
    }

    public void Reset(List<TPlayer> players, int startIndex = 0)
    {
        _players = players;
        _currentIndex = startIndex;
        TurnChanged?.Invoke();
    }
}

