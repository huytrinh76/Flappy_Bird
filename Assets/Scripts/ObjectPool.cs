using System.Collections.Generic;
using UnityEngine;

namespace Murdock.Core
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;
        [SerializeField] private List<GameObject> pooledObjects;
        [SerializeField] private GameObject pipesPrefab;
        public int amountToPool = 5;

        void Awake()
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
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = SpawnObject();
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject()
        {
            foreach (var t in pooledObjects)
            {
                if (!t.activeInHierarchy)
                {
                    t.SetActive(true);
                    t.transform.position = transform.position;
                    return t;
                }
            }

            GameObject obj = SpawnObject();
            pooledObjects.Add(obj);
            return obj;
        }

        GameObject SpawnObject() => Instantiate(pipesPrefab, transform);
    }
}