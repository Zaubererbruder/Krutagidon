using Assets.Scripts.Network;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class InGameInstaller : MonoInstaller
    {
        [SerializeField] Server _server;
        [SerializeField] TurnMover _turnMover;
        public override void InstallBindings()
        {
            Container
                .Bind<Server>()
                .FromInstance(_server);

            Container
                .Bind<TurnMover>()
                .FromInstance(_turnMover);
        }
    }
}
