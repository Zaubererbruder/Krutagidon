using System;
using System.Collections.Generic;

public class TurnManager : ITurnManager
{
    private List<Player> _players;
    private int _currentIndex;

    public TurnManager()
    {
        _players = new List<Player>();
        _currentIndex = 0;
    }

    public event Action TurnChanged;

    public Player CurrentPlayer => _players[_currentIndex];

    public void EndTurn()
    {
        _currentIndex = (_currentIndex + 1) % _players.Count;
        TurnChanged?.Invoke();
    }

    public void Init(List<Player> players)
    {
        Reset(players, 0);
    }

    public void Reset(List<Player> players, int startIndex = 0)
    {
        _players = players;
        _currentIndex = startIndex;
        TurnChanged?.Invoke();
    }
}

