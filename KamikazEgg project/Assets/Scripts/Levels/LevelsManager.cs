using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Levels = new List<GameObject>();
    int currentLevelIndex;

    private void Start()
    {
        currentLevelIndex = LevelSetupScript.Instance.currentLevelIndex - 1;
        Instantiate(Levels[currentLevelIndex]);
    }
}
