using Assets.Scripts.Krutagidon;
using System.Collections.Generic;

namespace Assets.Scripts.Network
{
    public class Player
    {
        protected Dictionary<string, IntStat> _stats = new Dictionary<string, IntStat>();

        public int Id { get; private set; }
        public ulong NetId { get; private set; }
        public string Name { get; private set; }

        public Player(int id, ulong netId, string name)
        {
            Id = id;
            NetId = netId;
            Name = name;
        }

        public IntStat GetStat(string name)
        {
            return _stats[name];
        }
    }
}
