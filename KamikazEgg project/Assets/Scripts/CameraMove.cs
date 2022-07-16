using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    [SerializeField] TouchToDrag touchToDragScript;

    Vector2 dragDistance;
    Vector3 camPosition;
    Vector3 hitPosition;
    Vector3 currentPosition;
    Vector3 targetPosition;

    bool flag = false;
    bool firstTouchBegun = false;

    public float mapRightBoundary;
    public float mapLeftBoundary;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        CameraDragTouch();
        MovementBounds();
    }


    private void CameraDragTouch()
    {
        if (Input.touchCount < 1)
            return;
        else if (Input.touchCount > 1)
        {
            flag = false;
            firstTouchBegun = false;
            return;
        } 
        else if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began && touchToDragScript.dragging == false)
        {
            camPosition = transform.position;
            hitPosition = Input.GetTouch(0).position;
            firstTouchBegun = true;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Moved && touchToDragScript.dragging == false && firstTouchBegun == true)
        {
            currentPosition = Input.GetTouch(0).position;
            TouchMove();
            flag = true;

        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            flag = false;

        if (flag == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 40.0f * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                flag = false;
            }
        }

        void TouchMove()
        {
            currentPosition.y = hitPosition.y;
            Vector3 direction = Camera.main.ScreenToWorldPoint(currentPosition) - Camera.main.ScreenToWorldPoint(hitPosition);
            direction *= -1;
            targetPosition = camPosition + direction;
        }
    }




    private void MovementBounds()
    {
        if (this.transform.position.x < mapLeftBoundary)
            this.transform.position = new Vector3(mapLeftBoundary, 0f, -10f);
        if (this.transform.position.x > mapRightBoundary)
            this.transform.position = new Vector3(mapRightBoundary, 0f, -10f);
    }
}
