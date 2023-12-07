using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public static event Action InInventory;

    private int _quantity;

    private void OnDisable()
    {
        CoinController.IsTakeCoin -= TakeCoin;
    }

    private void OnEnable()
    {
        CoinController.IsTakeCoin += TakeCoin;
    }

    private void TakeCoin(int value)
    {
        InInventory?.Invoke();
        _quantity += value;
        _scoreText.text = _quantity.ToString();
    }
}
