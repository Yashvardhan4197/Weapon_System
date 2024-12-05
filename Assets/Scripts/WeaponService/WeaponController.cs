
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponController
{
    private WeaponView weaponView;
    private WeaponDataSO weaponData;
    private Transform weaponHolderTransform;
    private bool isReloading;
    private int currentCapacity;
    private int reloadCapacity;
    private float nextTimeToFire;
    public int CurrenCapacity { get {  return currentCapacity; } }
    public int ReloadCapacity {  get { return reloadCapacity; } }

    public Transform WeaponHolderTransform { get { return weaponHolderTransform; } }

    public WeaponController(Transform weaponHolderTransform)
    {
        this.weaponHolderTransform = weaponHolderTransform;
    }

    public void SetView(WeaponView weaponView,WeaponDataSO weaponDataSO)
    {
        this.weaponView = weaponView;
        this.weaponData = weaponDataSO;
        weaponView.SetController(this);
        isReloading = false;
        currentCapacity = weaponData.currentCapacity;
        reloadCapacity=weaponData.reloadCapacity;
        nextTimeToFire = 0f;
    }

    public void Shoot()
    {
        if (isReloading == false&&currentCapacity>0 && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1 / weaponData.fireRate);
            RaycastHit Hit;
            if (Physics.Raycast(weaponView.GetMuzzleTransform().position, weaponView.GetMuzzleTransform().forward, out Hit, weaponData.range))
            {
                Debug.Log(Hit.transform.name);
                Debug.DrawRay(weaponView.GetMuzzleTransform().position, weaponView.GetMuzzleTransform().forward, Color.cyan, 2f);
            }
            currentCapacity--;
            Debug.Log("CurrentCapacity: " + currentCapacity);
        }
    }

    public void ReloadWeapon()
    {
        if(currentCapacity<weaponData.totalCapacity && reloadCapacity>0)
        {
            isReloading=true;
            startReloading();
        }
    }

    private async void startReloading()
    {
        await Task.Delay(weaponData.reloadTime*1000);
        reloadCapacity--;
        isReloading = false;
        currentCapacity=weaponData.totalCapacity;
        Debug.Log("ReloadCapacity Left: " + reloadCapacity);
    }

}