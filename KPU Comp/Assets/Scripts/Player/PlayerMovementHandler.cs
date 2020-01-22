using UnityEngine;

public class PlayerMovementHandler
{
    private PlayerModel _player;
    private PlayerSettings _playerSettings;

    private float SkinWidth => _playerSettings.skinWidth;
    private PlayerCollisionState CollisionState => _player.CollisionState;

    public PlayerMovementHandler(
            PlayerModel player,
            PlayerSettings playerSettings)
    {
        _player = player;
        _playerSettings = playerSettings;
    }

    public void Move(Vector2 delta)
    {
        _8DirectionModule(ref delta);

        XMovement(ref delta);
        YMovement(ref delta);

        _player.Position += delta * _playerSettings.speed * Time.deltaTime;
    }

    private void _8DirectionModule(ref Vector2 delta)
    {
        float step = 360f / 8;
        float halfstep = step / 2;

        var angle = Vector2.SignedAngle(Vector2.up, delta);
        angle = -(angle - 360 -halfstep) % 360f;

        int pos = Mathf.FloorToInt(angle / step);
    }

    private void XMovement(ref Vector2 delta)
    {
        if (!CollisionState.HasXCollision) return;

        var isGoingRight = delta.x > 0;

        // Colliding so force the delta to the collision point
        delta.x = CollisionState.RaycastXPoint;

        // Then add or subtract the skin depth
        if (isGoingRight)
        {
            delta.x -= SkinWidth;
        }
        else
        {
            delta.x += SkinWidth;
        }
    }


    private void YMovement(ref Vector2 delta)
    {
        if (!CollisionState.HasYCollision) return;

        var isGoingUp = delta.y > 0;

        // Colliding so force the delta to the collision point
        delta.y = CollisionState.RaycastYPoint;

        // Then add or subtract the skin depth
        if (isGoingUp)
        {
            delta.y -= SkinWidth;
        }
        else
        {
            delta.y += SkinWidth;
        }
    }
}
