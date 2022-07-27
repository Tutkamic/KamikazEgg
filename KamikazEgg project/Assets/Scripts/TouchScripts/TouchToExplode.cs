using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToExplode : MonoBehaviour
{
    private bool isIgnite = false;
    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteSTate;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteSTate;
    }

    private void Update()
    {
        TouchCheck();
    }

    private void TouchCheck()
    {
        if (Input.touchCount != 1 || isIgnite == false)
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);

            if (hit.collider != null)
                if(hit.collider.tag == "BoomArea")
                {
                    IExplosible explosibleObject = hit.collider.gameObject.GetComponentInParent<IExplosible>();
                    explosibleObject.Boom();
                }
                else if (hit.collider.TryGetComponent<IExplosible>(out var explosibeObject))
                {
                    //IExplosible explosibleObject = explosibeObject;
                    explosibeObject.Boom();
                }
        }
    }
    private void IgniteSTate(bool isOnFire) => isIgnite = isOnFire;
}
