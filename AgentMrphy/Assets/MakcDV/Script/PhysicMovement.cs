using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMovement : MonoBehaviour
{
    [SerializeField] private int _speedMovement;
    [SerializeField] private Controller _controller;
    [SerializeField] private Transform groundCheckAnchor;
    [SerializeField] private LayerMask groundLayerMask;

    private Rigidbody2D _rigidbody;

    private float groundCheckRadius = .2f;
    private bool isOnGround = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnGroundCheck();
        Move();
    }

    private void OnGroundCheck()
    {
        isOnGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckAnchor.position, groundCheckRadius, groundLayerMask);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
                isOnGround = true;
        }
    }

    public void Jump(float force)
    {
        Debug.Log(isOnGround);
        if (!isOnGround)
            return;
        _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speedMovement * _controller.Direction, _rigidbody.velocity.y);
    }
}
