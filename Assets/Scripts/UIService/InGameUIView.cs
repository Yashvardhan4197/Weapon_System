using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    [SerializeField] Button resetBullets;
    [SerializeField] Button resumeGameButton;
    [SerializeField] Button exitGameButton;
    private InGameUiController inGameUiController;
    private void Start()
    {
        resumeGameButton.onClick.AddListener(OnResumeButtonClicked);
        exitGameButton.onClick.AddListener(OnExitButtonClicked);
        resetBullets.onClick.AddListener(onResetBulletsButtonClicked);
        this.gameObject.SetActive(false);
    }

    public void SetController(InGameUiController inGameUiController)
    {
        this.inGameUiController = inGameUiController;
    }


    private void OnExitButtonClicked()
    {
        inGameUiController.ExitGame();
    }

    private void OnResumeButtonClicked()
    {
        inGameUiController.UnPauseGame();
    }
    private void onResetBulletsButtonClicked()
    {
        inGameUiController.ResetBulletData();
    }
}
