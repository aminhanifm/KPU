using UnityEngine;
using Zenject;
using System;

public class PlayerAnimationHandler : IInitializable
{
    //private readonly string[] staticAnimations = {"Up", "UpRight", "Right", "DownRight", 
    //                                                "Down", "DownLeft", "Left", "UpLeft"};

    private readonly string[] staticAnimations = {"Walk_Up", "Walk_UpRight", "Walk_Right", "Walk_DownRight",
                                                    "Walk_Down", "Walk_DownLeft", "Walk_Left", "Walk_UpLeft"};

    private Components _components;
    private PlayerModel _player;

    string[] _directionArray;
    public int lastAnimationIndex;

    private Animator _animator => _components.animator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="player"></param>
    /// <param name="components"></param>
    public PlayerAnimationHandler(
        PlayerModel player,
        Components components) 
    {
        _player = player;
        _components = components;
    }
    public void Initialize()
    {
        Debug.Log("INit start");
        _directionArray = staticAnimations;
        lastAnimationIndex = 4;
    }

    public void Animate(Vector2 direction)
    {
        if (!_player.Input.available)
        {
            _animator.Play("Idle_Down");
            return;
        }
        
        lastAnimationIndex = directionToIndex(direction, 8);

        _animator.Play(staticAnimations[lastAnimationIndex]);
    }

    private int directionToIndex(Vector2 direction, int sliceCount)
    {
        Vector2 normDir = direction.normalized;

        float step = 360f / sliceCount;

        float halfStep = step / 2f;

        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        //angle += halfStep;
        angle = -(angle - 360 - halfStep) % 360f;

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    [Serializable]
    public class Components
    {
        public Animator animator;
    }
}
