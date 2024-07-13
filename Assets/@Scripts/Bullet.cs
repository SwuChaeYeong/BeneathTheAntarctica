using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Revolver revolver;
    private float bulletSpeed = 70.0f;
    private Vector3 direction;

    private int damage;


    public void Init(Vector3 targetPosition, int damage)
    {
        direction = (targetPosition - transform.position).normalized;
        //direction = targetPosition;
        this.damage = damage;
    }

    public void SetRevolver(Revolver revolver)
    {
        this.revolver = revolver;
    }

    private void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Damaged(damage);
            revolver.ReturnBullet(gameObject);
        }

        if (other.CompareTag("wall"))
        {
            revolver.ReturnBullet(gameObject);
        }

        if (other.CompareTag("ore"))
        {
            other.GetComponent<Ore>().Damaged(damage);
            revolver.ReturnBullet(gameObject);
        }
    }
}