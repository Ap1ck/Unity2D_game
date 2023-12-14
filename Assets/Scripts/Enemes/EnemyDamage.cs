
using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Transform _rangeAttack;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private float _damage;

    public static event Action IsAttack;

    public static event Action<float> OnTakeDamage;

    private void DAMAGE()
    {
        OnTakeDamage?.Invoke(_damage);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsAttack?.Invoke();
            _animator.SetBool("isAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsAttack?.Invoke();
            _animator.SetBool("isAttack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthComponent>().TakeDamage(_damage);
        }
    }
}
