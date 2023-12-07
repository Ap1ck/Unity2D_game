using System;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private Canvas _loseCanvas;

    public static event Action OnDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Lose");
            OnDestroy?.Invoke();
            _loseCanvas.gameObject.SetActive(true);
        }
    }
}
