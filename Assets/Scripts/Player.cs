using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int MaxHP { get; private set; } = 200;

    public delegate void Action(int HP);
    public event Action ChandgedHP;

    private int _currentHP;    

    private void Start()
    {
        _currentHP = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHP > 0)
        {
            _currentHP -= damage;

            _currentHP = Mathf.Clamp(_currentHP, 0, MaxHP);

            ChandgedHP?.Invoke(_currentHP);
        }
    }

    public void Heal(int healPower)
    {
        if (_currentHP < MaxHP)
        {
            _currentHP += healPower;

            _currentHP = Mathf.Clamp(_currentHP, 0, MaxHP);

            ChandgedHP?.Invoke(_currentHP);
        }        
    }
}
