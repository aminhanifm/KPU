using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    // ReSharper disable once InconsistentNaming
    [Inject]
    public InputState InputState;

    public PlayerSettings playerSettings;
    public PosContainer posContainer;
    public PlayerModel.Components modelComponents;    
    public PlayerCollisionHandler.Components collisionComponents;
    public PlayerAnimationHandler.Components animatorComponents;

    public override void InstallBindings()
    {
        Container.Bind<PlayerSettings>()
                .FromInstance(playerSettings)
                .AsSingle();

        Container.Bind<PosContainer>()
                .FromInstance(posContainer)
                .AsSingle();

        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(modelComponents, InputState)
            .NonLazy();

        Container.Bind<PlayerMovementHandler>()
            .AsSingle()
            .NonLazy();

        Collision();
        _Animator();
    }
    
    /// <summary>
    /// Bind collision
    /// </summary>
    private void Collision()
    {
        Container.Bind<PlayerCollisionState>()
            .AsSingle()
            .WhenInjectedInto<PlayerModel>();

        Container.Bind<PlayerTriggerItems>()
            .AsSingle()
            .WhenInjectedInto<PlayerModel>();

        Container.BindFactory<string, float, GameObject, PosSettings, PlayerTriggerItems.Item, PlayerTriggerItems.Item.Factory>();

        Container.BindInterfacesAndSelfTo<PlayerCollisionHandler>()
            .AsSingle()
            .WithArguments(collisionComponents)
            .NonLazy();
    }

    private void _Animator()
    {
        Container.Bind<PlayerAnimationHandler>()
            .AsSingle()
            .WithArguments(animatorComponents)
            .NonLazy();
    }
}
