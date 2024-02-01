using System;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _low;
    [SerializeField] private Color _hight;
    [SerializeField] private Transform _target;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.transform.position;

        _slider.value = _slider.maxValue;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = _target.transform.position + _offset;
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        _slider.value = health;
        _slider.maxValue = maxHealth;

        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _hight, _slider.normalizedValue);
    }
}
