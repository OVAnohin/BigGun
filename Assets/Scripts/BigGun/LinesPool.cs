using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();
    private GameObject _prefab;

    protected void Initialize(GameObject prefab)
    {
        _prefab = prefab;

        for (int i = 0; i < _capacity; i++)
            SpawnPrefab(_prefab);
    }

    private void SpawnPrefab(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected GameObject GetObject()
    {
        GameObject result;
        result = _pool.Find(p => p.activeSelf == false);

        if (result == null)
            SpawnPrefab(_prefab);

        return result;
    }
}
