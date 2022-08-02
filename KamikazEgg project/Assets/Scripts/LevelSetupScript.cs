using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetupScript : MonoBehaviour
{
    public static LevelSetupScript Instance { get; private set; }

    public int[] slotAmount = new int[3];

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
