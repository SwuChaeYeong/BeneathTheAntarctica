using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : Manager<DoorManager>
{
    [SerializeField] private GameObject doorPosition;
    public bool isMove = false;
    public void MoveMap(float cameraX, float cameraY, Transform characterMove, Vector3 space)
    {
        CameraController.Instance.SetCameraLimit(cameraX, cameraY);
        doorPosition.transform.position = characterMove.position + space;

        PlayerController.Instance.Teleport(doorPosition.transform);
        FloorManager.Instance.DoorPlus();
        isMove = true;
    }
}
