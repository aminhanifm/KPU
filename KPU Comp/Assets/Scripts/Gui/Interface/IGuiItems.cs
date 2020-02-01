using UnityEngine;
using System;

public interface IGuiItems
{
    GameObject gui { get;  }
    void onEnterAnimation();
    void onExitAnimation();
}
