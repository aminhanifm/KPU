using UnityEngine;
using System;

public class PlayerModel
{
    private Components _components;

    public Vector2 LastPosition { get; set; }

    public Transform Transform => _components.transform;

    public InputState Input { get; }

    public PlayerCollisionState CollisionState { get; }

    public bool IsMoving => Vector2.Distance(Position, LastPosition) > 0.001;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="components"></param>
    /// <param name="input"></param>
    public PlayerModel(
        Components components,
        PlayerCollisionState collisionState,
        InputState input)
    {
        _components = components;
        CollisionState = collisionState;
        Input = input;
    }

    /// <summary>
    /// Get or set position
    /// </summary>
    public Vector2 Position
    {
        get { return _components.transform.position; }
        set { _components.transform.position = value; }
    }

    [Serializable]
    public class Components
    {
        public Transform transform;
    }
}
