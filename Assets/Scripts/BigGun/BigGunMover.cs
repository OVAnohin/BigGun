﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigGunMover : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private Transform _bigGun;
    [SerializeField] private Button _buttonRotateBarrelUp;
    [SerializeField] private Button _buttonRotateBarrelDown;
    [SerializeField] private Button _buttonRotateCarriageLeft;
    [SerializeField] private Button _buttonRotateCarriageRight;

    private float _step = 2;
    private float _maxAngleInclination = 80;
    private float _maxAngleElevation = 2;

    private void OnEnable()
    {
        _buttonRotateBarrelUp.onClick.AddListener(OnButtonRotateBarrelUpClick);
        _buttonRotateBarrelDown.onClick.AddListener(OnButtonRotateBarrelDownClick);
        _buttonRotateCarriageLeft.onClick.AddListener(OnButtonRotateCarriageLeftClick);
        _buttonRotateCarriageRight.onClick.AddListener(OnButtonRotateCarriageRightClick);
    }

    private void OnDisable()
    {
        _buttonRotateBarrelUp.onClick.RemoveListener(OnButtonRotateBarrelUpClick);
        _buttonRotateBarrelDown.onClick.RemoveListener(OnButtonRotateBarrelDownClick);
        _buttonRotateCarriageLeft.onClick.RemoveListener(OnButtonRotateCarriageLeftClick);
        _buttonRotateCarriageRight.onClick.RemoveListener(OnButtonRotateCarriageRightClick);
    }

    private void Awake()
    {
        _gunBarrel.rotation *= Quaternion.Euler(45, 45, 0);
    }
    private void OnButtonRotateBarrelUpClick()
    {
        if (_gunBarrel.rotation.eulerAngles.x >= _maxAngleElevation)
            _gunBarrel.rotation *= Quaternion.Euler(-_step, 0, 0);
    }

    private void OnButtonRotateBarrelDownClick()
    {
        if (_gunBarrel.rotation.eulerAngles.x <= _maxAngleInclination)
            _gunBarrel.rotation *= Quaternion.Euler(_step, 0, 0);
    }

    private void OnButtonRotateCarriageLeftClick()
    {
        _bigGun.rotation *= Quaternion.Euler(0, -_step, 0);
    }

    private void OnButtonRotateCarriageRightClick()
    {
        _bigGun.rotation *= Quaternion.Euler(0, _step, 0);
    }
}
