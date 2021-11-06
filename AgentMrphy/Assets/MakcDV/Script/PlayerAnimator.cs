using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private float _direction;
    private Animator _animator; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = Input.GetAxis("Horizontal");
        SetAnimation(_direction);
    }

    private void SetAnimation(float direction)
    {
        int value = 0;
        if (direction > 0)
            value = 1;
        else if (direction < 0)
            value = -1;
        _animator.SetInteger("direction", value);
    }
}
