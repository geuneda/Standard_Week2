using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public ObjectPoolManager objectPool;
    public string monsterName = "Monster";
    public Transform spawnPoint;

    public float spawnInterval = 1f;
    public float spawnTime;

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnInterval)
        {
            SpawnMonster();
            spawnTime = 0f;
        }
    }

    private void SpawnMonster()
    {
        GameObject monster = objectPool.GetFromPool(monsterName);
        if (monster != null)
        {
            monster.transform.position = spawnPoint.position;
            monster.GetComponent<Monster>().Initialize(objectPool);
        }
    }
}
