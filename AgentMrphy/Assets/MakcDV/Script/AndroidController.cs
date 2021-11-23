using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : Controller
{
    [SerializeField] private FixedJoystick _jostick;

    private float _direction;
    private bool _canShoot = true;

    public override float Direction => _direction;

    public override event ControllerEvent JumpEvent;
    public override event ControllerEvent ShootEvent;

    private void Update()
    {
        OnSetDirection();
        CheakJump();
    }

    private void OnSetDirection()
    {
        if (_jostick.Direction.x > 0)
            _direction = 1;
        else if (_jostick.Direction.x < 0)
            _direction = -1;
        else
            _direction = 0;
    }

    private void CheakJump()
    {

        if (_jostick.Direction.y > 0.9f && JumpEvent!=null)
        {
            JumpEvent();
        }
    }
    public void OnShooting()
    {
        if (_canShoot)
        {
            _canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        if (ShootEvent != null)
            ShootEvent();
        yield return new WaitForSeconds(delayNextShoot);
        _canShoot = true;
    }
}
