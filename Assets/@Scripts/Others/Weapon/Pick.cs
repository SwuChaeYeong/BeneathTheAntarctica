using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pick : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 _mousePosition;

    public LayerMask oreLayer;
    private float maxDistance = 1.2f;

    private bool isAttacking;

    public Animator attackAnim;

    private float pickRate = 1f; // 곡괭이질 딜레이
    private float pickTimer = 0f; // 공격 타이머
    private float nextPickTime = 0f; // 다음 공격 시간

    private void Awake()
    {
        mainCamera = Camera.main;
        attackAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        isAttacking = false;
    }

    private void OnDisable()
    {
        transform.localEulerAngles = new Vector3(0,0,0);
    }
    
    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시
        if (Input.GetMouseButtonDown(0) && Time.time >= nextPickTime)
        {
            // 일단 휘두름
            attackAnim.SetTrigger("isAttack");
        }
    }
    
    // 곡괭이 애니메이션에 달려있는 함수
    private void AttackOre()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero, Mathf.Infinity, oreLayer);

        nextPickTime = Time.time + pickRate;
        
        if (hit.collider != null)
        {
            float distance = Vector2.Distance(transform.position, hit.collider.transform.position);

            if (distance <= maxDistance)
            {
                // 마우스에 맞은애가 광물이라면
                if (hit.collider.GetComponent<Ore>())
                {
                    hit.collider.GetComponent<Ore>().Damaged(15);
                }

                // 마우스에 맞은애가 몬스터라면?
                if (hit.collider.GetComponent<Enemy>())
                {
                    hit.collider.GetComponent<Enemy>().Damaged(1);
                }
            }
        }
    }
}
