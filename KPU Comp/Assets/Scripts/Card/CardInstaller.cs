using UnityEngine;
using Zenject;

public class CardInstaller : MonoInstaller<CardInstaller>
{
    public MasukKotakManager masukKotakManager;
    public Card cardPrefab;

    public override void InstallBindings()
    {
        Container.Bind<MasukKotakManager>()
            .FromInstance(masukKotakManager);

        Container.BindFactory<Card, Card.Factory>().FromComponentInNewPrefab(cardPrefab);
    }
}
