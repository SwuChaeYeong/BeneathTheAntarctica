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
            //�ִ� ü�� 20%
        }
        else if (trapName == "Gas")
        {
            //1ƽ�� ��Ұ����� 1%
            OXManager.Instance.DamagedOX(1);
        }
    }
}
