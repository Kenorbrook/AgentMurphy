using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManger : Singleton<UserInputManger>
{
    [SerializeField] private PlayerController avatar;

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {

#if UNITY_ANDROID
        UIController.Instance.JumpClickAction.AddListener(() => avatar.HandleJumpInput());
        UIController.Instance.ShootClickAction.AddListener(() => avatar.HandleShootInput());
#endif

    }

    private void Update()
    {
        if (avatar == null)
            return;
        PCInput();
    }

    void MobileInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    void PCInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }
}