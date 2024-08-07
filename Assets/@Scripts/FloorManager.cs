using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : Manager<FloorManager>
{
    private int oreCount = 0;
    private int doorCount = 0;

    [SerializeField] private Button[] floorBtn;

    public void OrePlus()
    {
        oreCount++;
    }
    public void DoorPlus()
    {
        doorCount++;
    }

    public void Update()
    {
        if (oreCount > 40 && doorCount > 10)
        {
            floorBtn[1].interactable = true;
        }
    }
}
