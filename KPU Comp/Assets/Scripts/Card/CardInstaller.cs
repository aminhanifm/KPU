using UnityEngine;
using Zenject;

public class CardInstaller : MonoInstaller<CardInstaller>
{
    public MasukKotakManager masukKotakManager;
    public CardsHandler cardsHandler;
    public Card cardPrefab;

    public override void InstallBindings()
    {
        Container.Bind<MasukKotakManager>()
            .FromComponentInHierarchy(masukKotakManager)
            .AsSingle();

        Container.Bind<CardsHandler>()
            .FromComponentInHierarchy(cardsHandler)
            .AsSingle();

        Container.BindFactory<Card, Card.Factory>().FromComponentInNewPrefab(cardPrefab);
    }
}
