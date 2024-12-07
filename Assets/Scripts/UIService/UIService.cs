

public class UIService
{
    private WeaponUIController weaponUIController;
    public UIService(WeaponUIView weaponUIView) 
    {
        weaponUIController= new WeaponUIController(weaponUIView);
    }
    
    public WeaponUIController GetWeaponUIController()=>weaponUIController;


}
