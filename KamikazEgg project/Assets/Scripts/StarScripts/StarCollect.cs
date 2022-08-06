using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour, ICollectable
{
    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    public void Collect()
    {
        transform.position = startPosition;
        gameObject.SetActive(false);
    }

}
