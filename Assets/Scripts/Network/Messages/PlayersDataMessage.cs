using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;

namespace Assets.Scripts.Network.Messages
{
    public struct PlayersDataMessage : INetworkSerializable
    {
        public PlayerDataMessage[] players;
        public int[] playersIds;
        public ulong[] playersNetIds;

        public PlayersDataMessage(List<Player> playersList)
        {
            players = new PlayerDataMessage[playersList.Count];
            playersIds = new int[playersList.Count];
            playersNetIds = new ulong[playersList.Count];

            for (int i = 0; i < playersList.Count; i++)
            {
                Player player = playersList[i];
                players[i] = new PlayerDataMessage(player.Name);
                playersIds[i] = player.Id;
                playersNetIds[i] = player.NetId;
            }
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref players);
            serializer.SerializeValue(ref playersIds);
            serializer.SerializeValue(ref playersNetIds);
        }
    }
}
