using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _power;

    public float Range => _range;
    public float Power => _power;
}
