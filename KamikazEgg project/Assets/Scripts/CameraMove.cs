using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 dragDistance;
    Touch firstTouch;
    public float mapRightBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraDragTouch();
        MovementBounds();
    }

    private void CameraDragTouch()
    {
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                dragDistance = firstTouch.deltaPosition;
                this.transform.position += new Vector3(-dragDistance.x, 0f, 0f) * Time.deltaTime * 0.25f;
            }

        }
    }


    private void MovementBounds()
    {
        if (this.transform.position.x < 0f)
            this.transform.position = new Vector3(0f, 0f, -10f);
        if (this.transform.position.x > mapRightBoundary)
            this.transform.position = new Vector3(mapRightBoundary, 0f, -10f);
    }
}
