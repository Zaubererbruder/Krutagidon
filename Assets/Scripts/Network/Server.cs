using Assets.Scripts.Network.Factories;
using Assets.Scripts.Network.Messages;
using Assets.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Network
{
    public class Server : NetworkBehaviour
    {
        private GameManager _gameManager;

        private IPlayerFactory _playerFactory;
        private List<Player> _players = new List<Player>();
        private IDebugger _debugger;
        private TurnMover _turnMover;

        private bool _gameStarted;

        [Inject]
        public void Construct(GameManager gameManager, IPlayerFactory playerFactory, IDebugger debugger, TurnMover turnMover)
        {
            _gameManager = gameManager;
            _playerFactory = playerFactory;
            _debugger = debugger;
            _turnMover = turnMover;
        }

        public bool IsGameStarted => _gameStarted;
        public event Action PlayersListChanged;
        public event Action<bool> GameStarted;
        public IReadOnlyList<Player> Players => _players;

        private void Start()
        {
            if (_gameManager.IsHost)
            {
                HostGame();
            }
            else
            {
                JoinGame();
            }
        }

        public void HostGame()
        {
            NetworkManager.StartHost();
            _debugger.ChangeMessage("Server", "Host");
        }

        public void JoinGame()
        {
            if(!NetworkManager.StartClient())
            {
                Debug.Log("Cannot join");
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
            _debugger.ChangeMessage("Server", "Client");
        }

        public override void OnNetworkSpawn()
        {
            if (IsClient)
            {
                PlayerDataMessage playerDataMessage = new PlayerDataMessage("Player");
                SendConnectedPlayerDataServerRpc(playerDataMessage);
            }
        }



        [ServerRpc(RequireOwnership = false)]
        private void SendConnectedPlayerDataServerRpc(PlayerDataMessage playerDataMessage, ServerRpcParams serverRpcParams = default)
        {
            Player newPlayer = _playerFactory.Create(playerDataMessage, serverRpcParams.Receive.SenderClientId);
            _players.Add(newPlayer);

            ulong[] clientNetIds = _players.Where((player)=>(player.Id != 0)).Select((player) => { return player.NetId; }).ToArray(); 

            ClientRpcParams clientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = clientNetIds
                }
            };

            PlayersListChanged?.Invoke();
            SendPlayersDataClientRpc(new PlayersDataMessage(_players), clientRpcParams);

            _debugger.ChangeMessage("Players", _players.Count.ToString());
            if (_players.Count == 2)
                StartGame();
        }

        protected virtual void StartGame()
        {
            _gameStarted = true;
            GameStarted?.Invoke(IsServer);
            StartGameClientRpc();
            _turnMover.OnGameStarted();
            _debugger.ChangeMessage("Game", "Started");
        }

        [ClientRpc]
        private void StartGameClientRpc()
        {
            if (IsServer)
                return;

            _gameStarted = true;
            GameStarted?.Invoke(IsServer);
            _debugger.ChangeMessage("Game", "Started");
        }

        [ClientRpc]
        private void SendPlayersDataClientRpc(PlayersDataMessage playersDataMessage, ClientRpcParams clientRpcParams = default)
        {
            if (IsServer)
                return;

            FillPlayers(playersDataMessage);
            PlayersListChanged?.Invoke();

            _debugger.ChangeMessage("Players", _players.Count.ToString());
        }

        private void FillPlayers(PlayersDataMessage playersDataMessage)
        {
            List<Player> tempList = new List<Player>();
            for (int i = 0; i < playersDataMessage.playersIds.Length; i++)
            {
                int id = playersDataMessage.playersIds[i];
                ulong netId = playersDataMessage.playersNetIds[i];

                PlayerDataMessage playerDataMessage = playersDataMessage.players[i];

                Player existPlayer = _players.Find((p) => { return p.Id == id; });
                if (existPlayer == null)
                    existPlayer = _playerFactory.CreateExist(id, netId, playerDataMessage.Name.ToString());

                tempList.Add(existPlayer);
            }

            _players = new List<Player>(tempList);
        }

    }
}
