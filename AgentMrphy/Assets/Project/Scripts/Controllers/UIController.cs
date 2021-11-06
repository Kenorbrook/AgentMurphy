using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public UnityEvent JumpClickAction;
    public UnityEvent ShootClickAction;

    [HideInInspector]public static UIController instance;

    [SerializeField] Button jumpButton;
    [SerializeField] Button shootButton;
    public Text BulletCounter;
    protected override void Awake()
    {
        base.Awake();
        instance = this;

        jumpButton.onClick.AddListener(()=>
        {
            JumpClickAction?.Invoke();
        });

        shootButton.onClick.AddListener(() =>
        {
            ShootClickAction?.Invoke();
        });
    }
}
