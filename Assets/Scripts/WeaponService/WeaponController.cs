﻿
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
    private bool isAiming;
    private bool isPaused;
    public Transform WeaponHolderTransform { get { return weaponHolderTransform; } }

    public WeaponController(Transform weaponHolderTransform)
    {
        this.weaponHolderTransform = weaponHolderTransform;
        isPaused = false;
        GameService.Instance.PAUSEGAME += OnGamePaused;
        GameService.Instance.UNPAUSEGAME += OnGameUnPaused;
    }

    public void SetView(WeaponView weaponView,WeaponDataSO weaponDataSO)
    {
        if(this.weaponView==null)
        {
            GameService.Instance.UIService.GetWeaponUIController().OpenWeaponUI();
            GameService.Instance.UIService.GetWeaponUIController().SetCrossHair(true);
        }
        if (this.weaponView != null)
        {
            isAiming = true;
            SetAimWeapon();
        }
        this.weaponView = weaponView;
        this.weaponData = weaponDataSO;
        weaponView.SetController(this);
        isReloading = false;
        nextTimeToFire = 0f;
        impactParticleSystem = weaponView.GetImpactParticleSystem();
        muzzleParticleSystem = weaponView.getMuzzleParticleSystem();
        GameService.Instance.UIService.GetWeaponUIController().SetWeaponInfo(weaponData.WeaponName);
        GameService.Instance.UIService.GetWeaponUIController().SetMagInfo(weaponData.CurrentMagCapacity, weaponData.CurrentTotalBullets);
        GameService.Instance.SoundService.PlaySFXSound(SoundType.WEAPON_CHANGE);
    }

    public void Shoot()
    {
        if (isReloading == false&& weaponData.CurrentMagCapacity>0 && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1 / weaponData.FireRate);
            Ray ray=new Ray();
            RaycastHit Hit;
            ray.origin = weaponView.GetMuzzleTransform().position;
            ray.direction = GameService.Instance.PlayerService.GetPlayerController().GetCrossHairObjectPositon().position - weaponView.GetMuzzleTransform().position;
            if (Physics.Raycast(ray, out Hit, weaponData.Range))
            {
                impactParticleSystem.transform.position = Hit.point;
                impactParticleSystem.transform.forward = Hit.normal;
                impactParticleSystem.Emit(1);

                muzzleParticleSystem.transform.position = weaponView.GetMuzzleTransform().position;
                muzzleParticleSystem.transform.forward= weaponView.GetMuzzleTransform().forward;
                muzzleParticleSystem.Emit(1);

                var tracer= Object.Instantiate(weaponData.BulletTracer,ray.origin,Quaternion.identity);
                tracer.AddPosition(ray.origin);
                tracer.transform.position = Hit.point;
                IDamageAble damageAbleObject=Hit.transform.GetComponent<IDamageAble>();
                if(damageAbleObject!=null)
                {
                    damageAbleObject.TakeDamage(weaponData.Damage);
                }
            }
            weaponData.SetCurrentMagCapacity(weaponData.CurrentMagCapacity-1);
            GameService.Instance.UIService.GetWeaponUIController().SetMagInfo(weaponData.CurrentMagCapacity, weaponData.CurrentTotalBullets);
            GameService.Instance.SoundService.PlaySFXSound(weaponData.ShootSound);
        }
    }

    public void ReloadWeapon()
    {
        if(weaponData.CurrentMagCapacity <weaponData.TotalMagCapacity && weaponData.CurrentTotalBullets>0)
        {
            isReloading=true;
            startReloading();
            GameService.Instance.SoundService.PlayBackgroundSound(weaponData.ReloadSound);
        }
    }

    private async void startReloading()
    {
        await Task.Delay(weaponData.ReloadTime*1000);
        int neededBullets = weaponData.TotalMagCapacity - weaponData.CurrentMagCapacity;
        if(weaponData.CurrentTotalBullets>=neededBullets)
        {
            weaponData.SetCurrentTotalBullets(weaponData.CurrentTotalBullets-neededBullets);
            weaponData.SetCurrentMagCapacity(weaponData.CurrentMagCapacity + neededBullets);
        }
        else
        {
            weaponData.SetCurrentMagCapacity(weaponData.CurrentMagCapacity + weaponData.CurrentTotalBullets);
            weaponData.SetCurrentTotalBullets(0);
        }
        isReloading = false;
        GameService.Instance.UIService.GetWeaponUIController().SetMagInfo(weaponData.CurrentMagCapacity, weaponData.CurrentTotalBullets);
        GameService.Instance.SoundService.PlayBackgroundSound(SoundType.NONE);
        GameService.Instance.SoundService.PlaySFXSound(SoundType.RELOAD_COMPLETE);
    }

    public void SetAimWeapon()
    {
        if(isAiming)
        {
            weaponView.transform.localPosition = Vector3.MoveTowards(weaponData.AimPosition.localPosition, new Vector3(0, 0, 0), 100 * Time.deltaTime);
            weaponView.transform.localRotation = Quaternion.Slerp(weaponData.AimPosition.localRotation, Quaternion.identity, 100 * Time.deltaTime);
            isAiming = false;
            GameService.Instance.UIService.GetWeaponUIController().OnWeaponAim(true);
        }
        else
        {
            weaponView.transform.localPosition = Vector3.MoveTowards(new Vector3(0, 0, 0), weaponData.AimPosition.localPosition, 100*Time.deltaTime);
            weaponView.transform.localRotation = Quaternion.Slerp(Quaternion.identity,weaponData.AimPosition.localRotation, 100 * Time.deltaTime);
            isAiming =true;
            GameService.Instance.UIService.GetWeaponUIController().OnWeaponAim(false);
        }
    }

    public bool gamePauseStatus() => isPaused;
    public void OnGamePaused()
    {
        isPaused = true;
    }

    public void OnGameUnPaused()
    {
        isPaused = false;
    }

    public void OnWeaponDataReset()
    {
        GameService.Instance.UIService.GetWeaponUIController().SetMagInfo(weaponData.CurrentMagCapacity, weaponData.CurrentTotalBullets);
    }
}