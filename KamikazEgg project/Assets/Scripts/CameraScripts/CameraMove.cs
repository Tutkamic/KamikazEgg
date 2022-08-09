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
    Vector3 cameraEarthquakePosition;

    float targetZoomSize;

    bool overUI;
    bool flag = false;
    bool firstTouchBegun = false;
    bool isIgnite = false;
    bool dragging = false;
    bool earthquake = false;

    float mapRightBoundary;
    float mapLeftBoundary;
    float earthquakeStartTime;
    float earthquakePower;

    private EggCollision egg;
    private FinishAreaTrigger finishArea;

    private Camera cam;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
        TouchToDrag.DragObject += DragState;
        ObjectExplosionScript.Explode += EarthqauakeStart;
        DragFromInventory.InventoryItemDrag += DragState;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        TouchToDrag.DragObject -= DragState;
        ObjectExplosionScript.Explode -= EarthqauakeStart;
        DragFromInventory.InventoryItemDrag -= DragState;
    }


    // Start is called before the first frame update
    void Start()
    {
        egg = FindObjectOfType<EggCollision>();
        finishArea = FindObjectOfType<FinishAreaTrigger>();
        mapLeftBoundary = egg.transform.position.x;
        mapRightBoundary = finishArea.transform.position.x;
        Application.targetFrameRate = 60;
        cam = Camera.main;

        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CameraDragTouch();
        CameraFollowEgg();
        CameraZoom();
        EarthQuake();
        MovementBounds();
    }

    private void IgniteState(bool objSelected) => isIgnite = objSelected; 

    private void DragState(bool isdragged) => dragging = isdragged;

    private void CameraDragTouch()
    {
        if (Input.touchCount < 1 || isIgnite == true) return;
        else if (Input.touchCount > 1)
        {
            flag = false;
            firstTouchBegun = false;
            return;
        } 
        else if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) overUI = true;
        else overUI = false;

        if (Input.GetTouch(0).phase == TouchPhase.Began && dragging == false)
            DragStartHandle();

        else if (Input.GetTouch(0).phase == TouchPhase.Moved && dragging == false && firstTouchBegun == true)
            DragMoveHandle();

        else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            flag = false;

        if (flag == true && !overUI)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10.0f * Time.deltaTime);
            if (transform.position == targetPosition)  flag = false;
        }

        void TouchMove()
        {
            currentPosition.y = hitPosition.y;
            Vector3 direction = Camera.main.ScreenToWorldPoint(currentPosition) - Camera.main.ScreenToWorldPoint(hitPosition);
            direction *= -1;
            targetPosition = camPosition + direction;
        }

        void DragStartHandle()
        {
            camPosition = transform.position;
            hitPosition = Input.GetTouch(0).position;
            firstTouchBegun = true;
        }

        void DragMoveHandle()
        {
            currentPosition = Input.GetTouch(0).position;
            TouchMove();
            flag = true;
        }
    }

    void CameraFollowEgg()
    {
        if (earthquake) return;
        if (isIgnite)
        {
            Vector3 v3target = new Vector3(egg.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, v3target, 5.0f * Time.deltaTime);
        }
    }

    void CameraZoom()
    {
        if ((Camera.main.WorldToScreenPoint(egg.transform.position).y > Screen.height - 100) || ((Camera.main.WorldToScreenPoint(egg.transform.position).y < Screen.height - 100) && cam.orthographicSize > 5f))
        {
            targetZoomSize = (Camera.main.WorldToScreenPoint(egg.transform.position).y + 100 - Screen.height) * 0.001f;
        }
        else
        {
            targetZoomSize = 0;
        }
        cam.orthographicSize += targetZoomSize * 50 * Time.deltaTime;

        if (cam.orthographicSize < 5)
        {
            cam.orthographicSize = 5;
        }
    }


    private void MovementBounds()
    {
        if (transform.position.x < mapLeftBoundary)
            transform.position = new Vector3(mapLeftBoundary, 0f, -10f);
        if (transform.position.x > mapRightBoundary)
            transform.position = new Vector3(mapRightBoundary, 0f, -10f);
    }

    private void EarthqauakeStart(GameObject bomb)
    {
        earthquakeStartTime = Time.time;
        cameraEarthquakePosition = transform.position;
        earthquake = true;
        earthquakePower = 0.2f;
    }

    private void EarthQuake()
    {
        if (!earthquake) return;

        if (Time.time - earthquakeStartTime < 0.2f)
        {
            float randX = UnityEngine.Random.Range(-earthquakePower, earthquakePower);
            float randY = UnityEngine.Random.Range(-earthquakePower, earthquakePower);
            transform.position = cameraEarthquakePosition + new Vector3(randX, randY, 0);
            if (earthquakePower > 0) earthquakePower -= 1f * Time.deltaTime;
        }
        else earthquake = false;
    }

    void StartPosition()
    {
        Vector3 v3target = new Vector3(egg.transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(v3target.x, v3target.y, transform.position.z);
    }
}
