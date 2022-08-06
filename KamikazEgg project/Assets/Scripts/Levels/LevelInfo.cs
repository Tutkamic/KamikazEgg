using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public int levelIndex;
    public bool isAvailable { get; private set; }
    public int levelScore { get; private set; }

    [SerializeField] int bombAmount = 0;
    [SerializeField] int dynamiteAmount = 0;
    [SerializeField] int grenadeAmount = 0;

    void Start()
    {
        isAvailable = LevelSetupScript.Instance.levelAvilable[levelIndex-1];

        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 0] = bombAmount;
        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 1] = dynamiteAmount;
        LevelSetupScript.Instance.ExplosiveAmount[levelIndex - 1, 2] = grenadeAmount;
    }


    public void PlayLevel()
    {
        if (!isAvailable) return;
        LevelSetupScript.Instance.slotAmount[0] = bombAmount;
        LevelSetupScript.Instance.slotAmount[1] = dynamiteAmount;
        LevelSetupScript.Instance.slotAmount[2] = grenadeAmount;
        LevelSetupScript.Instance.currentLevelIndex = levelIndex;
        SceneManager.LoadScene(2);
    }
}
