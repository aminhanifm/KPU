using Zenject;

public class PlayerInstaller : MonoInstaller
{
    // ReSharper disable once InconsistentNaming
    [Inject]
    public InputState InputState;

    public PlayerSettings playerSettings;
    public PlayerModel.Components modelComponents;    
    public PlayerCollisionHandler.Components collisionComponents;

    public override void InstallBindings()
    {
        Container.Bind<PlayerSettings>()
                .FromInstance(playerSettings)
                .AsSingle();

        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(modelComponents, InputState)
            .NonLazy();

        Container.Bind<PlayerMovementHandler>()
            .AsSingle()
            .NonLazy();

        Collision();
    }

    /// <summary>
    /// Bind collision
    /// </summary>
    private void Collision()
    {
        Container.Bind<PlayerCollisionState>()
            .AsSingle()
            .WhenInjectedInto<PlayerModel>();

        Container.BindInterfacesAndSelfTo<PlayerCollisionHandler>()
            .AsSingle()
            .WithArguments(collisionComponents)
            .NonLazy();
    }
}
