using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIPauseWindow : MonoBehaviour
{

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
        pauseWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ReplayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }
    public void LevelsButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
    }

}
