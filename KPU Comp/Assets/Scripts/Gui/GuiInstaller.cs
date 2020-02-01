using Zenject;
using UnityEngine;

public class GuiInstaller : MonoInstaller
{
    [Header("Pos Notif")]
    public GameObject guiPosNotification;
    public GuiPosNotification.Items guiPosNotificationItems;
    public override void InstallBindings()
    {
        Container.Bind<GuiPosNotification>()
            .AsSingle()
            .WithArguments(guiPosNotification, guiPosNotificationItems);
    }
}
