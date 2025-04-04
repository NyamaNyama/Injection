using System;
using UnityEngine;

public class ManagerInit : MonoBehaviour
{
    public static ManagerInit Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitGameManagers()
    {
        if (Instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>("MANAGERS");
            if (prefab != null)
            {
                Instantiate(prefab);
            }
        }
        
    }
}
