using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Netcode;

namespace Assets.Scripts.Network.Messages
{
    public struct PlayerDataMessage : INetworkSerializable
    {
        //public ulong NetId;
        public FixedString128Bytes Name;

        public PlayerDataMessage(string name)
        {
            //NetId = netId;
            Name = name;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            //serializer.SerializeValue(ref NetId);
            serializer.SerializeValue(ref Name);
        }
    }
}
