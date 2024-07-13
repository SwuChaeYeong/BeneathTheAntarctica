using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : Manager<GameData>
{
    public Dictionary<string, UpgradeData> UpgradeData;

    ////

    public ScriptableUpgradeData ScriptableUpgradeData;

    public void Init()
    {
        UpgradeData =new Dictionary<string, UpgradeData>();

        foreach (var item in ScriptableUpgradeData.Datas)
        {
            UpgradeData.Add($"{item.ItemName}_{item.Level}", item);
        }
    }
}
