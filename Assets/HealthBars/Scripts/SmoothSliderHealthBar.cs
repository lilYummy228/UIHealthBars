using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothSliderHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _reduceSpeed = 10f;

    private Slider _healthSlider;

    private void OnEnable()
    {
        _health.CurrentHealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= ChangeValue;
    }

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        _healthSlider.value = _health.CurrentHealthValue;
    }

    public void ChangeValue()
    {
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while (_healthSlider.value != _health.CurrentHealthValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _health.CurrentHealthValue, _reduceSpeed * Time.deltaTime);
            yield return new WaitWhile(() => _healthSlider.value == _health.CurrentHealthValue);
        }
    }
}
