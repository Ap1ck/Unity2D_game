using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRevert;

    private Rigidbody2D _rigidBody;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float _currentState, _currentTimeToRevert;

    private void Start()
    {
        _currentState = WALK_STATE;
        _currentTimeToRevert = 0;
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (_currentTimeToRevert >= _timeToRevert)
        {
            _currentTimeToRevert = 0;
            _currentState = REVERT_STATE;
        }

        switch (_currentState)
        {
            case IDLE_STATE:
                _currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                _rigidBody.velocity = Vector2.left * _speed;
                    break;       
            case REVERT_STATE:
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _speed *= -1;
                _currentState = WALK_STATE;
                break;
        }

        _animator.SetFloat("Velocity", _rigidBody.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            _currentState = IDLE_STATE;
        }
    }
}
