using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BigGun : MonoBehaviour
{
    [SerializeField] private TMP_InputField _rangeField;
    [SerializeField] private TMP_InputField _powerField;

    public event UnityAction<float> Ranging;
    public event UnityAction<float> Powering;

    private float _range = 10;
    private float _power = 10;

    private void OnEnable()
    {
        _rangeField.onValueChanged.AddListener(OnRangeValueChange);
        _powerField.onValueChanged.AddListener(OnPowerValueChange);
    }

    private void OnDisable()
    {
        _rangeField.onValueChanged.RemoveListener(OnRangeValueChange);
        _powerField.onValueChanged.RemoveListener(OnPowerValueChange);
    }

    private void Start()
    {
        _rangeField.text = _range.ToString();
        _powerField.text = _power.ToString();
        Ranging?.Invoke(_range);
        Powering?.Invoke(_power);
    }

    private void OnRangeValueChange(string value)
    {
        _range = (float)Convert.ToDouble(value);
        Ranging?.Invoke(_range);
    }

    private void OnPowerValueChange(string value)
    {
        _power = (float)Convert.ToDouble(value);
        Powering?.Invoke(_power);
    }
}
