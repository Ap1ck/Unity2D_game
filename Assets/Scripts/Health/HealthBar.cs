using System;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _low;
    [SerializeField] private Color _hight;

    private void Start()
    {
        _slider.value = _slider.maxValue;
    }

    public void SetHealth(float health, float maxHealth)
    {
        _slider.value = health;
        _slider.maxValue = maxHealth;

        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _hight, _slider.normalizedValue);
    }
}
