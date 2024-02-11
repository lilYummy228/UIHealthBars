using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _textHealthValue;

    private void OnEnable()
    {
        _health.CurrentHealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= ChangeValue;
    }

    public void Start()
    {
        _textHealthValue = GetComponent<TextMeshProUGUI>();
        _textHealthValue.text = $"{_health.CurrentHealthValue}/{_health.MaxHealthValue}";
    }

    private void ChangeValue()
    {
        _textHealthValue.text = $"{_health.CurrentHealthValue}/{_health.MaxHealthValue}";
    }
}
