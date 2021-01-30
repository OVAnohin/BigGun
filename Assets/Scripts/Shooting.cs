using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _surface;

    private Plane _plane;

    private void Update()
    {
        RaycastHit hit;
        //Physics.Raycast(transform.position, transform.up);
        //Debug.DrawRay(transform.position, transform.up * 10, Color.red);
        //Debug.Log(hit);
        //if (Physics.Raycast(_shootPoint.position, _shootPoint.up, out hit))
        //{
        //    Debug.DrawRay(_shootPoint.position, _shootPoint.up * hit.distance, Color.yellow);
        //    //Debug.Log(hit.distance);
        //    //Debug.Log(hit.point);
            
        //    _plane = hit.collider.GetComponent<QuadObject>().Plane;
        //    Vector3 normal = _plane.normal;
        //    Debug.Log(normal);
        //    Debug.DrawRay(hit.point, normal * 2, Color.red);
        //}

        //Ray ray = Camera.main.ScreenPointToRay(_shootPoint.position);
        //float t = 0.01f;

        //if (_plane.Raycast(ray, out t))
        //{
        //    Vector3 vector = ray.GetPoint(t);
        //    Debug.Log(vector);
        //}
    }
}
