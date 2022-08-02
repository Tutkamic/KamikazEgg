using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFromInventory : MonoBehaviour
{
    bool isIgnite = false;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
    }

    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        ButtonControllerScript.DragItem -= DragItemStart;
    }

    private void Update()
    {
        DragFromInv();
    }

    void DragFromInv()
    {
        if (Input.touchCount < 1 || isIgnite) return;
        //else if (Input.touchCount > 1 && dragging) HandleTouchEnded();
    }

    private void IgniteState(bool isOnFire) => isIgnite = isOnFire;

    private void DragItemStart(int explosive)
    {

    }
}
