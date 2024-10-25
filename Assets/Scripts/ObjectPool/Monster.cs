using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private ObjectPoolManager objectPool;

    public void Initialize(ObjectPoolManager pool)
    {
        objectPool = pool;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        objectPool.ReleaseToPool(gameObject);
    }
}
