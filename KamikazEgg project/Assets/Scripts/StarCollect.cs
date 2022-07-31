using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
