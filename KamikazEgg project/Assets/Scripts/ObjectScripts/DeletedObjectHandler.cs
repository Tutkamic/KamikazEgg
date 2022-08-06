using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DeletedObjectHandler : MonoBehaviour
{
    List<GameObject> destroyedObj = new List<GameObject>();

    private void OnEnable()
    {
        ObjectExplosionScript.Explode += DeleteExplodedObject;
        ButtonControllerScript.Ignite += ResetDeletedObjects;
    }
    private void OnDisable()
    {
        ObjectExplosionScript.Explode -= DeleteExplodedObject;
        ButtonControllerScript.Ignite -= ResetDeletedObjects;
    }

    private void DeleteExplodedObject(GameObject bomb)
    {
        destroyedObj.Add(bomb);
    }

    private void ResetDeletedObjects(bool isIgnite)
    {
        if (isIgnite)
            return;
        else
        {
            foreach (GameObject go in destroyedObj)
            {
                go.SetActive(true);
                go.GetComponent<Rigidbody2D>().isKinematic = false;
                go.GetComponent<ILastPositionHandler>().ResetPosition();
            }
            destroyedObj.Clear();
        }
    }
}
