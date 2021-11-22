using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform weaponAnchor;
    [SerializeField] private Controller _controller;

    private PhysicMovement _movement;

    public Stats stats;
    public PlayerAnimator playerAnimator;

    public delegate void PlayerEvent();
    public PlayerEvent PlayerEventAction;


    private void Awake()
    {
        _movement = GetComponent<PhysicMovement>();
    }
    private void OnEnable()
    {
        _controller.JumpEvent += HandleJumpInput;
        _controller.ShootEvent += HandleShootInput;
    }
    private void OnDisable()
    {
        _controller.JumpEvent -= HandleJumpInput;
        _controller.ShootEvent -= HandleShootInput;
    }
    private void HandleShootInput()
    {
        ShootProjectile();
    }

    private void HandleJumpInput()
    {
        _movement.Jump(jumpForce);
    }

    public void InvokeDeadEvent()
    {
        if (PlayerEventAction != null)
            PlayerEventAction();
    }

    protected virtual GameObject ShootProjectile()
    {
        if (stats.GetBulletsCount() > 0)
        {
            GameObject projectile = PoolManager.Instance.PojectilePool.GetPooledObject();
            projectile.transform.position = weaponAnchor.position;

            projectile.transform.rotation = weaponAnchor.rotation;
            if (gameObject.transform.localScale.x < 0)
                projectile.transform.Rotate(projectile.transform.up, 180f);

            projectile.SetActive(true);
            stats.IncreaseOneBullet();
            playerAnimator.AnimateShoot();
            return projectile;
        }
        else
        {
            return null;
        }
    }

}
