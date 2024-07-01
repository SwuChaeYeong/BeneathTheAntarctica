using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


/// <summary>
/// InventoryManager는 플레이어가 가지고 있는 아이템들에 대한 모든 것을 담당합니다.
/// </summary>
public class InventoryManager : Manager<InventoryManager>
{
    [SerializeField] private GameObject inventoryUIBlack;
    private Image inventoryUIBlackImage;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject[] inventoryItemList;

    public List<OreParts> orePartsList = new List<OreParts>();

    // 아이템 데이터가 나오기 전까지 임시로 사용
    private int stone;
    public int Stone=>stone;

    private bool isInventory;

    private int gold;
    public int Gold => gold;
    public bool IsInventory { get { return isInventory; } set { isInventory = value; } }


    private void Start()
    {
        inventoryUIBlackImage = inventoryUIBlack.GetComponent<Image>();
        isInventory = true;
        stone = 0;
    }

    public void AddPart(string partname, int quantity)
    {
        // 아이템 획득 로그 띄우기
        UIManager.Instance.ShowItemLog(1, quantity);

        // 아이템 데이터 저장
        OreParts existingPart = orePartsList.Find(part => part.name == partname);
        if (existingPart != null)
        {
            existingPart.quantity += quantity;
        }
        else
            orePartsList.Add(new OreParts(partname, quantity));
    }

    public void OpenInventory()
    {
        // 각 아이템들이 몇개 있는지 데이터 가져오기.
        int index = 0;

        foreach (var oreParts in orePartsList)
        {
            if (oreParts == null)
                return;

            int quantity = oreParts.quantity;
            inventoryItemList[index].GetComponent<TextMeshProUGUI>().text = "x" + quantity;
            index++;
        }

        // 뒷 검은 배경
        inventoryUIBlackImage.gameObject.SetActive(true);
        inventoryUIBlackImage.DOFade(0.7f, 0.25f);

        inventoryUI.transform.localScale = Vector3.zero;
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.transform.DOScale(1, 0.25f);

        IsInventory = false;
    }

    public void CloseInventory()
    {
        inventoryUIBlackImage.DOFade(0, 0.25f);
        inventoryUIBlackImage.gameObject.SetActive(false);

        inventoryUI.gameObject.SetActive(false);
        IsInventory = true;
    }


}
