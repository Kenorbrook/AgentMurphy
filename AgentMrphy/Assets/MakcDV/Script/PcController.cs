using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : Controller
{
    private float _direction;

    public override float Direction => _direction;

    public override event ControllerEvent JumpEvent;
    public override event ControllerEvent ShootEvent;

    private void Awake()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        SetDirection();
        CheakJump();
    }

    private void SetDirection()
    {
        _direction = Input.GetAxis("Horizontal");
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Mouse0) && ShootEvent != null)
            {
                ShootEvent();
                yield return new WaitForSeconds(delayNextShoot);
            }
            else
                yield return null;
        }

    }
    private void CheakJump()
    {
        var jumpInpuut = Input.GetAxis("Vertical");
        if ((jumpInpuut > 0 || Input.GetKey(KeyCode.Space)) && JumpEvent != null)
        {
            JumpEvent();
        }
    }
}
