using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : Manager<PortalManager>
{
    [SerializeField] private GameObject mine1Map;
    [SerializeField] private Transform mine1MapEnterance;

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
                UIManager.Instance.OpenMineSelectPanel();
                break;
            
            case "OutMinePortal":
                UIManager.Instance.OpenMineSelectPanel();
                break;
        }
    }

    public void EnterPortal()
    {
        UIManager.Instance.CloseMineSelectPanel();
        PlayerController.Instance.Teleport(mine1MapEnterance);
        CameraController.Instance.SetCameraLimit(8, 8);
    }
    
    
}
