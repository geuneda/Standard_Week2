using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public string name;
        public int size = 300;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.name, objectPool);
        }
    }

    public GameObject Get(string name)
    {
        if (!PoolDictionary.ContainsKey(name))
        {
            return null;
        }

        GameObject obj = PoolDictionary[name].Dequeue();
        PoolDictionary[name].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}