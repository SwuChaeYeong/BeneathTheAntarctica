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

    public List<OreParts> orePartsList = new List<OreParts>();
    int maxQuantity;
    // Start is called before the first frame update
    void Start()
    {
        // 각 아이템들이 몇개 있는지 데이터 가져오기.
        int index = 0;

        foreach (var oreParts in orePartsList)
        {
            if (oreParts == null)
                return;

            int quantity = oreParts.quantity;
            Debug.Log(quantity);
            count.text = quantity.ToString();
            index++;
        }

        maxQuantity = int.Parse(count.text.ToString());
        Debug.Log(maxQuantity);
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
        count.text = (int.Parse(count.text.ToString()) - 1).ToString();
        Price();

    }

    public void PlusButton()
    {
        if (int.Parse(count.text.ToString()) == maxQuantity)
            return;
        saleCount.text = (int.Parse(saleCount.text.ToString())+1)+"";
        count.text = (int.Parse(count.text.ToString()) - 1).ToString();
        Price();
    }
    public void MinusButton()
    {
        if (int.Parse(count.text.ToString()) == 0)
            return;

        saleCount.text = (int.Parse(saleCount.text.ToString()) - 1) + "";
        count.text = (int.Parse(count.text.ToString()) + 1).ToString();
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
        productList.SetActive(false);
        salePrice.SetActive(false);
    }
}
