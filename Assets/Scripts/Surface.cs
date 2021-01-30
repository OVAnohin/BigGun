using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    [SerializeField] private float _absorption;

    public float Absorption => _absorption;

    private void Start()
    {
        if (_absorption < 0)
            _absorption = 0;
    }
}
