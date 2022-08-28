using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSetupScript : MonoBehaviour
{
    public static LevelSetupScript Instance { get; private set; }

    public int[] slotAmount = new int[3];
    public int totalScore;
    public int[] levelScore = new int[24]; 
    public bool[] levelAvilable = new bool[24];
    public int[,] ExplosiveAmount = new int[24,3];
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
