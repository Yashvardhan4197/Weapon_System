using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUIView : MonoBehaviour
{

    private WeaponUIController weaponUIController;
    [SerializeField] TextMeshProUGUI weaponNameUI;
    [SerializeField] TextMeshProUGUI weaponMagInfoUI;
    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject crossHairLines;
    public void SetController(WeaponUIController weaponUIController)
    {
        this.weaponUIController = weaponUIController;
    }

    private void Start()
    {
        weaponNameUI.gameObject.SetActive(false);
        weaponMagInfoUI.gameObject.SetActive(false);
        crossHair.SetActive(false);
    }

    public void OnWeaponSelected()
    {
        weaponMagInfoUI.gameObject.SetActive(true);
        weaponNameUI.gameObject.SetActive(true);
    }

    public TextMeshProUGUI GetWeaponMagInfoUI() => weaponMagInfoUI;

    public TextMeshProUGUI GetWeaponNameUI() => weaponNameUI;

    public void SetCrossHairLines(bool crossHairLinesStatus)
    {
        crossHairLines.SetActive(crossHairLinesStatus);
    }

    public void SetCrossHairStatus(bool crossHairStatus)
    {
        crossHair.SetActive(crossHairStatus);
    }

}
