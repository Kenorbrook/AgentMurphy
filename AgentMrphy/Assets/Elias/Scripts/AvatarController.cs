using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elias
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class AvatarController : MonoBehaviour
    {
        [Header("Set in Inspector")]

        //Move
        [SerializeField] private float speed;
        private bool isMovingRight;

        //Jump
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform groundCheckAnchor;
        [SerializeField] private LayerMask groundLayerMask; // A mask determining what is ground to the character
        float groundCheckRadius = .2f; // Radius of the overlap circle to determine if grounded
        float groundCheckTimeDelay = 0.1f;
        float groundCheckTimeTick = 0f;
        [SerializeField] private bool isOnGround = true; // Whether or not the player is grounded.

        //Shoot
        [SerializeField] private float shootTimeDelay;
        [SerializeField] private Transform weaponAnchor;
        private float shootTimeTick = 0f;

        Rigidbody2D rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();

            isMovingRight = transform.localScale.x > 0;
        }
        private void Update()
        {
            shootTimeTick-=Time.deltaTime;
            groundCheckTimeTick -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (groundCheckTimeTick <= 0)
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
        public void HandleShootButton()
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

        public void Jump()
        {
            if (isOnGround)
            {
                isOnGround = false;
                groundCheckTimeTick = groundCheckTimeDelay;
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        public void Move(bool isMovingDirectionRight)
        {
            if ((isMovingRight == true && isMovingDirectionRight == false) || (isMovingRight == false && isMovingDirectionRight == true))
                TurnAround();

            if (isOnGround == false)
                return;

            if(isMovingRight)
                rigid.velocity = Vector2.right * speed;
            else
                rigid.velocity = -Vector2.right * speed;
        }

        void TurnAround()
        {
            isMovingRight = !isMovingRight;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }


    }
}
