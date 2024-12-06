
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponController
{
    private WeaponView weaponView;
    private WeaponDataSO weaponData;
    private Transform weaponHolderTransform;
    private bool isReloading;
    private float nextTimeToFire;
    private ParticleSystem impactParticleSystem;
    private ParticleSystem muzzleParticleSystem;
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
        nextTimeToFire = 0f;
        impactParticleSystem = weaponView.GetImpactParticleSystem();
        muzzleParticleSystem = weaponView.getMuzzleParticleSystem();
    }

    public void Shoot()
    {
        if (isReloading == false&& weaponData.currentCapacity>0 && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1 / weaponData.fireRate);
            Ray ray=new Ray();
            RaycastHit Hit;
            ray.origin = weaponView.GetMuzzleTransform().position;
            ray.direction = GameService.Instance.PlayerService.GetPlayerController().GetCrossHairObjectPositon().position - weaponView.GetMuzzleTransform().position;
            if (Physics.Raycast(ray, out Hit, weaponData.range))
            {
                impactParticleSystem.transform.position = Hit.point;
                impactParticleSystem.transform.forward = Hit.normal;
                impactParticleSystem.Emit(1);

                muzzleParticleSystem.transform.position = weaponView.GetMuzzleTransform().position;
                muzzleParticleSystem.transform.forward= weaponView.GetMuzzleTransform().forward;
                muzzleParticleSystem.Emit(1);

                var tracer= Object.Instantiate(weaponData.bulletTracer,ray.origin,Quaternion.identity);
                tracer.AddPosition(ray.origin);
                tracer.transform.position = Hit.point;
                IDamageAble damageAbleObject=Hit.transform.GetComponent<IDamageAble>();
                if(damageAbleObject!=null)
                {
                    damageAbleObject.TakeDamage(weaponData.damage);
                }
            }
            weaponData.currentCapacity--;
        }
    }

    public void ReloadWeapon()
    {
        if(weaponData.currentCapacity <weaponData.totalCapacity && weaponData.currentReloadCapacity>0)
        {
            isReloading=true;
            startReloading();
        }
    }

    private async void startReloading()
    {
        await Task.Delay(weaponData.reloadTime*1000);
        weaponData.currentReloadCapacity--;
        isReloading = false;
        weaponData.currentCapacity =weaponData.totalCapacity;
    }

}