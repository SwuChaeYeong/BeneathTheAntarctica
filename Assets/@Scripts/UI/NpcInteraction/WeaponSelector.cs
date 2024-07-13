using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    
    private void Start()
    {
        StartScaleAnim();
    }

    private void StartScaleAnim()
    {
        transform.DOScale(1.1f, 0.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    public void ChangePosition(int slotNum)
    {
        transform.position = slots[slotNum].position;
    }
}
