using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _pointPatrol;

    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRevert;

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidBody != null)
        {
            _rigidBody.velocity = Vector2.left * _speed;
            _animator.SetFloat("Velocity", _rigidBody.velocity.magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Stopper"))
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _speed *= -1;
        }   
    }

    private void OnEnable()
    {
        EnemyHealthComponent.OnDied += StopMoving;
    }

    private void OnDisable()
    {
        EnemyHealthComponent.OnDied -= StopMoving;
    }

    private void StopMoving()
    {
        Destroy(_rigidBody);
        Destroy(_collider);
    }
}
