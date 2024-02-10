using System.Collections;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private Material _hurtBlinkMaterial;
    [SerializeField] private Material _healBlinkMaterial;

    public int CurrentHealthValue;

    public int MaxHealthValue { get; private set; }

    private WaitForSeconds _wait;
    private Material _defaultMaterial;
    private SpriteRenderer _spriteRenderer;
    private float _blinkTime = 0.2f;

    private void Start()
    {
        if (gameObject.TryGetComponent(out SpriteRenderer spriteRenderer))
            _spriteRenderer = spriteRenderer;

        _wait = new WaitForSeconds(_blinkTime);

        _defaultMaterial = _spriteRenderer.material;

        MaxHealthValue = CurrentHealthValue;
    }

    public void Heal(int healValue)
    {
        CurrentHealthValue += healValue;

        StartCoroutine(HealBlink());

        if (CurrentHealthValue > MaxHealthValue)
            CurrentHealthValue = MaxHealthValue;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealthValue -= damage;

        StartCoroutine(HurtBlink());

        if (CurrentHealthValue <= 0)
            Dead();
    }

    private IEnumerator HurtBlink()
    {
        _spriteRenderer.material = _hurtBlinkMaterial;

        yield return _wait;

        _spriteRenderer.material = _defaultMaterial;
    }

    private IEnumerator HealBlink()
    {
        _spriteRenderer.material = _healBlinkMaterial;

        yield return _wait;

        _spriteRenderer.material = _defaultMaterial;
    }

    private void Dead()
    {
        enabled = false;

        Destroy(gameObject);
    }
}
