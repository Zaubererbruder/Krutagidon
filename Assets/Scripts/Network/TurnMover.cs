using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Network
{
    public class TurnMover : NetworkBehaviour
    {
        private IDebugger _debugger;
        private Server _server;
        private int _indexOfPlayer;

        [Inject]
        public void Construct(Server server, IDebugger debugger)
        {
            _server = server;
            _debugger = debugger;
        }

        public Player CurrentPlayer => _server.Players[_indexOfPlayer];

        //public override void OnNetworkSpawn()
        //{
        //    if(IsServer)
        //        _server.GameStarted += OnGameStarted;
        //}

        //public override void OnNetworkDespawn()
        //{
        //    if (IsServer)
        //        _server.GameStarted -= OnGameStarted;
        //}

        public void OnGameStarted()
        {
            if (!IsServer)
                return;

            _indexOfPlayer = 0;
            _debugger.ChangeMessage("CurrentTurn", _indexOfPlayer.ToString());
            SendCurrentTurnInfoMessageClientRpc(_indexOfPlayer);
        }

        [ClientRpc]
        private void SendCurrentTurnInfoMessageClientRpc(int playerIndex)
        {
            if (IsServer)
                return;

            _indexOfPlayer = playerIndex;
            _debugger.ChangeMessage("CurrentTurn", _indexOfPlayer.ToString());
        }

        [ServerRpc(RequireOwnership = false)]
        private void EndTurnOnServerRpc()
        {
            _indexOfPlayer = (_indexOfPlayer + 1) % _server.Players.Count;
            _debugger.ChangeMessage("CurrentTurn", _indexOfPlayer.ToString());
            SendCurrentTurnInfoMessageClientRpc(_indexOfPlayer);
        }

        public void EndTurn()
        {
            if(!_server.IsGameStarted)
            {
                Debug.Log("Нельзя закончить ход, игра еще не началась");
                return;
            }

            if (!CanTurnBeEndedLocal())
            {
                Debug.Log("Нельзя завершить ход");
                return;
            }
            EndTurnOnServerRpc();
        }

        public bool CanTurnBeEndedLocal()
        {
            if (NetworkManager.LocalClient.ClientId != CurrentPlayer.NetId)
                return false;

            return true;
        }
    }

    public struct TurnInfoMessage : INetworkSerializable
    {
        public int PlayerIndex;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            throw new NotImplementedException();
        }
    }
}
