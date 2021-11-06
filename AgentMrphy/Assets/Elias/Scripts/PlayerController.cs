using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Move
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float runSpeed;
    //Jump
    [SerializeField] private float jumpForce;

    //Shoot
    [SerializeField] private float shootTimeDelay;
    [SerializeField] private Transform weaponAnchor;
    private float shootTimeTick = 0f;
    protected Moveable moveableComponent;
    public Stats stats;

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
        Move();
    }
    public void Move()
    {
        moveableComponent.Move(moveSpeed);
        //TODO Animation
    }

    public void Run()
    {
        moveableComponent.Move(runSpeed);
        //TODO Animation
    }

    public void HandleJumpInput()
    {
        moveableComponent.Jump(jumpForce);
        //TODO Animation
    }

    public void TurnArount()
    {
        moveableComponent.TurnAround();
        //TODO Animation
    }

    public void HandleShootInput()
    {
        if (shootTimeTick > 0)
            return;

        ShootProjectile();

        shootTimeTick = shootTimeDelay;
    }

    virtual protected GameObject ShootProjectile()
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
            return projectile;
        }
        else
        {
            return null;
        }

    }

    protected GameObject[] ObjectsInRange(float searchRadious, LayerMask searchTarget)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, searchRadious, searchTarget);
        if (colliders != null)
        {
            GameObject[] obj = new GameObject[colliders.Length];
            for (int i = 0; i < colliders.Length; i++)
            {
                obj[i] = colliders[i].gameObject;
            }
            return obj;
        }
        else
            return null;
    }

    protected bool IsLookingRight()
    {
        return (transform.position.x > 0);
    }
}
