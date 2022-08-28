using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelButtonController : MonoBehaviour, ILevelExplosiveAmountHandler
{
    [SerializeField] int[] bombAmount = new int[24];
    [SerializeField] int[] dynamiteAmount = new int[24];
    [SerializeField] int[] grenadeAmount = new int[24];


    public int SetBombs(int index)
    {
        return bombAmount[index];
    }
    public int SetDynamites(int index)
    {
        return dynamiteAmount[index];
    }
    public int SetGrenades(int index)
    {
        return grenadeAmount[index];
    }
}
