using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private string trapName;
    private void OnParticleCollision(GameObject other)
    {
        if (trapName == "WaterBomb")
        {
            
            PlayerController.Instance.isHit = true;   

            Debug.Log(PlayerController.Instance.isHit);
            Debug.Log(PlayerController.Instance.isInvincible);

            if (PlayerController.Instance.isHit && !PlayerController.Instance.isInvincible)
            {
                //최대 체력 20% + *무적 시간 필요함
                PlayerController.Instance.Damaged((int)(LevelManager.Instance.GetMaxHp() * 0.2f));
            }
        }
        else if (trapName == "Gas")
        {
            //1틱당 산소게이지 1%
            OXManager.Instance.DamagedOX(1);
        }
    }
}
