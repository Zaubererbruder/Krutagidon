using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class TestSceneInstaller : MonoInstaller
{
    [SerializeField] private CardViewsController _cardViewsController;
    public override void InstallBindings()
    {   
        BindInstances();
    }

    private void BindInstances()
    {
        CardViewsPool cardsPool = new CardViewsPool();
        Container
            .BindInstances(
                cardsPool,
                _cardViewsController);
    }
}
