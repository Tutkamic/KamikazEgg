using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToExplode : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneManagerScript;
    private void Update()
    {
        TouchCheck();
    }

    private void TouchCheck()
    {
        if (Input.touchCount != 1 || sceneManagerScript.isIgnite == false)
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);

            if (hit.collider != null)
                if (hit.collider.gameObject.GetComponent<IExplosible>() != null)
                {
                    IExplosible explosibleObject = hit.collider.gameObject.GetComponent<IExplosible>();
                    explosibleObject.Boom();
                }
        }
    }
}
