using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerFacade : MonoBehaviour
{
    public Vector2 Position => _player.Position;

    private PlayerModel _player;

    private PlayerMovementHandler _movementHandler;

    private PlayerCollisionHandler _collisionHandler;

    private PlayerAnimationHandler _animationHandler;

    private enum States
    {
        Idle,
        Moving
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="player"></param>
    /// <param name="collisionHandler"></param>
    /// <param name="movementHandler"></param>
    /// <param name="stateMachine"></param>
    [Inject]
    public void Construct(
        PlayerModel player,
        PlayerCollisionHandler collisionHandler,
        PlayerMovementHandler movementHandler,
        PlayerAnimationHandler animationHandler)
    {
        _player = player;
        _collisionHandler = collisionHandler;
        _movementHandler = movementHandler;
        _animationHandler = animationHandler;
    }

    /// <summary>
    /// Check input and movement and swap state depending on what's going on
    /// </summary>
    private void LateUpdate()
    {
        _collisionHandler.Check(_player.Input.CurrentDirection);
        _movementHandler.Move(_player.Input.CurrentDirection);
        _animationHandler.Animate(_player.Input.CurrentDirection);

        //if (_player.IsMoving && _stateMachine.CurrentStateIs(_stateMap[States.Idle]))
        //{
        //    _stateMachine.ChangeState(_stateMap[States.Moving]);
        //}
        //else if (!_player.IsMoving && _stateMachine.CurrentStateIs(_stateMap[States.Moving]))
        //{
        //    _stateMachine.ChangeState(_stateMap[States.Idle]);
        //}
    }
}
