using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenuSceneLoad : MonoBehaviour
{
    public static event Action ClickSound;
    public void StartButton()
    {
        ClickSound?.Invoke();
        LevelSetupScript.Instance.levelAvilable[0] = true;
        SceneManager.LoadScene(1);
    }
    public void HowToPlayButton()
    {
        ClickSound?.Invoke();
        LevelSetupScript.Instance.slotAmount[0] = 1;
        LevelSetupScript.Instance.slotAmount[1] = 0;
        LevelSetupScript.Instance.slotAmount[2] = 0;
        SceneManager.LoadScene(3);
    }
}
