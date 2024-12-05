
using UnityEngine;


[CreateAssetMenu(fileName ="WeaponData",menuName ="ScriptableObjects/NewWeaponData")]
public class WeaponDataSO:ScriptableObject
{
    public int damage;
    public int range;
    public int totalCapacity;
    public int reloadTime;
}

