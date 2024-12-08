using System;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] Transform muzzleTransform;
    [SerializeField] int swaySmoothness;
    [SerializeField] int swaySpeed;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem impactFlash;
    private WeaponController weaponController;


    public void SetController(WeaponController weaponController)
    {
        this.weaponController = weaponController;
    }

    private void Update()
    {
        if (weaponController.gamePauseStatus() == false)
        {
            AddSwayInMotion();
            Shoot();
            ReloadWeapon();
        }
    }

    private void ReloadWeapon()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            weaponController.ReloadWeapon();
        }
    }

    private void AddSwayInMotion()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*swaySpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y")*swaySpeed;

        Quaternion xRotation = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion yRotation=Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion totalRotation=xRotation*yRotation;

        weaponController.WeaponHolderTransform.localRotation = Quaternion.Slerp(weaponController.WeaponHolderTransform.localRotation, totalRotation,swaySmoothness*Time.deltaTime);
    }

    private void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            weaponController?.Shoot();
        }
        if(Input.GetMouseButtonDown(1))
        {
            weaponController?.SetAimWeapon();
        }
    }


    public Transform GetMuzzleTransform() => muzzleTransform;

    public ParticleSystem GetImpactParticleSystem() => impactFlash;
    public ParticleSystem getMuzzleParticleSystem()=>muzzleFlash;

}
