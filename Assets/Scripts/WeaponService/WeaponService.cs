
using System.Collections.Generic;
using UnityEngine;

public class WeaponService
{
    private List<WeaponList> weaponList;
    private WeaponController weaponController;
    private WeaponView currentSpawnedWeapon;
    private Transform weaponHolder;
    private int currentWeaponSelected;
    private Dictionary<int, WeaponView> spawnedWeapons=new Dictionary<int, WeaponView>();
    public WeaponService(List<WeaponList> weaponList, Transform weaponHolder)
    {
        weaponController = new WeaponController(weaponHolder);
        this.weaponList = weaponList;
        this.weaponHolder = weaponHolder;
        OnGameStart();
    }

    public void OnGameStart()
    {
        foreach (WeaponList weapon in weaponList)
        {
            weapon.weaponData.ResetData();
        }
        spawnedWeapons.Clear();
        SpawnWeapons();
    }

    private void SpawnWeapons()
    {
        int i = 1;
        currentWeaponSelected = 0;
        foreach(WeaponList weapon in weaponList)
        {
            currentSpawnedWeapon = Object.Instantiate(weapon.weaponView);
            currentSpawnedWeapon.transform.SetParent(weaponHolder);
            currentSpawnedWeapon.transform.localPosition = Vector3.zero;
            currentSpawnedWeapon.transform.localEulerAngles = Vector3.zero;
            spawnedWeapons.Add(i, currentSpawnedWeapon);
            currentSpawnedWeapon.gameObject.SetActive(false);
            i++;
        }
        currentSpawnedWeapon = null;
    }

    public void UseWeapon(int weaponNumber)
    {

        if((weaponNumber<=weaponList.Count&&weaponNumber!=0))
        {
            if (currentWeaponSelected == 0 || currentWeaponSelected != weaponNumber)
            {
                currentSpawnedWeapon?.gameObject.SetActive(false);
                weaponController.SetView(spawnedWeapons[weaponNumber], weaponList[weaponNumber - 1].weaponData);
                spawnedWeapons[weaponNumber].gameObject.SetActive(true);
                currentSpawnedWeapon = spawnedWeapons[weaponNumber];
                currentWeaponSelected = weaponNumber;
            }
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