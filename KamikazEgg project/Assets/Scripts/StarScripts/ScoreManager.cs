using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> FinishSetup;
    List<GameObject> starCollected = new List<GameObject>();
    int currentScore = 0;

    private void OnEnable()
    {
        EggCollision.StarCollect += OnStarCollect;
        ButtonControllerScript.Ignite += StarReset;
        FinishAreaTrigger.FinishComplete += Finish;
    }
    private void OnDisable()
    {
        EggCollision.StarCollect -= OnStarCollect;
        ButtonControllerScript.Ignite -= StarReset;
        FinishAreaTrigger.FinishComplete -= Finish;
    }

    private void Start()
    {
        currentScore = 0;
    }


    void OnStarCollect(GameObject star)
    {
        currentScore++;
        starCollected.Add(star);
    }

    void StarReset(bool isIgnite)
    {
        currentScore = 0;
        if (isIgnite) return;
        foreach (var item in starCollected) item.gameObject.SetActive(true);
        starCollected.Clear();

    }

    void Finish()
    {
        int levelIndex = LevelSetupScript.Instance.currentLevelIndex - 1;
        int levelScore = LevelSetupScript.Instance.levelScore[levelIndex];
        bool nextLevelAvailable = LevelSetupScript.Instance.levelAvilable[levelIndex + 1];

        if (!nextLevelAvailable) LevelSetupScript.Instance.levelAvilable[levelIndex + 1] = true;

        if (currentScore > levelScore)
        { 
            LevelSetupScript.Instance.totalScore += currentScore - levelScore;
            LevelSetupScript.Instance.levelScore[levelIndex] = currentScore;
        }
        FinishSetup?.Invoke(currentScore);
    }
}
