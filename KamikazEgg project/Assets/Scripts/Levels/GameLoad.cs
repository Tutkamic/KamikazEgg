using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour
{
    void Start()
    {
        Load();
    }
    void Load()
    {
        LevelData data = SaveSystem.LoadLevels();

        LevelSetupScript.Instance.totalScore = data.totalScore;
        for (int i = 0; i < 27; i++)
        {
            LevelSetupScript.Instance.levelScore[i] = data.levelScore[i];
            LevelSetupScript.Instance.levelAvilable[i] = data.levelAvilable[i];
        }
    }
}
