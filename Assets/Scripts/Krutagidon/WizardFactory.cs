using Assets.Scripts.Network;
using Assets.Scripts.Network.Factories;
using Assets.Scripts.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Krutagidon
{
    public class WizardFactory : IPlayerFactory
    {
        public static int IdCounter = 0;

        public Player Create(PlayerDataMessage playerDataMessage, ulong netId)
        {
            Wizard player = new Wizard(IdCounter, netId, playerDataMessage.Name.ToString());
            IdCounter++;

            return player;
        }

        public Player CreateExist(int id, ulong netId, string name)
        {
            Wizard player = new Wizard(id, netId, name);
            return player;
        }
    }
}
