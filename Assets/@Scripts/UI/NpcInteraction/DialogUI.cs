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
    //대장장이 데이터
    private List<string[]> blackSmithData;
    //상인 데이터
    private List<string[]> traderData;

    //NPC 식별 상수
    private const int BLACK_SMITH = 0;
    private const int TRADER = 1;

    [Header("NPC Image")]
    [SerializeField] private Sprite blackSmith;
    [SerializeField] private Sprite trader;

    public void Awake()
    {
        //리스트 초기화
        blackSmithData = new List<string[]>();
        traderData = new List<string[]>();

        GenerateData();
    }

    private void GenerateData()
    {
        ////대장장이
        //기본 대사
        blackSmithData.Add(new string[] { "어서오게. 내가 도와줄 게 있는가?" });

        //도움말 대사
        blackSmithData.Add(new string[] { "장비는 C~S등급의 장비로 분류되어 있지. 장비의 등급과 강화단계에 따라 소비되는 금액과 재료는 달라지고 높아질 수록 요구되는 금액과 재료 또한 많아진다네.",
                                        "재료는 특정 광물파편을 내게 가져오면 제련해주니 언제든 가져오면 되네.\n다른 마을보다 저렴하고 정교함이 다르다니까?",
                                        "그리고 내 솜씨는 말로 다 표현 못해. 강화를 실패해도 장비가 파괴되지 않는다고.\n오히려 무엇이 잘못되었는지 알아내어 성공할 확률이 올라간다네.",
                                        "이참에 한 번 해보겠나? 이리 줘보게."});

        //종료 대사
        blackSmithData.Add(new string[] { "그래, 다음에 또 필요한 일 있을 때 오라고." });


        ////상인
        //기본 대사
        traderData.Add(new string[] { "어서와! '닉네임' 도와줄 거 있어?" });

        //도움말 대사
        traderData.Add(new string[] { "먼저 정산이란 네가 광산에서 캐온 광물 파편을 내게 주면 종류에 따라서 돈을 줄 거야.\n등급이 높은 광물 파편일수록 더 많은 돈을 주겠지?.",
                                        "그리고 광산 밑으로 내려가면 산소 게이지가 닳을 거야.\n그럴 때를 대비해서 나한테 산소통을 몇개 사 가면 산소 걱정은 없을 거야!",
                                        "뿐만 아니라 너의 모든 모험에 도움이 될 만한 물건들을 가지고 있으니 언제든 구경하러 와!",
                                        "말 나온 김에 구경해 볼래? 가지고 있는 파편은?"});

        //종료 대사
        traderData.Add(new string[] { "그래, 다음에 또 필요한 일 있을 때 오라고." });

    }

    public string GetDialog(int dialogIndex, int npcID, int btnID)
    {
        switch (npcID)
        {
            //현재 NPC가 대장장이일 경우
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

    //나중에 버튼 텍스트까지 GET할 수 있게
    public string GetDialogName(int npcID)
    {
        switch(npcID)
        {
            case BLACK_SMITH:
                return "대장장이 펭귄";

            case TRADER:
                return "상인 펭귄";

            default:
                return "ERROR";
        }
    }

    public string[] GetBtnText(int npcID)
    {
        switch (npcID)
        {
            case BLACK_SMITH:
                return new string[] { "장비강화", "파편제련", "도움말", "나가기" };

            case TRADER:
                return new string[] { "정산", "상점", "도움말", "나가기" };

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


