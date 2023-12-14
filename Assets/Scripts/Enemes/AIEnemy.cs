using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDamage))]
public class AIEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _pointPatrol;

    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _timeToRevert;

    private float _currentTimeToRevert;

    private bool _revertRightOrLeft = true;

    private float _currentState = 0;

    private const float IDLE_STATE = 1;
    private const float WALK_STATE = 2;
    private const float REVERT_STATE = 3;
    private const float ATTACK_STATE = 4;

    public static event Action<float> OnTakeDamage;

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;

    private void Start()
    {
        _currentState = WALK_STATE;
        _collider = GetComponent<BoxCollider2D>();
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

                if (_revertRightOrLeft)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                _revertRightOrLeft = !_revertRightOrLeft;

                _speed *= -1;

                _currentState = WALK_STATE;
                break;

            case ATTACK_STATE:

                _currentState = WALK_STATE;

                break;
        }

        _animator.SetFloat("Velocity", _rigidBody.velocity.magnitude);
    }

    private void AttackNow()
    {
        _currentState = ATTACK_STATE;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stopper"))
        {
            _currentState = IDLE_STATE;
        }
    }

    private void OnEnable()
    {
        EnemyDamage.IsAttack += AttackNow;
        EnemyHealthComponent.IsDied += RemoveEnemyComponent;
        EnemyHealthComponent.IsTakeHit += MovingStop;
    }

    private void OnDisable()
    {
        EnemyDamage.IsAttack -= AttackNow;
        EnemyHealthComponent.IsDied -= RemoveEnemyComponent;
        EnemyHealthComponent.IsTakeHit -= MovingStop;
    }

    private void MovingStop()
    {
        StartCoroutine(StopWalkTime());
    }

    private IEnumerator StopWalkTime()
    {
        _currentState = IDLE_STATE;
        yield return new WaitForSeconds(0.7f);
        _currentState = WALK_STATE;
    }

    private void RemoveEnemyComponent()
    {
        Destroy(_rigidBody);
        Destroy(_collider);
    }
}
