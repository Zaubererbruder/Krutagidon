
using Assets.Krutagidon;
using System.Collections.Generic;

public class Game
{
    private List<Player> _players;
    private ITurnManager _turnManager;
    private GameBoard _gameBoard;
    private StarterCardDistributor _starterCardDistributor;

    public Game(List<Player> players)
    {
        _players = players;
        KrutagidonCards.InitCards();
        _starterCardDistributor = new StarterCardDistributor(_players);
        UseDefaultTurnManager();
        _gameBoard = new GameBoard(_players, _turnManager);
    }

    public ITurnManager TurnManager => _turnManager;
    public GameBoard GameBoard => _gameBoard;

    public void InitTurnManager(ITurnManager turnManager)
    {
        _turnManager = turnManager;
    }

    public void UseDefaultTurnManager()
    {
        _turnManager = new TurnManager();
    }

    public void Init()
    {
        foreach (var player in _players)
        {
            player.Init();
        }
        _starterCardDistributor.Distribute();
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
