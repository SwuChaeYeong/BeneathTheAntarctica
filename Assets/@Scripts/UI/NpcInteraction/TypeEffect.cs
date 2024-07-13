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
        //���� ���¿��� ����
        msgText.text = "";
        index = 0;
        endSpace.SetActive(false);

        interval = 1.0f / cps;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        //�� ��µǸ� ����
        if (targetText == msgText.text)
        {
            EffectEnd();
            return;
        }
        
        msgText.text += targetText[index];
        index++;
        
        //��� ȣ��
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        endSpace.SetActive(true);
    }
}
