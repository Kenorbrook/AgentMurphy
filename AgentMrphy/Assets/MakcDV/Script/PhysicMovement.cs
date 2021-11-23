using UnityEngine;

public class PhysicMovement
{
    private readonly int _speedMovement;
    private readonly Rigidbody2D _rigidbody;

    public PhysicMovement(int speedMovement, Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
        _speedMovement = speedMovement;
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedMovement * direction, _rigidbody.velocity.y);
    }
}
