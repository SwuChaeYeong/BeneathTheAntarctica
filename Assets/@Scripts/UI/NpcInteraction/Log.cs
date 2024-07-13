using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Log : MonoBehaviour
{
    private Coroutine displayCoroutine;
    private float displayTime = 6f;
    
    private void OnEnable()
    {
        StartCoroutine(LogAnimCoroutine());
    }

    IEnumerator LogAnimCoroutine()
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
        UIManager.Instance.DequeueLog(gameObject);
    }
}
