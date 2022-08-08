using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIPauseWindow : MonoBehaviour
{
    public static event Action ClickSound;
    [SerializeField] GameObject pauseWindow;

    private void OnEnable()
    {
        ButtonControllerScript.Pause += GamePaused;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Pause -= GamePaused;
    }

    private void Start()
    {
        pauseWindow.SetActive(false);
    }
    void GamePaused()
    {
        pauseWindow.SetActive(true);
    }
    public void ResumeButton()
    {
        ClickSound?.Invoke();
        pauseWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ReplayButton()
    {
        ClickSound?.Invoke();
        int levelIndex = LevelSetupScript.Instance.currentLevelIndex - 1;
        LevelSetupScript.Instance.slotAmount[0] = LevelSetupScript.Instance.ExplosiveAmount[levelIndex, 0];
        LevelSetupScript.Instance.slotAmount[1] = LevelSetupScript.Instance.ExplosiveAmount[levelIndex, 1];
        LevelSetupScript.Instance.slotAmount[2] = LevelSetupScript.Instance.ExplosiveAmount[levelIndex, 2];
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }
    public void LevelsButton()
    {
        ClickSound?.Invoke();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        ClickSound?.Invoke();
        Time.timeScale = 1.0f;
        Application.Quit();
    }

}
