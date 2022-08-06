using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetupScript : MonoBehaviour
{
    public static LevelSetupScript Instance { get; private set; }

    public int[] slotAmount = new int[3];
    public int totalScore;
    public int[] levelScore = new int[27]; 
    public bool[] levelAvilable = new bool[27];
    public int currentLevelIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

    }


}
