using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BigGun))]
public class Shooting : LinesPool
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _barrel;
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Button _fireButton;
    [SerializeField] private float _disappearanceTime;

    private float _power;
    private float _ragne;
    private List<Path> _paths;

    private void OnEnable()
    {
        _fireButton.onClick.AddListener(OnFireButtonClick);
    }

    private void OnDisable()
    {
        _fireButton.onClick.RemoveListener(OnFireButtonClick);
    }

    private void Start()
    {
        _power = GetComponent<BigGun>().Power;
        _ragne = GetComponent<BigGun>().Range;

        Initialize(_linePrefab);
    }

    private void OnFireButtonClick()
    {
        _paths = new List<Path>();
        CalculationTrajectory();

        foreach (var path in _paths)
        {
            if (TryGetObject(out GameObject element))
            {
                SetLine(element, path.StartPoint, path.EndPoint, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                StartCoroutine(DrawLine(element));
            }
        }
    }

    private void SetLine(GameObject prefab, Vector3 startPoint, Vector3 endPoint, Color color)
    {
        LineRenderer line = prefab.GetComponent<LineRenderer>();
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
        line.startWidth = 0.15f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = color;
        prefab.SetActive(true);
    }

    private void CalculationTrajectory()
    {
        Vector3 direction = _barrel.up.normalized;
        Vector3 magnitude = direction * _ragne;
        Vector3 startPoint = _shootPoint.position;
        Vector3 endPoint;
        Path path;
        float remainingDistance = _ragne;
        float remainingPower = _power;
        RaycastHit hit;

        while (remainingDistance > 0 && remainingPower > 0)
        {
            if (Physics.Raycast(startPoint, direction, out hit, remainingDistance))
            {
                endPoint = hit.point;
                path = new Path(startPoint, endPoint);
                _paths.Add(path);

                direction = CalculationReflection(magnitude, hit.normal);
                remainingDistance -= (endPoint - startPoint).magnitude;
                startPoint = hit.point;
                magnitude = direction * remainingDistance;
                remainingPower -= hit.collider.GetComponent<Surface>().Absorption;
            }
            else
            {
                remainingDistance = 0;
                path = new Path(startPoint, startPoint + magnitude);
                _paths.Add(path);
            }
        }
    }

    private IEnumerator DrawLine(GameObject prefab)
    {
        float elapsedTime = _disappearanceTime;

        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            yield return null;
        }

        prefab.SetActive(false);
    }

    private Vector3 CalculationReflection(Vector3 incomingVector, Vector3 normalVector)
    {
        float dot = Vector3.Dot(incomingVector.normalized, normalVector) * 2;

        return incomingVector.normalized - normalVector * dot;
    }

    private struct Path
    {
        public Vector3 StartPoint { get; private set; }
        public Vector3 EndPoint { get; private set; }

        public Path(Vector3 startPoint, Vector3 endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
