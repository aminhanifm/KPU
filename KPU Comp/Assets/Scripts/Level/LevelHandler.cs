using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class LevelHandler : MonoBehaviour
{
    private LevelState levelState { get; set; }

    [Inject]
    private void Construct(
        LevelState _levelState)
    {
        levelState = _levelState;
    }

    private void CekState()
    {
        
    }
}
