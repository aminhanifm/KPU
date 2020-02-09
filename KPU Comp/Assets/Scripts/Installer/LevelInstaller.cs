using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public GameObject player;

    public override void InstallBindings()
    {
        Container.Bind<PlayerFacade>()
            .FromComponentInHierarchy(player)
            .AsSingle();

        Container.Bind<LevelState>()
            .AsSingle();
    }
}
