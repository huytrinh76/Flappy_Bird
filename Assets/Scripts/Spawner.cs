using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Murdock.Core
{
    public class Spawner : MonoBehaviour
    {
        private float _repeatRate = 1f;
        private float _minHeight = -1f;
        private float _maxHeight = 1f;
        
        private void OnEnable()
        {
            InvokeRepeating(nameof(SpawnObject), _repeatRate, _repeatRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnObject));
        }

        private void SpawnObject()
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject();
            obj.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }
}