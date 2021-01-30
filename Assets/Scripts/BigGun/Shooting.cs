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
    private Vector3 _direction;
    private Vector3 _magnitude;

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
        Initialize(_linePrefab);
    }

    private void OnFireButtonClick()
    {
        if (TryGetObject(out GameObject element))
        {
            CalculationTrajectory();
            SetLine(element, _shootPoint.position, _shootPoint.position + _magnitude, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            StartCoroutine(DrawLine(element));
        }
    }

    private void SetLine(GameObject prefab, Vector3 startPoint, Vector3 endPoint, Color color)
    {
        LineRenderer line = prefab.GetComponent<LineRenderer>();
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
        line.SetWidth(0.15f, 0.15f);
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.SetColors(color, color);
        prefab.SetActive(true);
    }

    private void CalculationTrajectory()
    {
        _power = GetComponent<BigGun>().Power;
        _ragne = GetComponent<BigGun>().Range;
        _direction = _barrel.up.normalized;
        _magnitude = _direction * _ragne;
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
}
