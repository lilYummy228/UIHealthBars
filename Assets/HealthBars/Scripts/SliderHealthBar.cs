using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

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

    public virtual void ChangeValue()
    {
        _healthSlider.value = _health.CurrentHealthValue;
    }
}
