using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    instance = singleton.AddComponent<T>();
                }
            }    
            return instance;
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(GetRootGameObject(gameObject));
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private GameObject GetRootGameObject(GameObject obj)
    {
        if (obj.transform.parent != null)
        {
            return GetRootGameObject(obj.transform.parent.gameObject);
        }
        return obj;
    }
}
