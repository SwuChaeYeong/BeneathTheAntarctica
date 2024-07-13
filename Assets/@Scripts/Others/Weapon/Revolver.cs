using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public event Action<int> OnMagazineCountChanged;

    [SerializeField] private GameObject player;
    
    [Header("Bullet Fire Test")]
    [SerializeField] private GameObject bulletPos;
    private GameObject bulletPrefab;
    
    [Header("Shooting")]
    public float fireRate = 0.1f; // 발사 간격 (한 발당 딜레이)
    public int magazineSize = 20; // 장탄수
    public float reloadTime = 0.3f; // 재장전 시간
    
    private float nextFireTime = 0f; // 다음 발사 시간
    private int currentMagazine; // 현재 장탄 수
    private bool isReloading = false; // 재장전 중인지 여부

    private int basicDamage = 10;

    [Header("Weapon Rotation")]
    public Transform weaponPivot;
    private float rotationSpeed = 50f;

    [Header("BulletPool")]
    public Transform bulletPoolTr;
    private Queue<GameObject> bulletPool;
    private int poolSize = 10;
    
    private Camera m_camera;
    
    void Start()
    {
        m_camera = Camera.main;
        currentMagazine = magazineSize;
    }

    private void OnEnable()
    {
        Debug.Log("Revolver.OnEnable");
        //bulletPrefab = ResourceManager.Instance.Load<GameObject>("Bullet.prefab");
        CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = bulletPoolTr.GetChild(i).gameObject;
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    private void NotifyMagazineCountZero(int magazineCount)
    {
        OnMagazineCountChanged?.Invoke(magazineCount);
    }
    
    void Update()
    {
        RotateWeaponTowardsMouse();
        
        // 장전중이면 발사 중지
        if (isReloading)
            return;
        
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            if (currentMagazine > 0)
            {
                Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f; // 카메라와 거리를 일정하게 유지하기 위해 z축을 0으로 설정

                Shoot(mousePos);
            }
        }
    }

    private void RotateWeaponTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - player.transform.position;
        direction.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponPivot.rotation = Quaternion.Slerp(weaponPivot.rotation, rotation, rotationSpeed * Time.deltaTime);
        
        if (direction.x < -0)
        {
            transform.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
    
    private void Shoot(Vector3 targetPosition)
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetRevolver(this);
            bullet.GetComponent<Bullet>().Init(targetPosition, basicDamage);
            
            currentMagazine--;
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            Debug.Log("BulletPool is empty!");
        }
        
        // 총알 개수 구독자들에게 알림 발송
        NotifyMagazineCountZero(currentMagazine);
        

        if (currentMagazine == 0)
        {
            Invoke("Reload", reloadTime); // 재장전
        }
    }
    
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
    
    private void Reload()
    {
        isReloading = true;
        Debug.Log("장전중입니다!");
        
        Invoke("FinishReload", reloadTime); // 재장전 시간만큼 대기 후 완료
    }
    
    private void FinishReload()
    {
        Debug.Log("장전이 완료되었습니다!");
        currentMagazine = magazineSize; // 재장전 완료
        
        // 총알 개수 구독자들에게 알림 발송
        NotifyMagazineCountZero(currentMagazine);
        
        isReloading = false;
        Debug.Log("isReloading이 false가 되었습니다.");
    }
}
