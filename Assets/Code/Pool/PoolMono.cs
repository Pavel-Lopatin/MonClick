using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonClick.Code.Pool
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public T _prefab { get; }
        public bool _autoExpand { get; set; }
        public Transform _container { get; }

        private List<T> _pool;

        public PoolMono(T prefab, int count)
        {
            _prefab = prefab;
            _container = null;

            CreatePool(count);
        }

        public PoolMono(T prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAllElements()
        {
            foreach (var mono in _pool)
            {
                mono.gameObject.SetActive(false);
            }
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception($"There is now free elements if pool of type {typeof(T)}");
        }
    }
}


