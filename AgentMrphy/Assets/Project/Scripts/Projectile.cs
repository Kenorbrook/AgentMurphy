using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] float speed;
    [SerializeField] float worldBorder;
    Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StarMoving();
    }

    private void Update()
    {

    }

    void StarMoving()
    {
        rigid2D.velocity = transform.right * speed;
    }

    bool isOutWorldBorders() //TODO move to Camera controller
    {
        if (Mathf.Abs(transform.position.x) > worldBorder)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ITransformable>() != null)
        {
            collision.gameObject.GetComponent<ITransformable>().HandleTransforming();
            DestroyProjectile();
        }
        
        //if (collision.gameObject.GetComponent<IDamagable>() != null)
        //{
        //    foreach (IDamagable damagable in collision.gameObject.GetComponents<IDamagable>())
        //    {
        //        damagable.Damage();
        //        DestroyProjectile();
        //    }
        //}
    }

    void DestroyProjectile()
    {
        PoolManager.Instance.PojectilePool.ReturnObjectToPool(gameObject);
    }
}