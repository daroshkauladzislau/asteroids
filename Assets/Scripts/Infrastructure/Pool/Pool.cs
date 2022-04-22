using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Pool
{
    public class Pool
    {
        public int ActiveObjectsCount { get; private set; } = 0;

        private Transform _poolParent;
        private Dictionary<int, Stack<GameObject>> _cachedObjects = new Dictionary<int, Stack<GameObject>>();
        private Dictionary<int, int> _cachedId = new Dictionary<int, int>();


        public void SetParent(Transform obj)
        {
            _poolParent = obj;
        }


        public GameObject Spawn(GameObject prefab, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Transform parent = null)
        {
            var key = prefab.GetInstanceID();
            Stack<GameObject> stack;

            var haveStack = _cachedObjects.TryGetValue(key, out stack);

            if (haveStack && stack.Count > 0)
            {
                Transform transform = stack.Pop().transform;
                transform.SetParent(parent);
                transform.rotation = rotation;
                transform.gameObject.SetActive(true);
                ActiveObjectsCount++;
                if (parent)
                {
                    transform.position = position;
                }
                else
                {
                    transform.localPosition = position;
                }
                var poolable = transform.GetComponent<IPoolable>();
                if (poolable != null)
                {
                    poolable.OnSpawn();
                }
                return transform.gameObject;
            }
            if (!haveStack)
            {
                _cachedObjects.Add(key, new Stack<GameObject>());
            }

            var createdPrefab = Populate(prefab, position, rotation, parent);
            _cachedId.Add(createdPrefab.GetInstanceID(), key);
            return createdPrefab;
        }


        public void Despawn(GameObject obj)
        {
            obj.SetActive(false);
            ActiveObjectsCount--;
            _cachedObjects[_cachedId[obj.GetInstanceID()]].Push(obj);
            var poolable = obj.GetComponent<IPoolable>();
            if (poolable != null)
            {
                poolable.OnDespawn();
            }
            if (_poolParent != null)
            {
                obj.transform.SetParent(_poolParent);
            }
        }


        public void Dispose()
        {
            _poolParent = null;
            ActiveObjectsCount = 0;
            _cachedId.Clear();
            _cachedObjects.Clear();
        }


        GameObject Populate(GameObject prefab, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Transform parent = null)
        {
            var go = Object.Instantiate(prefab, position, rotation, parent).transform;
            ActiveObjectsCount++;
            if (parent == null)
            {
                go.position = position;
            }
            else
            {
                go.localPosition = position;
            }
            return go.gameObject;
        }

    }
}