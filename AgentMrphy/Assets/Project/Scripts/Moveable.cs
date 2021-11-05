using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] private Transform groundCheckAnchor;
    [SerializeField] private LayerMask groundLayerMask; // A mask determining what is ground to the character

    Rigidbody2D rigid2D;

    float groundCheckRadius = .2f; // Radius of the overlap circle to determine if grounded
    bool isMovingRight;
    bool isOnGround = true; // Whether or not the player is grounded.

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        isMovingRight = transform.localScale.x > 0;
    }

    private void FixedUpdate()
    {
        OnGroundCheck();
    }

    void OnGroundCheck()
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
        if (isOnGround)
            return;

        rigid2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public void TurnAround(bool is_moving_direction_right)
    {
        if (!((isMovingRight == true && is_moving_direction_right == false) || (isMovingRight == false && is_moving_direction_right == true)))
            return;

        isMovingRight = !isMovingRight;
        gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        //Turn in fly
        if (isOnGround == false)
            rigid2D.velocity = new Vector2(-rigid2D.velocity.x, rigid2D.velocity.y);
    }

    public void Move(float speed)
    {
        if (!isOnGround)
            return;

        if (isMovingRight)
            rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
        else
            rigid2D.velocity = new Vector2(-speed, rigid2D.velocity.y); ;
    }
}
