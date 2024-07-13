using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;
using TMPro;

public class DialogUI : MonoBehaviour
{
    //�������� ������
    private List<string[]> blackSmithData;
    //���� ������
    private List<string[]> traderData;

    //NPC �ĺ� ���
    private const int BLACK_SMITH = 0;
    private const int TRADER = 1;

    [Header("NPC Image")]
    [SerializeField] private Sprite blackSmith;
    [SerializeField] private Sprite trader;

    public void Awake()
    {
        //����Ʈ �ʱ�ȭ
        blackSmithData = new List<string[]>();
        traderData = new List<string[]>();

        GenerateData();
    }

    private void GenerateData()
    {
        ////��������
        //�⺻ ���
        blackSmithData.Add(new string[] { "�����. ���� ������ �� �ִ°�?" });

        //���� ���
        blackSmithData.Add(new string[] { "���� C~S����� ���� �з��Ǿ� ����. ����� ��ް� ��ȭ�ܰ迡 ���� �Һ�Ǵ� �ݾװ� ���� �޶����� ������ ���� �䱸�Ǵ� �ݾװ� ��� ���� �������ٳ�.",
                                        "���� Ư�� ���������� ���� �������� �������ִ� ������ �������� �ǳ�.\n�ٸ� �������� �����ϰ� �������� �ٸ��ٴϱ�?",
                                        "�׸��� �� �ؾ��� ���� �� ǥ�� ����. ��ȭ�� �����ص� ��� �ı����� �ʴ´ٰ�.\n������ ������ �߸��Ǿ����� �˾Ƴ��� ������ Ȯ���� �ö󰣴ٳ�.",
                                        "������ �� �� �غ��ڳ�? �̸� �ຸ��."});

        //���� ���
        blackSmithData.Add(new string[] { "�׷�, ������ �� �ʿ��� �� ���� �� �����." });


        ////����
        //�⺻ ���
        traderData.Add(new string[] { "���! '�г���' ������ �� �־�?" });

        //���� ���
        traderData.Add(new string[] { "���� �����̶� �װ� ���꿡�� ĳ�� ���� ������ ���� �ָ� ������ ���� ���� �� �ž�.\n����� ���� ���� �����ϼ��� �� ���� ���� �ְ���?.",
                                        "�׸��� ���� ������ �������� ��� �������� ���� �ž�.\n�׷� ���� ����ؼ� ������ ������� � �� ���� ��� ������ ���� �ž�!",
                                        "�Ӹ� �ƴ϶� ���� ��� ���迡 ������ �� ���� ���ǵ��� ������ ������ ������ �����Ϸ� ��!",
                                        "�� ���� �迡 ������ ����? ������ �ִ� ������?"});

        //���� ���
        traderData.Add(new string[] { "�׷�, ������ �� �ʿ��� �� ���� �� �����." });

    }

    public string GetDialog(int dialogIndex, int npcID, int btnID)
    {
        switch (npcID)
        {
            //���� NPC�� ���������� ���
            case BLACK_SMITH:
                if(dialogIndex == blackSmithData[btnID].Length)
                    return null;
                else
                    return blackSmithData[btnID][dialogIndex];

            case TRADER:
                if (dialogIndex == traderData[btnID].Length)
                    return null;
                else
                    return traderData[btnID][dialogIndex];

            default:
                return "ERROR";
        }
        
    }

    //���߿� ��ư �ؽ�Ʈ���� GET�� �� �ְ�
    public string GetDialogName(int npcID)
    {
        switch(npcID)
        {
            case BLACK_SMITH:
                return "�������� ���";

            case TRADER:
                return "���� ���";

            default:
                return "ERROR";
        }
    }

    public string[] GetBtnText(int npcID)
    {
        switch (npcID)
        {
            case BLACK_SMITH:
                return new string[] { "���ȭ", "��������", "����", "������" };

            case TRADER:
                return new string[] { "����", "����", "����", "������" };

            default:
                return null;
        }
    }

    public Sprite GetNpcImage(int npcID)
    {
        switch (npcID)
        {
            case BLACK_SMITH:
                return blackSmith;

            case TRADER:
                return trader;

            default:
                return null;
        }
    }
}


