

public class UIService
{
    private WeaponUIController weaponUIController;
    private InGameUiController inGameUiController;
    public UIService(WeaponUIView weaponUIView,InGameUIView inGameUIView) 
    {
        weaponUIController= new WeaponUIController(weaponUIView);
        inGameUiController = new InGameUiController(inGameUIView);
    }
    
    public WeaponUIController GetWeaponUIController()=>weaponUIController;

    public InGameUiController GetInGameUiController() => inGameUiController;

}
