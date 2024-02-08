using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class CoinController : MonoBehaviour
{
    public static event Action<int> IsTakeCoin;

    private int _coin = 1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Coin");
            IsTakeCoin?.Invoke(_coin);
            StartCoroutine(DeletedCoin());
        }
    }

    private IEnumerator DeletedCoin()
    {
        _animator.SetBool("isDestroy", true);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
