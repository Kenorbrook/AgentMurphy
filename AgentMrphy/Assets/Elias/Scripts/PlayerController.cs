using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Move
    [SerializeField] private float speed;

    //Jump
    [SerializeField] private float jumpForce;

    //Shoot
    [SerializeField] private float shootTimeDelay;
    [SerializeField] private Transform weaponAnchor;
    private float shootTimeTick = 0f;
    Moveable moveableComponent;

    private void Awake()
    {
        moveableComponent = GetComponent<Moveable>();
    }
    private void Update()
    {
        shootTimeTick -= Time.deltaTime;
    }

    public void HandleMoveInput(bool isMovingDirectionRight)
    {
        moveableComponent.TurnAround(isMovingDirectionRight);


        moveableComponent.Move(speed);
        //TODO Animation
    }

    public void HandleJumpInput()
    {
        moveableComponent.Jump(jumpForce);
        //TODO Animation
    }

    public void HandleShootInput()
    {
        if (shootTimeTick > 0)
            return;

        ShootProjectile();

        shootTimeTick = shootTimeDelay;
    }

    void ShootProjectile()
    {
        GameObject projectile = PoolManager.Instance.PojectilePool.GetPooledObject();
        projectile.transform.position = weaponAnchor.position;

        projectile.transform.rotation = weaponAnchor.rotation;
        if (gameObject.transform.localScale.x < 0)
            projectile.transform.Rotate(projectile.transform.up, 180f);

        projectile.SetActive(true);
    }
}
