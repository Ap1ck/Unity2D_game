
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform _grourndColliderTransform;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _jumpOffest;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isGrounded)
        {
            _animator.SetBool("isJumping", false);
        }
        else
        {
            _animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = _grourndColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, _jumpOffest, _groundMask);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            AudioManager.Instance.PlaySFX("Jump");
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private void HorizontalMove(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }

    public void Move(float direction, bool isJumpPressed)
    {
        if (isJumpPressed)
        {
            Jump();
        }

        if (Mathf.Abs(direction) > 0.01)
        {
            HorizontalMove(direction);
        }
    }
}

