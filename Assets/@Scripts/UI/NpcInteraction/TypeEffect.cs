using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] private string targetText;
    [SerializeField] private TMP_Text msgText;
    [SerializeField] private GameObject endSpace;

    //CharPerSeconds;
    public int cps;
    int index;
    float interval;

    public void SetText(string text)
    {
        targetText = text;
        EffectStart();
    }

    void EffectStart()
    {
        //공백 상태에서 시작
        msgText.text = "";
        index = 0;
        endSpace.SetActive(false);

        interval = 1.0f / cps;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        //다 출력되면 리턴
        if (targetText == msgText.text)
        {
            EffectEnd();
            return;
        }
        
        msgText.text += targetText[index];
        index++;
        
        //재귀 호출
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        endSpace.SetActive(true);
    }
}
