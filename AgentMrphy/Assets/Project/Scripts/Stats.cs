using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    protected float BulletsCount = 5;

    UnityEvent ShootEvent;

    //[SerializeField] Text CounterText;

    void Start()
    {
        //CounterText.text = BulletsCount.ToString();

        if (ShootEvent == null)
            ShootEvent = new UnityEvent();

        //ShootEvent.AddListener(Shooted);
    }

    public void IncreaseOneButton()
    {
        BulletsCount--;
        ShootEvent.Invoke();
    }

    public float GetBulletsCount()
    {
        return BulletsCount;
    }
}
