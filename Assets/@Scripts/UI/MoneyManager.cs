using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Manager<MoneyManager>
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void PlustMoney(int extra)
    {
        moneyText.text = (int.Parse(moneyText.text.ToString()) + extra).ToString();
    }

    public int GetMoney()
    {
        return int.Parse(moneyText.text.ToString());
    }
}
