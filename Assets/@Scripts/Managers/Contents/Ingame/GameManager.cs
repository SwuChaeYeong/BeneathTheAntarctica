using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class GameManager
{
    public void Init()
    {
        Debug.Log("GameManager - Init()");
        // 리소스 로딩은 Loading 씬에서부터 진행되고, 모든 씬에서 가지고 있어야 함. 나중에 Loading씬으로 이동
        ResourceManager.Instance.LoadAllAsync<GameObject>("Prefab", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");
            
            if(count==totalCount)
                PortalManager.Instance.Init();
        });
        Debug.Log("Before PlayerController.Instance.Init()");
        PlayerController.Instance.Init();
        SpawnManager.Instance.Init();
        PoolManager.Instance.Init();
    }
}
