using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : Manager<CharacterManager>
{
    [SerializeField] private Button startBtn;

    [SerializeField] private Transform slotsParent;

    [SerializeField] private Transform slotEdge;
    [SerializeField] private Transform[] slots;
    
    [SerializeField] private Button newCharacterBtn; // 직업 선택하러가기 버튼
    [SerializeField] private Image[] characterImgs;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Transform slotoPrefab;

    private int crtCharacterNum;
    
    [Header("CreateCharacter")]
    [SerializeField] private GameObject createCharacterPanel; // 직업 고르는 창
    [SerializeField] private Button createBtn; // 직업 선택 후, 생성하기 버튼
    [SerializeField] private Transform selectedSign;
    [SerializeField] private Transform[] characters;
    private int createCharacterNumber;

    public void Init()
    {
        int count = 0;
        
        /*for (int i = 0; i < 3; i++)
        {
            bool isCreatedChar = DataManager.Instance.playerDataVo[i].isCreated;
            
            if (isCreatedChar)
            {
                count++;
            }
            else
            {
                
            }
        }*/

        if (count == 3)
        {
            newCharacterBtn.interactable = false;
        }
        startBtn.interactable = false;
    }

    public void OpenCreateCharacterPanel()
    {
        createCharacterPanel.gameObject.SetActive(true);
        createBtn.interactable = false;
    }

    public void CloseCreateCharacterPanel()
    {
        createCharacterPanel.gameObject.SetActive(false);
    }

    #region CreateCharacter

    public void SelectCharacter(int selectedNum)
    {
        switch (selectedNum)
        {
            case 0:
                selectedSign.SetParent(characters[0]);
                selectedSign.transform.position = characters[0].transform.position;
                createBtn.interactable = true;
                createCharacterNumber = 0;
                break;
            
            case 1:
                selectedSign.SetParent(characters[1]);
                selectedSign.transform.position = characters[1].transform.position;
                createBtn.interactable = true;
                createCharacterNumber = 1;
                break;
            
            case 2:
                selectedSign.SetParent(characters[2]);
                selectedSign.transform.position = characters[2].transform.position;
                createBtn.interactable = true;
                createCharacterNumber = 2;
                break;
        }
    }

    public void CreateCharacter()
    {
        switch (createCharacterNumber)
        {
            case 0:
                if (crtCharacterNum == 1)
                {
                    
                }
                break;
        }
    }

    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene("Game");   
    }
}
