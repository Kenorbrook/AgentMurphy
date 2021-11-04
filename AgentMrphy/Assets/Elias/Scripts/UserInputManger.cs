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

            if (horizontalInput != 0)
                avatar.HandleMoveInput(horizontalInput > 0);

            if (Input.GetButtonDown("Jump"))
                avatar.HandleJumpInput();

            if (Input.GetButton("Fire1"))
                avatar.HandleShootInput();
        }
    }
}

