using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class EnemyHealthComponent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar; 

    public static event Action OnTakeDamage;

    private float _currentHealth;

    private bool _isAlive;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        _healthBar.SetHealth(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        StartCoroutine(AnimHit());
        _healthBar.SetHealth(_currentHealth, _maxHealth);
        IsALive();
    }

    private void IsALive()
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
        _animator.SetBool("isDeath", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
