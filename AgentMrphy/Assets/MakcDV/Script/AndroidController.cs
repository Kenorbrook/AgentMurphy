using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : Controller
{
    [SerializeField] private DynamicJoystick _jostick;

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
        _direction = _jostick.Direction.x;
    }

    private void CheakJump()
    {

        if (_jostick.Direction.y > 0.9f && JumpEvent!=null)
        {
            Debug.Log(_jostick.Direction.y);
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
