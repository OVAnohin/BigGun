using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    [SerializeField] private SurfaceData _surfaceData;

    public float Absorption => _surfaceData.Absorption;
}
