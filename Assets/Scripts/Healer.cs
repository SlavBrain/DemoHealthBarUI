
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Healer : MonoBehaviour
{
    [SerializeField] private int _healPower=10;
    private Button _button;

    public delegate void SendHeal(int healPower);
    public event SendHeal Healed;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DoHeal);
    }

    private void DoHeal()
    {
        Healed?.Invoke(_healPower);
    }
}
