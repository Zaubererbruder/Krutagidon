using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerNetworkBehaviour _networkBehaviour;
        public string Name => name;
        public bool IsBot { get; set; }
        public ulong ClientId => IsBot ? 0 : _networkBehaviour.OwnerClientId;

        private void Awake()
        {
            IsBot = !TryGetComponent(out _networkBehaviour);
        }

    }
}
