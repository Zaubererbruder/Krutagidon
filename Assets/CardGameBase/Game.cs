using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Game<TPlayer> where TPlayer : Player
{
    private List<TPlayer> _players;
    private ITurnManager<TPlayer> _turnManager;

    public Game(List<TPlayer> players)
    {
        _players = players;
    }

    public ITurnManager<TPlayer> TurnManager => _turnManager;

    public void InitTurnManager(ITurnManager<TPlayer> turnManager)
    {
        _turnManager = turnManager;
    }

    public void UseDefaultTurnManager()
    {
        _turnManager = new TurnManager<TPlayer>();
    }

    public void Init()
    {
        foreach (var player in _players)
        {
            player.Init();
        }

        _turnManager.Init(_players);
    }

    public virtual void Start()
    {
        foreach (var player in _players)
        {
            player.Start();
        }
    }
}
