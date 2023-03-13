using Assets.Scripts.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Krutagidon
{
    public class Wizard : Player
    {
        public IntStat Health { get; private set; }

        public event Action StatChanged;

        public Wizard(int id, ulong netId, string name) : base(id, netId, name)
        {
            _stats.Add("Health", new IntStat("Health", 20,0,25));
        }
    }
}
