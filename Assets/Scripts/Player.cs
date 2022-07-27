using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int MaxHP { get; private set; } = 200;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Healer _healer;

    [SerializeField] public int _currentHP;

    public delegate void ActionThisHP(int HP);
    public event ActionThisHP ChandgedHP;

    private void Start()
    {
        _currentHP = MaxHP;
        _enemy.Attacked += TakeDamage;
        _healer.Healed += Heal;
    }

    private void TakeDamage(int damage)
    {
        if (_currentHP > 0)
        {
            _currentHP -= damage;

            if (_currentHP <= 0)
            {
                _currentHP = 0;
            }

            ChandgedHP?.Invoke(_currentHP);
        }
    }

    private void Heal(int healPower)
    {
        

        if (_currentHP < MaxHP)
        {
            _currentHP += healPower;

            if (_currentHP > MaxHP)
            {
                _currentHP = MaxHP;
            }

            ChandgedHP?.Invoke(_currentHP);
        }        
    }
}
