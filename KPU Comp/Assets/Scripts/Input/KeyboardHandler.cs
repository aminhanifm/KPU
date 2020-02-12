﻿using Zenject;
using UnityEngine;

public class KeyboardHandler : ITickable
{
    private InputState _inputState;

    public KeyboardHandler(InputState inputState)
    {
        _inputState = inputState;
    }


    /// <summary>
    /// Look for mouse input on every frame
    /// Don't change the order of the methods
    /// </summary>
    public void Tick()
    {
        _inputState.Reset();

        CheckAxes();
        CheckButtons();
    }


    /// <summary>
    /// Looks for directional input
    /// </summary>
    private void CheckAxes()
    {
        _inputState.XAxis = UnityEngine.Input.GetAxis("Horizontal");
        _inputState.YAxis = UnityEngine.Input.GetAxis("Vertical");
    }


    /// <summary>
    /// Look for button input
    /// </summary>
    private void CheckButtons()
    {
        _inputState.Interact = UnityEngine.Input.GetButtonDown("Interact");
        //_inputState.Collect = UnityEngine.Input.GetButtonDown("Collect");
        //_inputState.Search = UnityEngine.Input.GetButtonDown("Search");
    }
}
