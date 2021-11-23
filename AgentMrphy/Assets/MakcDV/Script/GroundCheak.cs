using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheak : MonoBehaviour
{
    [SerializeField] private int _countCheak;
    [SerializeField] private float _cheakDistanse;
    [SerializeField] private BoxCollider2D _playerCollider;
    [SerializeField] private LayerMask _groundLayer;

    private float _cheakInterval;
    private bool _isGround;
    [SerializeField]private GroundState _state;

    public bool IsGround => _isGround;
    public GroundState GroundState => _state;

    private void Awake()
    {
        float diameterCollider = _playerCollider.size.x;
        _cheakInterval = diameterCollider / ( _countCheak - 1);
    }
    private void Update()
    {
        Cheak();
        SetState();
    }
    private void Cheak()
    {
        _isGround = false;
        Vector3 cheakPosition = transform.position - Vector3.right * _playerCollider.size.x / 2;
        for (int i = 0; i < _countCheak; i++)
        {
            Color color = Color.green;
            RaycastHit2D hit = Physics2D.Raycast(cheakPosition, Vector3.down,_cheakDistanse, _groundLayer);
            if (hit.transform !=null)
            {
                if (!_isGround)
                    _isGround = true;
            }
            else
            {
                color = Color.red;
            }
            DrawRay(cheakPosition, color);
             cheakPosition += Vector3.right * _cheakInterval;
        }
    }
    private void DrawRay(Vector3 position, Color color)
    {
        Debug.DrawLine(position, position + Vector3.down * _cheakDistanse, color);
    }
    private void SetState()
    {
        if (_isGround)
        {
            switch (_state)
            {
                case GroundState.Stay:
                    break;
                case GroundState.Enter:
                    _state = GroundState.Stay;
                    break;
                default:
                    _state = GroundState.Enter;
                    break;
            }
        }
        else
        {
            switch (_state)
            {
                case GroundState.Flight:
                    break;
                case GroundState.Exit:
                    _state = GroundState.Flight;
                    break;
                default:
                    _state = GroundState.Exit;
                    break;
            }
        }
    }
}
