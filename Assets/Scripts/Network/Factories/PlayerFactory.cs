using Assets.Scripts.Network.Messages;

namespace Assets.Scripts.Network.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public static int IdCounter = 0;

        public Player Create(PlayerDataMessage playerDataMessage, ulong netId)
        {
            Player player = new Player(IdCounter, netId, playerDataMessage.Name.ToString());
            IdCounter++;

            return player;
        }

        public Player CreateExist(int id, ulong netId, string name)
        {
            Player player = new Player(id, netId, name);
            return player;
        }
    }
}
