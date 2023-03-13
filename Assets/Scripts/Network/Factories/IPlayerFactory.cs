using Assets.Scripts.Network.Messages;

namespace Assets.Scripts.Network.Factories
{
    public interface IPlayerFactory
    {
        public Player Create(PlayerDataMessage playerDataMessage, ulong netId);
        public Player CreateExist(int id, ulong netId, string name);
    }
}
