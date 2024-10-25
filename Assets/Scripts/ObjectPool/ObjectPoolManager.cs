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

    public List<Pool> pools;  // ���� ���� Ǯ�� �����ϴ� ����Ʈ
    private Dictionary<string, Queue<GameObject>> poolDictionary;  // Ǯ�� �̸��� Ű��, ť�� ������ ���� ��ųʸ�

    private void Awake()
    {
        InitializePools();
    }

    // �� Ǯ�� �ʱ�ȭ�ϴ� �޼ҵ�
    private void InitializePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = CreatePool(pool);
            poolDictionary.Add(pool.name, objectPool);
        }
    }

    // �� Ǯ�� ������Ʈ�� �����Ͽ� ť�� ��ȯ�ϴ� �޼ҵ�
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

    // ������Ʈ�� Ǯ���� �������� �޼ҵ�
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

    // ������Ʈ�� ��Ȱ��ȭ�Ͽ� Ǯ�� ��ȯ�ϴ� �޼ҵ�
    public void ReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
