using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class LevelInstaller : MonoInstaller
{
    public GameObject player;
    public LevelHandler levelHandler;

    public override void InstallBindings()
    {
        Container.Bind<PlayerFacade>()
            .FromComponentInHierarchy(player)
            .AsSingle();

        Container.Bind<LevelState.moreStates>()
            .AsSingle();

        Container.Bind<LevelState>()
            .AsSingle();

        Container.Bind<LevelHandler>()
            .FromComponentInHierarchy(levelHandler)
            .AsSingle();
    }
}
