using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public int levelIndex;
    public bool isAvailable { get; private set; }
    public int levelScore { get; private set; }

    [SerializeField] int bombAmount = 0;
    [SerializeField] int diamondAmount = 0;
    [SerializeField] int grenadeAmount = 0;

    void Start()
    {
        levelScore = LevelSetupScript.Instance.levelScore[levelIndex-1];
        isAvailable = LevelSetupScript.Instance.levelAvilable[levelIndex-1];
        TryGetComponent(out IButtonHandler button);
        button.ButtonChange(isAvailable, levelScore, levelIndex);
    }


    public void PlayLevel()
    {
        if (!isAvailable) return;
        LevelSetupScript.Instance.slotAmount[0] = bombAmount;
        LevelSetupScript.Instance.slotAmount[1] = diamondAmount;
        LevelSetupScript.Instance.slotAmount[2] = grenadeAmount;
        LevelSetupScript.Instance.currentLevelIndex = levelIndex;
        SceneManager.LoadScene(2);
    }
}
