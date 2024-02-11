using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _damageController;

    private TextMeshProUGUI _textHealthValue;

    public void Start()
    {
        _textHealthValue = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textHealthValue.text = $"{_damageController.CurrentHealthValue}/{_damageController.MaxHealthValue}";
    }
}
