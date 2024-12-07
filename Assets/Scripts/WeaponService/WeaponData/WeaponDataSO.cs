
using UnityEngine;


[CreateAssetMenu(fileName ="WeaponData",menuName ="ScriptableObjects/NewWeaponData")]
public class WeaponDataSO:ScriptableObject
{
    [SerializeField] string weaponName;
    [SerializeField] int damage;
    [SerializeField] int range;
    [SerializeField] int reloadTime;
    private int currentMagCapacity;
    private int currentTotalBullets;
    [SerializeField] int totalBullets;
    [SerializeField] int totalMagCapacity;
    [SerializeField] float fireRate;
    [SerializeField] TrailRenderer bulletTracer;
    [SerializeField] Transform aimPosition;


    //Fields
    public string WeaponName { get { return  weaponName; } }
    public int Damage {  get { return damage; } }
    public int Range { get { return range; } }
    public int ReloadTime { get {  return reloadTime; } }
    public int CurrentMagCapacity { get {  return currentMagCapacity; } }
    public int CurrentTotalBullets {  get { return currentTotalBullets; } }
    public int TotalBullets { get {  return totalBullets; } }
    public int TotalMagCapacity { get { return totalMagCapacity; } }
    public float FireRate { get {  return fireRate; } }
    public Transform AimPosition { get {  return aimPosition; } }
    public TrailRenderer BulletTracer { get { return bulletTracer; } }


    public void ResetData()
    {
        currentMagCapacity = totalMagCapacity;
        currentTotalBullets= totalBullets;
    }

    public void SetCurrentMagCapacity(int capacity)
    {
        currentMagCapacity= capacity;
    }

    public void SetCurrentTotalBullets(int bullets)
    {
        currentTotalBullets = bullets;
    }
}

