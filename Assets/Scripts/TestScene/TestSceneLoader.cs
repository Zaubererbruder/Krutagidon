using Assets.Scripts.TestScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneLoader : MonoBehaviour
{
    public List<KrutagidonPlayer> Players = new List<KrutagidonPlayer>();
    public KrutagidonGame KrutagidonGame;
    [SerializeField] public PlayerTestBeh Player1Beh;
    [SerializeField] public PlayerTestBeh Player2Beh;
    [SerializeField] public TurnBeh TurnBeh;

    private void Awake()
    {
        KrutagidonPlayer player1 = new KrutagidonPlayer("Player 1");
        KrutagidonPlayer player2 = new KrutagidonPlayer("Player 2");
        Players.Add(player1);
        Players.Add(player2);
        KrutagidonGame = new KrutagidonGame(Players);
        KrutagidonGame.Init();

        Player1Beh.Init(player1);
        Player2Beh.Init(player2);

        TurnBeh.Init(KrutagidonGame.TurnManager as TurnManager<KrutagidonPlayer>);
    }

    private void Start()
    {
        KrutagidonGame.Start();
    }
}
