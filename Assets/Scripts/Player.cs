using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int MaxHP { get; private set; } = 200;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Healer _healer;

    [SerializeField] public int CurrentHP { get; private set; }

    public delegate void ActionThisHP(int HP);
    public event ActionThisHP ChandgedHP;

    private void Start()
    {
        CurrentHP = MaxHP;
        _enemy.Attacked += TakeDamage;
        _healer.Healed += Heal;
    }

    private void TakeDamage(int damage)
    {
        if (CurrentHP > 0)
        {
            CurrentHP -= damage;

            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
            }

            ChandgedHP?.Invoke(CurrentHP);
        }
    }

    private void Heal(int healPower)
    {
        

        if (CurrentHP < MaxHP)
        {
            CurrentHP += healPower;

            if (CurrentHP > MaxHP)
            {
                CurrentHP = MaxHP;
            }

            ChandgedHP?.Invoke(CurrentHP);
        }        
    }
}
