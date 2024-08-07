using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PortalManager : Manager<PortalManager>
{
    [SerializeField] private GameObject mine1Map;
    [SerializeField] private Transform[] mapEnterance;
    [SerializeField] private GameObject villageButton;
    [SerializeField] private Vector2[] limit;

    public bool isInMine = false;

    private string[] mineList = { "Village", "FirstFloor", "SecondFloor", "ThirdFloor", "ForthFloor", "FifthFloor" };

    public void Init()
    {
        // LoadAllAsync로 불러온 맵 프리팹을 Load하고 mine[]에 순차적으로 넣어놓자.
        //mine1Map = ResourceManager.Instance.Load<GameObject>("Mine1.prefab");
    }
    
    public void TouchPortal(string portalName)
    {
        switch (portalName)
        {
            case "InMinePortal":
                villageButton.SetActive(false);
                UIManager.Instance.OpenMineSelectPanel();
                break;
            
            case "OutMinePortal":
                villageButton.SetActive(true);
                UIManager.Instance.OpenMineSelectPanel();
                break;
        }
    }

    public void EnterPortal()
    {
        UIManager.Instance.CloseMineSelectPanel();
        UIManager.Instance.isPanelOpend = false;

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        int index = 0;

        for (int i = 0; mapEnterance.Length > i; i++)
        {
            if (clickObject.name == mineList[i])
            {
                index = i;
                break;
            }
        }

        if (index == 0)
        {
            isInMine = false;
            TrapManager.Instance.RestartTrap();
        }
        else
        {
            isInMine = true;
            TrapManager.Instance.RestartTrap();
        }
            

        PlayerController.Instance.Teleport(mapEnterance[index]);
        CameraController.Instance.SetCameraLimit(limit[index].x, limit[index].y);
    }
    
    
}
