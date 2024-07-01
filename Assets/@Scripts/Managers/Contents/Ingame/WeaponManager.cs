using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Manager<WeaponManager>
{
    [Header("무기 리스트")]
    [SerializeField] private GameObject[] weapons;

    [Header("플레이어")]
    [SerializeField] private Transform weaponParent;

    [SerializeField] private WeaponSelector weaponSelector;
    
    public void Init()
    {
        
    }

    public void EquipWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "pick":
                weapons[0].gameObject.SetActive(true);
                weapons[1].gameObject.SetActive(false);
                weaponSelector.ChangePosition(0);
                break;
            
            case "gun":
                weapons[0].gameObject.SetActive(false);
                weapons[1].gameObject.SetActive(true);
                weaponSelector.ChangePosition(1);
                break;
        }
    }

    public void OnUpgrade()
    {

    }
}
