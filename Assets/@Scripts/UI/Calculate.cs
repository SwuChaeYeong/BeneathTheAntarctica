using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Calculate : MonoBehaviour
{
    [SerializeField] TMP_Text saleCount;
    [SerializeField] TMP_Text count;
    [SerializeField] TMP_Text myPrice;
    [SerializeField] TMP_Text productPrice;
    [SerializeField] GameObject productList;
    [SerializeField] GameObject salePrice;
    [SerializeField] private GameObject[] calItemList;

    public List<OreParts> orePartsList = new List<OreParts>();
    int maxQuantity;
    // Start is called before the first frame update
    public void StartSetting()
    {
        InventoryManager.Instance.ItemCount(calItemList);
        maxQuantity = int.Parse(count.text.ToString().Substring(1, (count.text.ToString().Length - 1)));
        myPrice.text = MoneyManager.Instance.GetMoney().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickItem()
    {
        productList.SetActive(true);
        salePrice.SetActive(true);
        saleCount.text = "1";
        count.text = (maxQuantity - 1).ToString();
        Price();

    }

    public void PlusButton()
    {
        if (int.Parse(count.text.ToString()) == maxQuantity)
            return;
        saleCount.text = (int.Parse(saleCount.text.ToString())+1)+"";
        count.text = "x" + (int.Parse(count.text.ToString()) - 1).ToString();
        Price();
    }
    public void MinusButton()
    {
        if (int.Parse(count.text.ToString()) == 0)
            return;

        saleCount.text = (int.Parse(saleCount.text.ToString()) - 1) + "";
        count.text = "x" + (int.Parse(count.text.ToString()) + 1).ToString();
        Price();
    }
    public void MaxButton()
    {
        saleCount.text = maxQuantity.ToString();
        count.text = "0";
        Price();
    }
    public void MinButton()
    {
        saleCount.text = "0";
        count.text = maxQuantity.ToString();
        Price();
    }
    private void Price()
    {
        productPrice.text = (int.Parse(saleCount.text.ToString()) * 110).ToString();
    }
    public void Sale()
    {
        myPrice.text = (int.Parse(myPrice.text.ToString()) + int.Parse(productPrice.text.ToString())).ToString();
        MoneyManager.Instance.PlustMoney(int.Parse(saleCount.text.ToString()) * 110);
        myPrice.text = MoneyManager.Instance.GetMoney().ToString();
        productList.SetActive(false);
        salePrice.SetActive(false);
    }
}
