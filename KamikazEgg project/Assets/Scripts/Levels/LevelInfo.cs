using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelInfo : MonoBehaviour
{
    public static event Action SoundClick;

    public int levelIndex;
    public bool isAvailable { get; private set; }
    public int levelScore { get; private set; }

    int bombAmount;
    int dynamiteAmount;
    int grenadeAmount;

    ILevelExplosiveAmountHandler explosiveAmountHandler;

    void Start()
    {
        explosiveAmountHandler = GetComponentInParent<ILevelExplosiveAmountHandler>();
        isAvailable = LevelSetupScript.Instance.levelAvilable[levelIndex-1];
        SetAmount();
    }


    public void PlayLevel()
    {
        SoundClick?.Invoke();
        if (!isAvailable) return;
        LevelSetupScript.Instance.slotAmount[0] = bombAmount;
        LevelSetupScript.Instance.slotAmount[1] = dynamiteAmount;
        LevelSetupScript.Instance.slotAmount[2] = grenadeAmount;
        LevelSetupScript.Instance.currentLevelIndex = levelIndex;
        SceneManager.LoadScene(2);
    }

    private void SetAmount()
    {
        bombAmount = explosiveAmountHandler.SetBombs(levelIndex - 1);
        dynamiteAmount = explosiveAmountHandler.SetDynamites(levelIndex - 1);
        grenadeAmount = explosiveAmountHandler.SetGrenades(levelIndex - 1);

        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 0] = bombAmount;
        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 1] = dynamiteAmount;
        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 2] = grenadeAmount;
    }
}
