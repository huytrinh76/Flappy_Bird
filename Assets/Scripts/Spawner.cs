using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    [SerializeField] private List<GameObject> pooledObjects;
    private int _amountToPool = 10;

    [SerializeField] private GameObject pipesPrefab;
    private float _repeatRate = 1f;
    private float _minHeight = -1f;
    private float _maxHeight = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = SpawnPipes();
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    GameObject SpawnPipes()
    {
        GameObject obj = Instantiate(pipesPrefab, transform);
        obj.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        return obj;
    }
}