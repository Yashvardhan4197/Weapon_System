public class WeaponUIController
{
    private WeaponUIView weaponUIView;

    public WeaponUIController(WeaponUIView weaponUIView)
    {
        this.weaponUIView = weaponUIView;
        weaponUIView.SetController(this);
    }

    public void SetMagInfo(int currentMagCapacity,int currentTotalBullets)
    {
        weaponUIView.GetWeaponMagInfoUI().text=currentMagCapacity.ToString()+"/"+currentTotalBullets.ToString();
    }

    public void SetWeaponInfo(string name)
    {
        weaponUIView.GetWeaponNameUI().text=name;
    }
    public void OpenWeaponUI()
    {
        weaponUIView.OnWeaponSelected();
    }

    public void OnWeaponAim(bool weaponAim)
    {
        weaponUIView.SetCrossHairLines(weaponAim);
    }
    public void SetCrossHair(bool crossHair)
    {
        weaponUIView.SetCrossHairStatus(crossHair);
    }
}