using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealthValue;
    public event Action CurrentHealthChanged;

    public int MaxHealthValue { get; private set; }

    private void Awake()
    {
        MaxHealthValue = CurrentHealthValue;
    }

    public void Heal(int healValue)
    {
        CurrentHealthValue += healValue;

        if (CurrentHealthValue > MaxHealthValue)
            CurrentHealthValue = MaxHealthValue;

        CurrentHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealthValue -= damage;

        if (CurrentHealthValue <= 0)
            CurrentHealthValue = 0;

        CurrentHealthChanged?.Invoke();
    }
}
