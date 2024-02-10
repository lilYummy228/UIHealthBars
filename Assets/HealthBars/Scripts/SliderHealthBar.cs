using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : MonoBehaviour
{
    [SerializeField] private DamageController _damageController;

    public Slider HealthSlider { get; private set; }

    public virtual void Start()
    {
        HealthSlider = GetComponent<Slider>();
    }

    public virtual void Update()
    {
        HealthSlider.value = _damageController.CurrentHealthValue;
    }
}
