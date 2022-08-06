using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToDrag : MonoBehaviour
{
    ISelectable selectable;

    private float dist;

    private bool dragging = false;
    private bool startDrag = false;
    private bool isIgnite = false;

    private Vector3 offset;
    private Vector3 startPosition;
    private float startSelectTime;

    private Transform toDrag;

    [SerializeField] LayerMask layerMask;

    GameObject grabbedObject;

    public static event Action<bool> DragObject;
    public static event Action<GameObject> ObjectSelected;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
        InstantiateExplosives.DraggedInventoryItem += ItemToDrag;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        InstantiateExplosives.DraggedInventoryItem -= ItemToDrag;
    }

    void Update()
    {
        DragTouch();
    }

    void DragTouch()
    {
        if (Input.touchCount < 1 || isIgnite)
            return;
        else if (Input.touchCount > 1 && dragging)
        {
            HandleTouchEnded();
        }

        Vector3 v3;
        Touch touch = Input.GetTouch(0);
        Vector3 pos = touch.position;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);



        if (touch.phase == TouchPhase.Began)
        {
            HandleTouchBegin();
        }
        else if (touch.phase == TouchPhase.Moved && startDrag)
        {
            HandleTouchMoved();
        }
        else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && startDrag)
        {
            HandleTouchEnded();
        }


        void HandleTouchBegin()
        {
            if (hit.collider == null)
                return;
            
            if (hit.collider.TryGetComponent<ISelectable>(out var selectableObject))
            {
                if (selectable != null)
                    selectable.UnSelect();
                selectable = selectableObject;
                selectable.Select();

                startSelectTime = Time.time;

                startPosition = hit.transform.position;
                grabbedObject = hit.collider.gameObject;
                toDrag = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;
                startDrag = true;
                if(grabbedObject) ObjectSelected?.Invoke(grabbedObject);
            }
            
        }

        void HandleTouchMoved()
        {
            dragging = true;
            var rb = grabbedObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.useFullKinematicContacts = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            grabbedObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            DragObject?.Invoke(true);

            v3 = new Vector3(pos.x, pos.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }
        void HandleTouchEnded()
        {
            dragging = false;
            startDrag = false;
            DragObject?.Invoke(false);
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.GetComponent<ILastPositionHandler>().LastPositionSave();

            if (grabbedObject.GetComponent<CapsuleCollider2D>().IsTouchingLayers(layerMask))
            {
                grabbedObject.transform.position = startPosition;
            }
        }
    }


    private void IgniteState(bool isOnFire) => isIgnite = isOnFire;

    private void ItemToDrag(GameObject item)
    {
        if (selectable != null)   selectable.UnSelect();
        selectable = item.GetComponent<ISelectable>();
    }
}
