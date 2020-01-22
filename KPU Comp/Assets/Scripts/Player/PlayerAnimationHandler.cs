using UnityEngine;
using Zenject;
using System;

public class PlayerAnimationHandler : IInitializable
{
    private readonly string[] staticAnimations = {"Up", "UpRight", "Right", "DownRight", 
                                                    "Down", "DownLeft", "Left", "UpLeft"};

    private Components _components;
    private PlayerModel _player;

    string[] _directionArray;
    public int lastAnimationIndex;
    public bool facingRight { get; set; }

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
        _directionArray = staticAnimations;
    }

    public void setDirection(Vector2 direction)
    {
        lastAnimationIndex = directionToIndex(direction, 8);

        if (lastAnimationIndex > 0 && facingRight) flip();
        else if (lastAnimationIndex < 0 && !facingRight) flip();

        _animator.Play(_directionArray[Mathf.Abs(lastAnimationIndex)]);
    }

    private int directionToIndex(Vector2 direction, int sliceCount)
    {
        Vector2 normDir = direction.normalized;

        float step = 360f / sliceCount;

        float halfStep = step / 1.5f;

        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle += halfStep;

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = _player.Transform.localScale;

        scale.x *= -1;
        _player.Transform.localScale = scale;
    }

    [Serializable]
    public class Components
    {
        public Animator animator;
    }
}
