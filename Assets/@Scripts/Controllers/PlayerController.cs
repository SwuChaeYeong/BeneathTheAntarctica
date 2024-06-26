using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Manager<PlayerController>
{
    [Header("Player")] 
    private Animator playerAnim;  // 플레이어 이동관련 애니메이션

    Vector2 _moveDir = Vector2.zero;
    private float playerSpeed = 4.0f;
    private int screenWidthHalf;

    private bool isMoving;
    
    private Camera m_camera;
    
    public void Init()
    {
        m_camera = Camera.main;
        screenWidthHalf = Screen.width / 2;
        playerAnim = GetComponent<Animator>();
        
        //PlayerController에서 Init이 모두 끝나면 하위개념인
        //WeaponManager Init 실행
        //WeaponManager.Instance.Init();
    }

    public void Teleport(Transform targetPosition)
    {
        transform.position = targetPosition.position + new Vector3(0, -1.5f, 0);
    }

    private void Update()
    {
        // 플레이어 이동 입력
        UpdateInput();
        
        // 마우스 위치 추적 및 캐릭터 방향 설정
        UpdateCursorPosition();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void UpdateInput()
    {
        Vector2 moveDir = Vector2.zero;
        isMoving = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y += 1;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y -= 1;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x -= 1;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x += 1;
            isMoving = true;
        }

        if (!isMoving)
            playerAnim.SetBool("isMove", false);
        else
            playerAnim.SetBool("isMove", true);

        _moveDir = moveDir.normalized;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 곡괭이 무기를 들게 함
            Debug.Log("곡괭이 드세요!");
            WeaponManager.Instance.EquipWeapon("pick");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 총 무기를 들게 함
            Debug.Log("총 드세요!");
            WeaponManager.Instance.EquipWeapon("gun");
        }
    }

    private void UpdateCursorPosition()
    {
        Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        // new Vector3를 지속적으로 많이 부르는것은 메모리 낭비가 심하므로 나중에
        // 미리 선언해서 변수에 담아 놓고 사용하기.
        if (mousePos.x >= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void MovePlayer()
    {
        Vector3 dir= _moveDir * playerSpeed * Time.deltaTime;
        transform.position += dir;
    }
}
