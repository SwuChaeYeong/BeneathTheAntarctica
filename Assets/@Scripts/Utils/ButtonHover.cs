using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.2f, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.1f);
    }

    ///이 밑은 사운드

    public AK.Wwise.Event clickSound;
    public void PlayClickSound()
    {
        clickSound.Post(gameObject);
    }

   
}
