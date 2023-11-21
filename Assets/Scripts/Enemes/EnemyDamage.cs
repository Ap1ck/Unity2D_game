
using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<PlayerHealthComponent>().TakeDamage(_damage);
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
