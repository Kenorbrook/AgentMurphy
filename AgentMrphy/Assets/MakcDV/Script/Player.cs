using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]

    [SerializeField] private int _speedMovement;
    [SerializeField] private Transform weaponAnchor;
    [SerializeField] private Controller _controller;
    [SerializeField] private JumpAnimation _jumpAnimation;

    private PhysicMovement _movement;
    private IJump _playerJump;

    public Stats stats;
    public PlayerAnimator playerAnimator;

    public delegate void PlayerEvent();
    public PlayerEvent PlayerEventAction;

    public bool IsGround => CheakGround(); 

    private void Awake()
    {
        _playerJump = _jumpAnimation;
        _movement = new PhysicMovement(_speedMovement, GetComponent<Rigidbody2D>());
    }
    private void OnEnable()
    {
        _controller.JumpEvent += _playerJump.Jump;
        _controller.ShootEvent += HandleShootInput;
    }
    private void OnDisable()
    {
        _controller.JumpEvent -= _playerJump.Jump;
        _controller.ShootEvent -= HandleShootInput;
    }
    private void FixedUpdate()
    {
        _movement.Move(_controller.Direction);
    }
    private void HandleShootInput()
    {
        ShootProjectile();
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
    private bool CheakGround()
    {
        return true;
    }
}
