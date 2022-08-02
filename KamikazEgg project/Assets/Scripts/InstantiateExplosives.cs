using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExplosives : MonoBehaviour
{
    [SerializeField] GameObject[] explosivesInstance;
    int[] amountSlot = new int[2];

    void Start()
    {
        
        for (int i = 0; i < 3; i++)
        {
            amountSlot[i] = LevelSetupScript.Instance.slotAmount[i];
            for (int j = 0; j < amountSlot[i]; j++)
                Instantiate(explosivesInstance[i]);
        }
    }

}
