using Assets.Scripts.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Krutagidon
{
    public class KrutagidonServer : Server
    {
        public List<Wizard> Wizards => new List<Wizard>(Players.Select((val) => val as Wizard));
        protected override void StartGame()
        {
            base.StartGame();
        }
    }
}
