using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private ObjectPool objectPool;

    public void Initialize(ObjectPool pool)
    {
        objectPool = pool;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        objectPool.Release(gameObject);
    }
}
