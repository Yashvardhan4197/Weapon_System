
using UnityEngine;


[CreateAssetMenu(fileName ="WeaponData",menuName ="ScriptableObjects/NewWeaponData")]
public class WeaponDataSO:ScriptableObject
{
    public int damage;
    public int range;
    public int reloadCapacity;
    public int reloadTime;
    public int currentCapacity;
    public int totalCapacity;
    public float fireRate;
    public void OnReload()
    {
        currentCapacity = totalCapacity;
        reloadCapacity--;
    }
}

