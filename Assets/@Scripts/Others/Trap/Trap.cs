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
                        PlayerController.Instance.Damaged((int)(LevelManager.Instance.GetCurrentHp() * 0.2));
        }
        else if (trapName == "Gas")
        {
            //1틱당 산소게이지 1%
            OXManager.Instance.DamagedOX(1);
        }
    }
}
