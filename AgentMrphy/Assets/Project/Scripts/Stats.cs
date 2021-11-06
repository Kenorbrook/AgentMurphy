using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    protected float BulletsCount = 5;

    //UnityEvent ShootEvent;
    public Events.EventIntegerEvent onBulletChange;

    private void Awake()
    {
        onBulletChange = new Events.EventIntegerEvent();
    }
    void Start()
    {
        //CounterText.text = BulletsCount.ToString();

/*        if (ShootEvent == null)
            ShootEvent = new UnityEvent();
*/
        //ShootEvent.AddListener(Shooted);
    }

    public void IncreaseOneButton()
    {
        BulletsCount--;
        onBulletChange.Invoke((int)BulletsCount);
        //ShootEvent.Invoke();
    }

    public float GetBulletsCount()
    {
        return BulletsCount;
    }
}
