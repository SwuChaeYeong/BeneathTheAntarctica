using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Npc : MonoBehaviour
{
    //NPC 상호작용 키
    private KeyCode interactionKey = KeyCode.F;

    [SerializeField] private Image pressKeyImg;
    [SerializeField] private GameObject selectedImg;

    [SerializeField] private UIManager uiManager;

    [Header("NPC Number")]
    [SerializeField] private int npcID;

    private void Start()
    {
        selectedImg.transform.DOScale(0.65f, 0.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    //범위 내로 플레이어 진입
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            selectedImg.SetActive(true);

            pressKeyImg.transform.DOLocalMoveY(2.0f, 0.25f).SetEase(Ease.Linear);
            pressKeyImg.DOFade(1f, 0.25f).SetEase(Ease.Linear);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyUp(interactionKey))
            {
                //대화창 열기
                uiManager.OpenDialogPanel();

                //해당 NPC 아이디 보냄
                uiManager.DialogAction(npcID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            selectedImg.SetActive(false);

            pressKeyImg.transform.DOLocalMoveY(1.0f, 0.3f).SetEase(Ease.Linear);
            pressKeyImg.DOFade(0f, 0.25f).SetEase(Ease.Linear);
        }
    }
}
