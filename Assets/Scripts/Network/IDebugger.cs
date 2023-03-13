using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Network
{
    public interface IDebugger
    {
        public void ChangeMessage(string type, string message);
        public void RemoveType(string type);
    }
}
