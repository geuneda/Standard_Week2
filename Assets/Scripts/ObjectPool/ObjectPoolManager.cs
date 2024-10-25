using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public string name;
        public int size = 300;
    }

    public List<Pool> pools;  // 여러 개의 풀을 관리하는 리스트
    private Dictionary<string, Queue<GameObject>> poolDictionary;  // 풀의 이름을 키로, 큐를 값으로 갖는 딕셔너리

    private void Awake()
    {
        InitializePools();
    }

    // 각 풀을 초기화하는 메소드
    private void InitializePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = CreatePool(pool);
            poolDictionary.Add(pool.name, objectPool);
        }
    }

    // 각 풀의 오브젝트를 생성하여 큐로 반환하는 메소드
    private Queue<GameObject> CreatePool(Pool pool)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        return objectPool;
    }

    // 오브젝트를 풀에서 가져오는 메소드
    public GameObject GetFromPool(string poolName)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning("Pool with name " + poolName + " doesn't exist.");
            return null;
        }

        GameObject objectToUse = poolDictionary[poolName].Dequeue();
        poolDictionary[poolName].Enqueue(objectToUse);
        objectToUse.SetActive(true);
        return objectToUse;
    }

    // 오브젝트를 비활성화하여 풀로 반환하는 메소드
    public void ReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
