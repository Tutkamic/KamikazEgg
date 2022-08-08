using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    void Start()
    {
        Save();
    }

    void Save() => SaveSystem.SaveLevels();


}
