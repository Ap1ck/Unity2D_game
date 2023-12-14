
using System;
using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealthComponent _healhPlayer;
    [SerializeField] private Animator _animator;

    [SerializeField] private LayerMask _playerMask;

    [SerializeField] private Transform _rangeAttack;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private float _damage;

    public static event Action<float> OnTakeDamage;

    private void Awake()
    {
        _healhPlayer = GetComponent<PlayerHealthComponent>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_rangeAttack.position, _sphereRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                StartCoroutine(AttackTime());
            }
        }
    }

    //public void StartOfAttackAnimation()
    //{
    //    StartCoroutine(AttackTime());
    //}

    private IEnumerator AttackTime()
    {
        _animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(1f);
        OnTakeDamage?.Invoke(_damage);
        _animator.SetBool("isAttack", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_rangeAttack.position, _sphereRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
