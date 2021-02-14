using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _surfaces;

    private int minX = -25;
    private int maxX = 25;
    private int minY = 2;
    private int maxY = 30;
    private int minZ = -15;
    private int maxZ = 55;

    private void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        int end = Random.Range(20, 50);
        for (int i = 0; i < end; i++)
        {
            int item = Random.Range(0, _surfaces.Length);
            GameObject surface = _surfaces[item];
            var spawned = Instantiate(surface);
            Vector3 position = transform.position + new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            Vector3 eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)); 
            spawned.transform.position = position;
            spawned.transform.eulerAngles = eulerAngles;
        }
    }
}
