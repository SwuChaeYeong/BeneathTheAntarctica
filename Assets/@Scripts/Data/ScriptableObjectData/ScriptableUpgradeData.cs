using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableUpgradeData : ScriptableObject
{
    public List<UpgradeData> Datas;
}

[Serializable]
public class UpgradeData
{
    //public string Key;
    public string ItemName;
    public int Level;
    public float Percent;
    public int GoldCost;
    public string[] Matters;
}


