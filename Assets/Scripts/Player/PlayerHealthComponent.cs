using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHealthComponent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Canvas _loseCanvas;
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    public static event Action OnTakeDamage;
    public static event Action OnDied;

    private float _currentHealth;
    private float _timeOfDeathAnimation = 1.12f;
    private bool _isAlive;

    public bool Alive => _isAlive;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        _healthBar.SetHealth(_currentHealth, _maxHealth);
    }

    private void IsAlive()
    {
        if (_currentHealth > 0)
        {
            _isAlive = true;
        }
        else
        {
            StartCoroutine(AnimDeath());
            _isAlive = false;
        }
    }

    private IEnumerator AnimHit()
    {
        _animator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.25f);
        _animator.SetBool("isHit", false);
    }

    private IEnumerator AnimDeath()
    {
        OnDied?.Invoke();
        _animator.SetBool("isDeath", true);
        yield return new WaitForSeconds(_timeOfDeathAnimation);
        _loseCanvas.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        AIEnemy.OnTakeDamage -= TakeDamage;
    }

    private void OnEnable()
    {
        AIEnemy.OnTakeDamage += TakeDamage;
    }

    public void TakeDamage(float damage)
    {
        OnTakeDamage?.Invoke();
        _currentHealth -= damage;
        StartCoroutine(AnimHit());
        _healthBar.SetHealth(_currentHealth, _maxHealth);
        IsAlive();
    }
}
