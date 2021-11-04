using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elias
{
    public class AvatarController : MonoBehaviour
    {
        [Header("Set in Inspector")]
        [SerializeField] private float speed;

        [SerializeField] private float shootTimeDelay;
        [SerializeField] private Transform weaponAnchor;
        private float shootTimeTick = 0;


        private void Update()
        {
            shootTimeTick-=Time.deltaTime;
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

        void Move()
        {

        }

        void Jump()
        {

        }

        void Fleep()
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }


    }
}
