using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IDLE,
    WALK,
    ATTACK,
    DIE
}

public class Enemy : MonoBehaviour
{
    private int hp;
    private int atk;
    private float spd;

    EnemyState enemyState;

    private Transform playerPos;

    private Vector2 tmpDircetion;

    private bool isAtk = false;

    private float distance;

    [SerializeField] private Animator monsterAnim;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        SetState(EnemyState.WALK);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(int hp, int atk, float spd)
    {
        this.hp = hp;
        this.atk = atk;
        this.spd = spd;

        playerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, playerPos.position);
        if(distance >= 0.75f && isAtk)
        {
            isAtk = false;
            SetState(EnemyState.WALK);
            StopCoroutine(Attack());
        }
    }
    public void SetState(EnemyState enemyState)
    {
        this.enemyState = enemyState;

        switch(enemyState)
        {
            case EnemyState.WALK:
                StartCoroutine(Walk());
                break;

            case EnemyState.ATTACK:
                StartCoroutine(Attack());
                break;
        }
    }

    public void Idle()
    {

    }

    public IEnumerator Walk()
    {
        while(!isAtk)
        {
            tmpDircetion = (playerPos.position - transform.position).normalized;
            transform.Translate(tmpDircetion * spd * Time.deltaTime);
            yield return null;
            
            if (tmpDircetion.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }

            if(distance < 0.75f )
            {
                isAtk = true;
                SetState(EnemyState.ATTACK);
                break;
            }
        }
        yield return null;
    }

    public IEnumerator Attack()
    {
        while(isAtk)
        {
            if (distance >= 0.75f)
            {
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void Damaged(int damage)
    {
        hp = -damage;

        if (hp <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
