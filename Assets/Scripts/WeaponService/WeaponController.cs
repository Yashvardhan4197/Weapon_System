

using UnityEngine;

public class WeaponController
{
    private WeaponView weaponView;
    private WeaponDataSO weaponData;
    private Transform weaponHolderTransform;
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
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}