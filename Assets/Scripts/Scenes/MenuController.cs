using Assets.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuController : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void HostGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void JoinGame()
    {
        _gameManager.IsHost = false;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
