using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _sliderSpeed=3;

    private Slider _slider;
    private Coroutine _sliding;    

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHP;
        _slider.value = _slider.maxValue;
        _player.ChandgedHP += ChandgeSliderValue;
    }

    private void Update()
    {
    }
    private void ChandgeSliderValue(int value)
    {
        if (_sliding != null)
        {
            StopCoroutine(_sliding);
        }

        _sliding=StartCoroutine(MovingSlider(value));
    }

    private IEnumerator MovingSlider(int endValue)
    {
        while (_slider.value != endValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, endValue, Time.deltaTime * _sliderSpeed);
            yield return null;
        }
    }
}
