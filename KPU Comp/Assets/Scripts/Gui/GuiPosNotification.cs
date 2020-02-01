using UnityEngine;
using System;
using DG.Tweening;
using TMPro;

public class GuiPosNotification : IGuiItems
{
    public GameObject gui { get; }
    public Items items { get;  }

    Tweener notiftween { get; set; }
    Tweener actiontween { get; set; }

    Transform notif => items.notifGui.transform;
    TMP_Text notifText => items.notiftext;
    Transform action => items.actionGui.transform;

    PosSettings _posSettings;
    public PosSettings posSettings {
        get {
            return this._posSettings;
        }
        set {
            this._posSettings = value;
            notifText.SetText(this._posSettings.notification);
        } 
    }

    private float duration = 0.6f;

    /// <summary>
    /// Constructor
    /// </summary>    
    public GuiPosNotification(
        GameObject _gui,
        Items _items)
    {
        gui = _gui;
        items = _items;
        initAnimation();
    }

    private void initAnimation()
    {
        TweenParams tParam = new TweenParams().SetEase(Ease.InOutBack).SetAutoKill(false);

        notiftween = notif.DOMoveY(notif.position.y - 80f , duration).SetAs(tParam);
        notiftween.Complete();

        actiontween = action.DOMoveY(action.position.y + 100f, duration).SetAs(tParam);
        actiontween.Complete();
    }

    public void onEnterAnimation() 
    {
        notiftween.PlayBackwards();

        actiontween.PlayBackwards();
    }
    public void onExitAnimation() 
    {
        notiftween.PlayForward();

        actiontween.PlayForward();
    }

    [Serializable]
    public class Items
    {
        public GameObject notifGui;
        public TMP_Text notiftext;
        public GameObject actionGui;
    }
}
