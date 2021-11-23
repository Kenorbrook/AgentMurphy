using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class JumpAnimation  : IJump
{
    [SerializeField] private int _jumpHeight;
    [SerializeField] private int _jumpDuration;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private GroundCheak _groundCheak;

    private bool _isJump;
    private float _jumpPositionY;

    public void Jump()
    {
        if (_groundCheak.IsGround && !_isJump)
        {
            _jumpPositionY = _playerTransform.position.y;
            _groundCheak.StartCoroutine(RunAnimation());
        }
    }
    private IEnumerator RunAnimation()
    {
        _isJump = true;
        float progress = 0f;
        while (progress < 1 && _groundCheak.GroundState != GroundState.Enter)
        {
            progress += Time.deltaTime / _jumpDuration;
            float offset = _jumpHeight * _jumpCurve.Evaluate(progress);
            _playerTransform.position = GetCurretPosition(offset);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        _isJump = false;
    }
    private Vector3 GetCurretPosition(float offset)
    {
        float x = _playerTransform.position.x;
        float y = _jumpPositionY + offset;
        float z = _playerTransform.position.z;
        return new Vector3(x, y, z);
    }
}
