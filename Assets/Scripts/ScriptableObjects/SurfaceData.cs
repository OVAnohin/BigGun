using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SurfaceData : ScriptableObject
{
    [SerializeField] protected float _absorption;

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
