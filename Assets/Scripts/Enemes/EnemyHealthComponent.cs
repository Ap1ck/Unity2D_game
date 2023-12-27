using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class EnemyHealthComponent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    public event Action IsTakeHit;
    public event Action IsDeath;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetHealth(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        IsTakeHit?.Invoke();
        StartCoroutine(AnimHit());
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth, _maxHealth);
        AudioManager.Instance.PlaySFX("TakeHitEnemy");
        IsALive();
    }

    private void IsALive()
    {
        if (_currentHealth > 0) { }
        else
        {
            IsDeath?.Invoke();
            StartCoroutine(AnimDeath());
        }
    }

    private IEnumerator AnimHit()
    {
        _animator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.25f);
        IsTakeHit?.Invoke();
        _animator.SetBool("isHit", false);
    }

    private IEnumerator AnimDeath()
    {
        _healthBar.gameObject.SetActive(false);
        _animator.SetBool("isDeath", true);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
