using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private SpriteRenderer _playerSprite;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetAnimation(_controller.Direction);
    }
    private void SetAnimation(float direction)
    {
        var value = RoundDirection(direction);
        _animator.SetInteger("direction", value);
        FlipSprite(direction);
    }
    private void FlipSprite(float direction)
    {
        _playerSprite.flipX = direction < 0;
    }
    private int RoundDirection(float direction)
    {
        if (direction > 0)
            return 1;
        else if (direction < 0)
            return -1;
        return 0;
    }


    public void AnimateShoot()
    {
        _animator.SetTrigger("Shooted");
    }
}
