using UnityEngine;

namespace Elias
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [Header("Set in Inspector")]
        [SerializeField] float speed;
        [SerializeField] float worldLimit;
        Rigidbody2D rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StarMoving();
        }
        private void Update()
        {
            if (isOutWorldBorders())
                DestroyProjectile();
        }

        void StarMoving()
        {
            rigid.velocity = transform.right * speed;
        }

        bool isOutWorldBorders() //TODO move to Camera controller
        {
            Debug.Log(transform.position.x);
            if (Mathf.Abs(transform.position.x) > worldLimit)
                return true;
            else
                return false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<IDamagable>() != null)
            {
                foreach(IDamagable damagable in collision.gameObject.GetComponents<IDamagable>())
                {
                    damagable.Damage();
                    DestroyProjectile();
                }
            }
        }

        void DestroyProjectile()
        {
            PoolManager.Instance.PojectilePool.ReturnObjectToPool(gameObject);
        }
    }
}