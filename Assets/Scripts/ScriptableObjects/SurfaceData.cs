using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SurfaceData", menuName = "Surface/New Surface", order = 51)]
public class SurfaceData : ScriptableObject
{
    [SerializeField] private float _absorption;

    public float Absorption 
    {
        get 
        {
            if (_absorption < 0)
                return 0;

            return _absorption;
        }
    }
}
