using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elias
{
    public class UserInputManger : Singleton<UserInputManger>
    {
        [SerializeField] private AvatarController avatar;

        private float horizontalInput;
        private float verticalInput;

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");


            if (Input.GetButton("Fire1"))
            {
                avatar.HandleShootButton();
            }
        }
    }
}

