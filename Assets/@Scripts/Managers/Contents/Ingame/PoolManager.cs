using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Bullets
{
    PISTOL = 1
}

public class PoolManager : Manager<PoolManager>
{
    [Header("PoolParent")]
    [SerializeField] private Transform poolParent; // Pool로 사용할 모든 오브젝트들의 최상위 객체
    
    [Header("DamagePool")]
    [SerializeField] private Transform damageTextPool; // 데미지 텍스트들의 풀
    [SerializeField] private TextMeshProUGUI damageText;
    private GameObject damagePrefab;
    private Queue<TextMeshProUGUI> damagePool;
    private int damagePoolSize = 15;
    
    [Header("MonsterPool")]
    [SerializeField] private Transform monsterPool; // 몬스터들의 풀

    
    /// <summary>
    /// 각 Pool은 Prefab GameObject로 보관했다가, 초기화 시점에
    /// "Game"씬에서 사용할 모든 풀들을 메모리에 올려놓는 역할을 한다.
    /// </summary>
    public void Init()
    {
        // 1. ResourceManager에서 필요한 Prefab들을 불러온다.
        // damagePrefab = ResourceManager.Instance.Load<GameObject>("DamageText.prefab");

        //CreateDamageTextPool();
    }

    private void CreateDamageTextPool()
    {
        damagePool = new Queue<TextMeshProUGUI>();
        
        for (int i = 0; i < damagePoolSize; i++)
        {
            TextMeshProUGUI text = Instantiate(damageText, damageTextPool);
            text.gameObject.SetActive(false);
            damagePool.Enqueue(text);
        }
    }
    
    public void ReturnDamageText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(false);
        damagePool.Enqueue(text);
    }
}
