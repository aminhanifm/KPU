using Zenject;

public class InputInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<InputState>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<KeyboardHandler>()
            .AsSingle()
            .NonLazy();
    }
}
