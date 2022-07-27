
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Enemy : MonoBehaviour
{
    [SerializeField]private int _damage=20;
    private Button _button;   

    public delegate void SendDamage(int damage);
    public event SendDamage Attacked;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DoAttack);
    }

    private void DoAttack()
    {
        Attacked?.Invoke(_damage);
    }
}
