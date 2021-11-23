using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private Transform weaponAnchor;
    [SerializeField] private Controller _controller;
    [SerializeField] private AudioClip _fire;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _controller.ShootEvent += ShootProjectile;
    }
    private void OnDisable()
    {
        _controller.ShootEvent -= ShootProjectile;
    }
    private void ShootProjectile()
    {
        if (_stats.GetBulletsCount() > 0)
        {
            GameObject projectile = PoolManager.Instance.PojectilePool.GetPooledObject();
            projectile.transform.position = weaponAnchor.position;

            projectile.transform.rotation = weaponAnchor.rotation;
            if (gameObject.transform.localScale.x < 0)
                projectile.transform.Rotate(projectile.transform.up, 180f);
            projectile.SetActive(true);
            _stats.IncreaseOneBullet();
            _source.PlayOneShot(_fire);
        }
    }
}
