using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothSliderHealthBar : MonoBehaviour
{
    [SerializeField] private Health _damageController;
    [SerializeField] private float _reduceSpeed = 35f;

    public Slider HealthSlider { get; private set; }

    public void Start()
    {
        HealthSlider = GetComponent<Slider>();
    }

    public void Update()
    {
        HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, _damageController.CurrentHealthValue, _reduceSpeed * Time.deltaTime);
    }
}
