using Assets.Scripts.Krutagidon;
using Assets.Scripts.Network;
using Assets.Scripts.Network.Factories;
using Assets.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindGameManager();

            
            IDebugger debugBehav = Container
                .InstantiateComponentOnNewGameObject<DebugBehaviour>();
            Container
                .Bind<IDebugger>()
                .FromInstance(debugBehav);
        }

        private void BindFactories()
        {
            Container
                .Bind<IPlayerFactory>()
                .To<WizardFactory>()
                .AsSingle();
        }

        private void BindGameManager()
        {
            Container
                .BindInterfacesAndSelfTo<GameManager>()
                .AsSingle();
        }
    }
}
