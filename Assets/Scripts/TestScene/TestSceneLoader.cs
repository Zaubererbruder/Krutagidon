using Assets.Scripts.TestScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneLoader : MonoBehaviour
{
    public List<Player> Players = new List<Player>();
    public Game Game;
    [SerializeField] public PlayerView Player1Beh;
    [SerializeField] public PlayerView Player2Beh;
    [SerializeField] public UIManager UIManager;
    [SerializeField] private PlayedCardsView _playedCardsView;

    private void Awake()
    {
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Players.Add(player1);
        Players.Add(player2);
        Game = new Game(Players);
        Game.Init();

        Player1Beh.Init(player1);
        Player2Beh.Init(player2);

        UIManager.Init(Game.GameBoard);
        _playedCardsView.Init(Game.GameBoard.CardsOnPlay);
    }

    private void Start()
    {
        Game.Start();
    }
}
