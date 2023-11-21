
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<EnemyHealthComponent>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<EnemyHealthComponent>().TakeDamage(_damage);
        }
    }
}
