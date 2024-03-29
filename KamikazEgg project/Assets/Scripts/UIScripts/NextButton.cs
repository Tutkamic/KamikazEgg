using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextButton : MonoBehaviour
{
    public static event Action ClickSound;
    public void NextButtonClick()
    {
        ClickSound?.Invoke();
        int nextLevelIndex = LevelSetupScript.Instance.currentLevelIndex;
        int bombs = LevelSetupScript.Instance.ExplosiveAmount[nextLevelIndex, 0];
        int dynamites = LevelSetupScript.Instance.ExplosiveAmount[nextLevelIndex, 1];
        int grenades = LevelSetupScript.Instance.ExplosiveAmount[nextLevelIndex, 2];
        LevelSetupScript.Instance.slotAmount[0] = bombs;
        LevelSetupScript.Instance.slotAmount[1] = dynamites;
        LevelSetupScript.Instance.slotAmount[2] = grenades;
        LevelSetupScript.Instance.currentLevelIndex++;
        SceneManager.LoadScene(2);
    }
}
