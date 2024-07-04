using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : Manager<UIManager>
{
    [SerializeField] private TextMeshProUGUI magazineNumText;

    [Header("Level")]
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI level;

    [Header("Portal Panel")]
    [SerializeField] private GameObject minePortalPanel;
    
    [Header("ItemLog")]
    [SerializeField] private Transform logPoolTr;
    [SerializeField] private Transform logParent;
    [SerializeField] private Sprite rockImg;
    private Queue<GameObject> logPool;
    private int logPoolSize = 7;

    [Header("Dialog")]
    [SerializeField] private TypeEffect dialogText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private Button[] dialogBtn;
    [SerializeField] private Image npcImg;
    private bool dialogAction = true;
    private int npcID;
    private int dialigIndex = 0;
    private int btnID = 0;

    [Header("Enforce")]
    [SerializeField] private GameObject enfroceUI;

    [Header("Calculate")]
    [SerializeField] private GameObject calculateUI;

    [Header("Store")]
    [SerializeField] private GameObject storeUI;


    //NPC 식별 상수
    private const int BLACK_SMITH = 0;
    private const int TRADER = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InventoryManager.Instance.IsInventory)
            {
                InventoryManager.Instance.OpenInventory();
            }
            else
            {
                InventoryManager.Instance.CloseInventory();
            }
        }

        if ((Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.Space)) && dialogPanel.activeSelf)
        {
            Dialog(btnID);
        }

    }

    public void Init()
    {
        //PlayerController.Instance.OnMagazineCountChanged += UpdateMagazineCountUI;
        CreateLogPool();
    }
    
    private void UpdateMagazineCountUI(int magazineCount)
    {
        magazineNumText.text = "Magazine Count: " + magazineCount;
    }

    #region MineSelectPanel

    public void OpenMineSelectPanel()
    {
        // 광산 선택 패널 오픈
        minePortalPanel.gameObject.SetActive(true);
        
        // 플레이어 조작 멈춤
        
    }

    public void CloseMineSelectPanel()
    {
        minePortalPanel.gameObject.SetActive(false);
    }

    #endregion

    #region LevelUI

    public void UpdateLevelText(int level, int currentExp, int requiredExp)
    {
        expText.text = currentExp + " / " + requiredExp;
        this.level.text = level.ToString();
    }

    public void UpdateExpBar(int currentExp, int requiredExp)
    {
        expSlider.maxValue = requiredExp;
        expSlider.value = currentExp;
    }

    #endregion

    #region ItemLogUI

    private void CreateLogPool()
    {
        logPool = new Queue<GameObject>();

        for (int i = 0; i < logPoolSize; i++)
        {
            GameObject log = logPoolTr.GetChild(i).gameObject;
            log.SetActive(false);
            logPool.Enqueue(log);
        }
    }

    public void ShowItemLog(int itemNum, int quantity)
    {
        if (logPool.Count > 0)
        {
            GameObject log = logPool.Dequeue();
            log.transform.SetParent(logParent);
            log.transform.GetChild(0).GetComponent<Image>().sprite = rockImg;
            log.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "돌 ( +" + quantity + " )";
            log.gameObject.SetActive(true);
        }
    }

    public void DequeueLog(GameObject log)
    {
        logPool.Enqueue(log);
        log.transform.SetParent(logPoolTr);
    }

    #endregion


    ////다이얼로그
    public void OpenDialogPanel()
    {
        //한 번 열리고 닫혔을 경우 대비, 다이얼로그 창이 활성화되지 않았을 때 F키를 누르면 초기화
        if (!dialogPanel.activeSelf)
        {
            btnID = 0;
            dialigIndex = 0;

            dialogBtn[2].gameObject.SetActive(true);
        }

        //창 활성화
        dialogPanel.SetActive(true);
    }

    //다이얼로그 출력
    public void DialogAction(int id)
    {
        this.npcID = id;

        Dialog(btnID);
    }

    //다이얼로그 출력
    private void Dialog(int btn = 0)
    {
        string dialogData = dialogUI.GetDialog(dialigIndex ,npcID, btn);
        string nameData = dialogUI.GetDialogName(npcID);
        string[] btnData = dialogUI.GetBtnText(npcID);
        Sprite spriteData = dialogUI.GetNpcImage(npcID);

        if (dialogData == null)
        {
            if((Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.Space)) && btnID == 2)
            {
                dialogPanel.SetActive(false);
            }
            return;
        }

        //데이터 세팅
        dialogText.SetText(dialogData);
        nameText.text = nameData;
        dialogBtn[0].GetComponentInChildren<TextMeshProUGUI>().text = btnData[0];
        dialogBtn[1].GetComponentInChildren<TextMeshProUGUI>().text = btnData[1];
        npcImg.sprite = spriteData;

        dialigIndex++;
    }

    //장비 강화
    public void EnforceBtnEvent()
    {
        dialogPanel.SetActive(false);

        if (npcID==BLACK_SMITH)
            enfroceUI.SetActive(true);
        else 
            calculateUI.SetActive(true);

        btnID = 0;
        dialigIndex = 0;

        //도움말 다시 복구
        dialogBtn[2].gameObject.SetActive(true);

        Dialog();
    }

    public void StoreEvent()
    {
        dialogPanel.SetActive(false);

        if (npcID == BLACK_SMITH)
            enfroceUI.SetActive(true);
        else
            storeUI.SetActive(true);

        btnID = 0;
        dialigIndex = 0;

        //도움말 다시 복구
        dialogBtn[2].gameObject.SetActive(true);

        Dialog();
    }

    //설명
    public void InformationBtnEvent()
    {
        dialigIndex = 0;
        btnID = 1;
        Dialog(btnID);
        dialogBtn[2].gameObject.SetActive(false);
    }
    public void CloseDialogBtnEvent()
    {
        dialigIndex = 0;
        btnID = 2;
        Dialog(btnID);
        
    }

    public void CloseEnforce()
    {
        enfroceUI.SetActive(false);
        calculateUI.SetActive(false);
        storeUI.SetActive(false);

        dialogPanel.SetActive(true);
    }
}
