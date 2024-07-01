using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnforceUI : MonoBehaviour
{
    public TMP_Text PercentText;

    public TMP_Text CostGoldText;
    public TMP_Text GoldText;

    public TMP_Text CostStoneText;
    public TMP_Text StoneText;

    public TMP_Text StrText;
    public TMP_Text StrPlusText;
    public TMP_Text DexText;
    public TMP_Text DexPlusText;
    public TMP_Text LukText;
    public TMP_Text LukPlusText;

    public void Init()
    {
        Refresh();
    }

    public void OnUpgrade()
    {

    }

    public void Refresh()
    {
        PercentText.text = $"99%";
        CostGoldText.text = "1234";
        GoldText.text = InventoryManager.Instance.Gold.ToString();
        CostStoneText.text = "1234";
        StoneText.text = InventoryManager.Instance.Stone.ToString();

        //юс╫ц
        StrText.text = $"111";
        StrPlusText.text = $"11";
        DexText.text = $"222";
        DexPlusText.text = $"22";
        LukText.text = $"333";
        LukPlusText.text = $"33";
    }
}
