using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class CameraController : Manager<CameraController>
{
    private Vector3 distance;
    public GameObject player;
    public Vector2 mapSize;
    
    // 카메라 쉐이킹
    [Header("카메라 쉐이킹")]
    private bool isShaking;
    private float shakeTime;
    private float shakeIntensity;

    // 초기 카메라 위치
    private Vector3 originalPosition;
    [SerializeField] public Vector2 center;
    [SerializeField] float height;
    [SerializeField] float width;

    private bool isMapChange;
    private void Awake()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    private void Start()
    {
        isShaking = false;
        distance = transform.position - player.transform.position;
        //height = Camera.main.orthographicSize;
        //width = height * Screen.width / Screen.height;
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        //distance = transform.position - player.transform.position;
    }

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        isShaking = true;
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;
        
        StopCoroutine("ShakeByRotation");
        StartCoroutine("ShakeByRotation");
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;
        float power = 2f;

        while (shakeTime > 0.0f)
        {
            float z = Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(0, 0, z) * shakeIntensity * power);
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = Quaternion.Euler(startRotation);
        isShaking = false;
    }

    public void SetCameraLimit(float centerX, float centerY)
    {
        // 플레이어 캐릭터가 맵을 이동하면, 카메라의 제한 범위를 변경해준다.
        // 카메라 제한범위 변경 코드 삽입
        mapSize.x = 10.0f;
        mapSize.y = 6.0f;
        center.x = centerX;
        center.y = centerY;

        transform.position = player.transform.position + distance;
    }
    
    private void LateUpdate()
    {
        if(!isShaking)
            LimitCameraArea();
    }

    private void LimitCameraArea()
    {
        transform.position = player.transform.position + distance;
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);
        
        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
