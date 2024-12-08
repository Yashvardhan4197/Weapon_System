using System;
using UnityEngine;

public class InGameUiController
{
    private InGameUIView inGameUIView;

    public InGameUiController(InGameUIView inGameUIView)
    {
        this.inGameUIView = inGameUIView;
        inGameUIView.SetController(this);
        GameService.Instance.PAUSEGAME += OnGamePaused;
        GameService.Instance.UNPAUSEGAME += OnGameUnPaused;
    }

    public void UnPauseGame()
    {
        GameService.Instance.UNPAUSEGAME?.Invoke();
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnGamePaused()
    {
        inGameUIView.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnGameUnPaused()
    {
        inGameUIView.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResetBulletData()
    {
        GameService.Instance.RESETWEAPONDATA?.Invoke();
        GameService.Instance.WeaponService.GetWeaponController().OnWeaponDataReset();
    }
}