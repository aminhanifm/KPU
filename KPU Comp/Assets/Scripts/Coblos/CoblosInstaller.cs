using UnityEngine;
using Zenject;

public class CoblosInstaller : MonoInstaller
{
    public CoblosContainer coblosContainer;
    //public CoblosContainer.Components coblosComponent;

    public override void InstallBindings() {
        
        Container.Bind<CoblosContainer>()
            .FromInstance(coblosContainer);
    }
    
}
