using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    protected int bulletsCount = 5;

    [HideInInspector]public Events.EventIntegerEvent onBulletChange;

    private void Awake()
    {
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
        onBulletChange.Invoke(bulletsCount);
    }

    public int GetBulletsCount()
    {
        return bulletsCount;
    }
}
