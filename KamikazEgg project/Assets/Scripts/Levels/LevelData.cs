using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int totalScore;
    public int[] levelScore = new int[27];
    public bool[] levelAvilable = new bool[27];
    public LevelData()
    {
        totalScore = LevelSetupScript.Instance.totalScore;
        for (int i = 0; i < levelScore.Length; i++)
        {
            levelScore[i] = LevelSetupScript.Instance.levelScore[i];
            levelAvilable[i] = LevelSetupScript.Instance.levelAvilable[i];
        }
    }
}
