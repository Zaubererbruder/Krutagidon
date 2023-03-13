using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class NetworkPlayer : NetworkBehaviour
    {
        [SerializeField] private ulong _ownerId;

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                _ownerId = OwnerClientId;
                AddPlayerServerRpc();
            }
        }

        [ServerRpc]
        private void AddPlayerServerRpc()
        {
            
        }
    }
}
