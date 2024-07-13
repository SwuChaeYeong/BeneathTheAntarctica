using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Store : MonoBehaviour
{
    [SerializeField] TMP_Text saleCount;
    [SerializeField] TMP_Text myPrice;
    [SerializeField] TMP_Text productPrice;
    [SerializeField] GameObject productList;
    [SerializeField] GameObject salePrice;
    [SerializeField] TMP_Text maxPrice;


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
            index++;
        }

        Debug.Log(maxQuantity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCart()
    {
        productList.SetActive(true);
        salePrice.SetActive(true);
        maxPrice.text = "/" + myPrice.text.ToString();
        saleCount.text = (int.Parse(saleCount.text.ToString())+1).ToString();
        Price();

    }

    public void PlusButton()
    {
        if (int.Parse(saleCount.text.ToString()) == maxQuantity)
            return;
        saleCount.text = (int.Parse(saleCount.text.ToString()) + 1) + "";
        Price();
    }
    public void MinusButton()
    {
        if (int.Parse(saleCount.text.ToString()) == 0)
            return;

        saleCount.text = (int.Parse(saleCount.text.ToString()) - 1) + "";
        Price();
    }
    private void Price()
    {
        productPrice.text = (int.Parse(saleCount.text.ToString()) * 1000).ToString();
    }
    public void Purchase()
    {
        myPrice.text = (int.Parse(myPrice.text.ToString()) - int.Parse(productPrice.text.ToString())).ToString();
        productList.SetActive(false);
        salePrice.SetActive(false);
    }
}
