using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Stats : MonoBehaviour
{
    [SerializeField] private AudioClip _reaload;

    private AudioSource _source;

    protected int bulletsCount = 5;

    [HideInInspector]public Events.EventIntegerEvent onBulletChange;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        onBulletChange = new Events.EventIntegerEvent();
    }
    public void IncreaseOneBullet()
    {
        bulletsCount--;
        onBulletChange.Invoke(bulletsCount);
    }
    public void PlusOneBullet()
    {
        bulletsCount++;
        _source.PlayOneShot(_reaload);
        onBulletChange.Invoke(bulletsCount);
    }

    public int GetBulletsCount()
    {
        return bulletsCount;
    }
}
