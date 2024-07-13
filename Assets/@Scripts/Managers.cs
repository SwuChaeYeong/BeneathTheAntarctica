using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static bool s_init = false;

    private void Awake()
    {
        Game.Init();
        UIManager.Instance.Init();
    }

    #region Contents
    // GameManager가 매니저들의 첫 시작
    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance?._game; } }
    private ObjectManager _object = new ObjectManager();
    public static ObjectManager Object { get { return Instance?._object; } }
    #endregion

    #region Core

    #endregion
    public static Managers Instance
    {
        get
        {
            if (s_init == false)
            {
                s_init = true;
                Debug.Log("s_init");
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject() { name = "@Managers" };
                    go.AddComponent<Managers>();
                }
                
                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();
            }
            Debug.Log("Before return s_instance");
            return s_instance;
        }
    }
}
