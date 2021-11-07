using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Text counterText;
    [SerializeField] Stats playerStats;
    private void Start()
    {
        playerStats.onBulletChange.AddListener(HandleOnBulletChange);
    }

    void HandleOnBulletChange(int bullets)
    {
        counterText.text = bullets.ToString();
    }
}
