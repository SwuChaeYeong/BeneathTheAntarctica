using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Manager<SpawnManager>
{
    public GameObject enemy;
    public Transform[] spawnPoint;
    public Transform enemyPool;
    
    private int currentWave = 1;

    private int[] enemyNum = {3, 7, 1, 10, 1}; // 5레벨은 보스
    private int[] enemyHp = { 50, 75, 100, 125, 500 };
    private int[] enemyAtk = { 10, 15, 20, 25, 100 };
    private float[] enemySpd = { 1, 1, 1, 1, 3 };
    
    // 나중에, DAO에서 각 광산별 몬스터 및 광물 정보를 가져와서
    // 플레이어가 해당 광산에 입장하면 그 정보로 여기에 뿌려줘야함.

    public void Init()
    {
        EnemySpawn();
    }
    public void EnemySpawn()
    {
        StartCoroutine(EnemySpawnCo());
    }

    private IEnumerator EnemySpawnCo()
    {
        Debug.Log("EnemySpawnCo");
        for(int i=0; i<enemyNum[currentWave-1]; i++) // 오브젝트 풀링의 기초
        {
            GameObject enemy = enemyPool.GetChild(i).gameObject;
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint[i].transform.position;
            enemy.GetComponent<Enemy>().Init(enemyHp[currentWave - 1], enemyAtk[currentWave - 1], enemySpd[currentWave - 1]);
            yield return new WaitForSeconds(.5f);
        }
        yield return null;
    }
}
