
using System.Collections.Generic;
using UnityEngine;

public class WeaponService
{
    private List<WeaponList> weaponList;
    private WeaponController weaponController;
    private WeaponView currentSpawnedWeapon;
    private Transform weaponHolder;
    public WeaponService(List<WeaponList> weaponList, Transform weaponHolder)
    {
        weaponController = new WeaponController(weaponHolder);
        this.weaponList = weaponList;
        this.weaponHolder = weaponHolder;
    }

    public void SpawnWeapon(int weaponNumber)
    {
        if(weaponNumber<=weaponList.Count&&weaponNumber!=0)
        {
            Object.Destroy(currentSpawnedWeapon?.gameObject);
            currentSpawnedWeapon = Object.Instantiate(weaponList[weaponNumber-1].weaponView);
            currentSpawnedWeapon.transform.SetParent(weaponHolder);
            currentSpawnedWeapon.transform.localPosition = Vector3.zero;
            currentSpawnedWeapon.transform.localEulerAngles = Vector3.zero;
            weaponController.SetView(currentSpawnedWeapon, weaponList[weaponNumber-1].weaponData);
        }
        
    }

    public WeaponController GetWeaponController() => weaponController;
}

[System.Serializable]
public class WeaponList
{
    public WeaponView weaponView;
    public WeaponDataSO weaponData;
}