using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private string doorDirection;

    private float moveX = 20.0f;
    private float moveY = 12.0f;
    private float horizontalSpace = 4.0f;
    private float verticalSpace = 5.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerFoot"))
        {
            Debug.Log(other.gameObject.name);

            switch (doorDirection)
            {
                case "Right":
                    DoorManager.Instance.MoveMap(CameraController.Instance.center.x + moveX, CameraController.Instance.center.y, transform, new Vector3(horizontalSpace, 0, 0));
                    TrapManager.Instance.SwitchMapMinTransform(TrapManager.Instance.mapSize.x + moveX, TrapManager.Instance.mapSize.y);
                    break;

                case "Left":
                    DoorManager.Instance.MoveMap(CameraController.Instance.center.x - moveX, CameraController.Instance.center.y, transform, new Vector3(-horizontalSpace, 0, 0));
                    TrapManager.Instance.SwitchMapMinTransform(TrapManager.Instance.mapSize.x - moveX, TrapManager.Instance.mapSize.y);
                    break;

                case "Up":
                    DoorManager.Instance.MoveMap(CameraController.Instance.center.x, CameraController.Instance.center.y + moveY, transform, new Vector3(0, verticalSpace, 0));
                    TrapManager.Instance.SwitchMapMinTransform(TrapManager.Instance.mapSize.x, TrapManager.Instance.mapSize.y + moveY);
                    break;

                case "Down":
                    DoorManager.Instance.MoveMap(CameraController.Instance.center.x, CameraController.Instance.center.y - moveY, transform, new Vector3(0, -verticalSpace, 0));
                    TrapManager.Instance.SwitchMapMinTransform(TrapManager.Instance.mapSize.x, TrapManager.Instance.mapSize.y - moveY);
                    break;
            }
        }
        
    }
}
