using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

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
        _quantity += value;
        _scoreText.text = _quantity.ToString();
    }
}
